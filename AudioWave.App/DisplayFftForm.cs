using System.Windows.Forms;
using AudioWave.App.Devices;
using FftSharp;
using NAudio.Wave;
using ScottPlot.Plottable;

// ReSharper disable LocalizableElement

namespace AudioWave.App;

public partial class DisplayFftForm : Form
{
	private static readonly IReadOnlyCollection<IWindow> allWindows = Window.GetWindows();
	private readonly IInputDevices inputDevices = new InputDevices();
	private WaveInEvent currentAudioEvent;

	public DisplayFftForm()
	{
		InitializeComponent();
		FillDevicesComboBox();
		FillWindowTypeComboBox();
		windowTypeComboBox.SelectedIndexChanged += (_, _) => RenderTransformedSignal();
	}

	private void FillDevicesComboBox()
	{
		inputDevices
			.AllNames()
			.ForEach(deviceName => devicesComboBox.Items.Add(deviceName));

		devicesComboBox.SelectedIndex = 0;
	}

	private void FillWindowTypeComboBox()
	{
		allWindows.ForEach(window => windowTypeComboBox.Items.Add(window));
		windowTypeComboBox.SelectedIndex = 0;
	}

	private void ChangeInputDevice(object sender, EventArgs e)
	{
		currentAudioEvent?.Dispose();
		currentAudioEvent = inputDevices.LoadByIndex(devicesComboBox.SelectedIndex, OnDataAvailable);
	}

	private double[] lastBuffer;

	private void OnDataAvailable(object _, WaveInEventArgs args)
	{
		var bytesPerSample = currentAudioEvent.WaveFormat.BitsPerSample / 8;
		var samplesRecorded = args.BytesRecorded / bytesPerSample;

		if (lastBuffer is null || lastBuffer.Length != samplesRecorded)
			lastBuffer = new double[samplesRecorded];
		for (var i = 0; i < samplesRecorded; i++)
			lastBuffer[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
	}

	private void RenderAll(object sender, EventArgs e)
	{
		try
		{
			RenderOriginalSignal();
			RenderTransformedSignal();
		}
		catch (Exception exception)
		{
			System.Diagnostics.Debug.WriteLine(exception);
		}
	}

	private SignalPlot originalPlot;

	private void RenderOriginalSignal()
	{
		if (lastBuffer is null)
		{
			return;
		}

		if (!originalFormPlot.Plot.GetPlottables().Any())
		{
			originalPlot = originalFormPlot.Plot.AddSignal(lastBuffer.Select(x => x).ToArray());
		}
		else
		{
			originalPlot.Ys = lastBuffer;
		}

		originalFormPlot.Plot.XLabel("Time");
		originalFormPlot.Plot.YLabel("Signal amplitude");

		if (autoAxisOriginal.Checked)
		{
			originalFormPlot.Plot.AxisAuto(horizontalMargin: 0);
		}

		originalFormPlot.Render();
	}

	private SignalPlot transformedPlot;

	private void RenderTransformedSignal()
	{
		if (lastBuffer is null)
		{
			return;
		}

		var window = allWindows.ElementAt(windowTypeComboBox.SelectedIndex);
		double[] windowed = window.Apply(lastBuffer);
		double[] zeroPadded = Pad.ZeroPad(windowed);
		double[] fftPower = Transform.FFTpower(zeroPadded);
		double[] fftFreq = Transform.FFTfreq(44100, fftPower.Length);

		peakLabel.Text = $"Peak Frequency: {PeakFrequency(fftPower, fftFreq):N0} Hz";
		transformedFormPlot.Plot.XLabel("Frequency Hz");
		transformedFormPlot.Plot.YLabel("Decibels");

		if (!transformedFormPlot.Plot.GetPlottables().Any())
		{
			transformedPlot = transformedFormPlot.Plot.AddSignal(
				fftPower,
				2.0 * fftPower.Length / 44100);
		}
		else
		{
			transformedPlot.Ys = fftPower;
		}

		if (autoAxisTransformed.Checked)
		{
			transformedFormPlot.Plot.AxisAuto(horizontalMargin: 0);
		}

		transformedFormPlot.Render();
	}

	/// <summary>
	/// Determine peak frequency based on Fast 
	/// </summary>
	private static double PeakFrequency(IEnumerable<double> fftPower, IEnumerable<double> fftFreq)
		=> fftPower
			.Zip(fftFreq, (x, y) => (PowerSample: x, FreqSample: y))
			.MaxBy(tuple => tuple.PowerSample)
			.FreqSample;

	private void OnStartRenderPressed(object sender, EventArgs e)
	{
		if (eventLoopTimer.Enabled)
		{
			eventLoopTimer.Enabled = false;
			startRenderButton.Text = "Start";
		}
		else
		{
			eventLoopTimer.Enabled = true;
			startRenderButton.Text = "Stop";
		}
	}
}