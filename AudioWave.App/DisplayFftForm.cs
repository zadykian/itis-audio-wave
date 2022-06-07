using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using AudioWave.App.Devices;
using FftSharp;
using FftSharp.Windows;
using NAudio.Wave;
using ScottPlot.Plottable;
using Spectrogram;

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
		SpectrogramBox.Height = spectrogramGenerator.Height;
	}

	private void FillDevicesComboBox()
	{
		inputDevices
			.AllNames()
			.ForEach(deviceName => devicesComboBox.Items.Add(deviceName));

		devicesComboBox.SelectedIndex = 0;
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
		audioSamplesQueue.Add(lastBuffer);
	}

	private void RenderAll(object sender, EventArgs e)
	{
		try
		{
			RenderOriginalSignal();
			RenderTransformedSignal();
			RenderSpectrogram();
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

		var window = new Hanning();
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

	private readonly SpectrogramGenerator spectrogramGenerator = new(6000, 1024, 50, minFreq: 0, maxFreq: 2500)
		{Colormap = Colormap.Turbo};
	private readonly BlockingCollection<double[]> audioSamplesQueue = new();

	private void RenderSpectrogram()
	{
		var newAudio = audioSamplesQueue.Take();
		spectrogramGenerator.Add(newAudio, process: false);

		if (spectrogramGenerator.FftsToProcess <= 0)
		{
			return;
		}

		spectrogramGenerator.Process();
		spectrogramGenerator.SetFixedWidth(SpectrogramBox.Width);
		var bitmap = new Bitmap(spectrogramGenerator.Width, spectrogramGenerator.Height, PixelFormat.Format32bppPArgb);
		using (var bmpSpecIndexed = spectrogramGenerator.GetBitmap(intensity:1.5d))
		using (var graphics = Graphics.FromImage(bitmap))
		{
			graphics.DrawImage(bmpSpecIndexed, 0, 0);
		}
		SpectrogramBox.Image?.Dispose();
		SpectrogramBox.Image = bitmap;
	}

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