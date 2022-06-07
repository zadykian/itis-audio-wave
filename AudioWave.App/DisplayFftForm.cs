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
	}

	private void FillDevicesComboBox()
	{
		inputDevices
			.AllNames()
			.ForEach(deviceName => devicesComboBox.Items.Add(deviceName));

		if (devicesComboBox.Items.Count == 0) MessageBox.Show("No any input devices found!");
		else devicesComboBox.SelectedIndex = 0;
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
		for (int i = 0; i < samplesRecorded; i++)
			lastBuffer[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
	}

	private void RenderAll(object sender, EventArgs e)
	{
		RenderOriginalSignal();
		RenderTransformedSignal();
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
			originalPlot = originalFormPlot.Plot.AddSignal(lastBuffer.Select(Math.Log10).ToArray());
		}
		else
		{
			originalPlot.Ys = lastBuffer;
		}

		originalFormPlot.Plot.XLabel("Time");
		originalFormPlot.Plot.YLabel("Signal amplitude");

		originalFormPlot.Plot.AxisAuto(horizontalMargin: 0);
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
		//double[] windowed = lastBuffer;
		double[] zeroPadded = Pad.ZeroPad(windowed);
		double[] fftPower = Transform.FFTpower(zeroPadded);
		double[] fftFreq = Transform.FFTfreq(currentAudioEvent.WaveFormat.SampleRate, fftPower.Length);

		peakLabel.Text = $"Peak Frequency: {PeakFrequency(fftPower, fftFreq):N0} Hz";
		transformedFormPlot.Plot.XLabel("Frequency Hz");
		transformedFormPlot.Plot.YLabel("Decibels");


		if (!transformedFormPlot.Plot.GetPlottables().Any())
		{
			transformedPlot = transformedFormPlot.Plot.AddSignal(
				fftPower,
				2.0 * fftPower.Length / currentAudioEvent.WaveFormat.SampleRate);
		}
		else
		{
			transformedPlot.Ys = fftPower;
		}

		if (cbAutoAxis.Checked)
		{
			try
			{
				transformedFormPlot.Plot.AxisAuto(horizontalMargin: 0);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

		try
		{
			transformedFormPlot.Render();
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex);
		}
	}

	/// <summary>
	/// Determine peak frequency based on Fast 
	/// </summary>
	private static double PeakFrequency(IEnumerable<double> fftPower, IEnumerable<double> fftFreq)
		=> fftPower
			.Zip(fftFreq, (x, y) => (PowerSample: x, FreqSample: y))
			.MaxBy(tuple => tuple.PowerSample)
			.FreqSample;
}