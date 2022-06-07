using System.Windows.Forms;
using AudioWave.App.Devices;
using NAudio.Wave;
using ScottPlot.Plottable;

// ReSharper disable LocalizableElement

namespace AudioWave.App;

public partial class DisplayFftForm : Form
{
	private readonly IInputDevices inputDevices = new InputDevices();
	private WaveInEvent currentAudioEvent;
	
	public DisplayFftForm()
	{
		InitializeComponent();
		FillDevicesComboBox();
	}

	private void FillDevicesComboBox()
	{
		inputDevices
			.AllNames()
			.ForEach(deviceName => devicesComboBox.Items.Add(deviceName));

		if (devicesComboBox.Items.Count == 0) MessageBox.Show("No any input devices found!");
		else devicesComboBox.SelectedIndex = 0;
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

	private SignalPlot signalPlot;

	private void RunSingleIteration(object sender, EventArgs e)
	{
		if (lastBuffer is null)
		{
			return;
		}

		var window = new FftSharp.Windows.Hanning();
		double[] windowed = window.Apply(lastBuffer);
		double[] zeroPadded = FftSharp.Pad.ZeroPad(windowed);
		double[] fftPower = FftSharp.Transform.FFTpower(zeroPadded);
		double[] fftFreq = FftSharp.Transform.FFTfreq(currentAudioEvent.WaveFormat.SampleRate, fftPower.Length);

		// determine peak frequency
		double peakFreq = 0;
		double peakPower = 0;
		for (int i = 0; i < fftPower.Length; i++)
		{
			if (fftPower[i] > peakPower)
			{
				peakPower = fftPower[i];
				peakFreq = fftFreq[i];
			}
		}
		peakLabel.Text = $"Peak Frequency: {peakFreq:N0} Hz";

		formsPlot1.Plot.XLabel("Frequency Hz");

		// make the plot for the first time, otherwise update the existing plot
		if (!formsPlot1.Plot.GetPlottables().Any())
		{
			signalPlot = formsPlot1.Plot.AddSignal(fftPower, 2.0 * fftPower.Length / currentAudioEvent.WaveFormat.SampleRate);
		}
		else
		{
			signalPlot.Ys = fftPower;
		}

		if (cbAutoAxis.Checked)
		{
			try
			{
				formsPlot1.Plot.AxisAuto(horizontalMargin: 0);
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine(ex);
			}
		}

		try
		{
			formsPlot1.Render();
		}
		catch (Exception ex)
		{
			System.Diagnostics.Debug.WriteLine(ex);
		}
	}
}