using System.Windows.Forms;
using AudioWave.App.Devices;
using NAudio.Wave;

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
	
	double[] lastBuffer;
	private void OnDataAvailable(object _, WaveInEventArgs args)
	{
		var bytesPerSample = currentAudioEvent.WaveFormat.BitsPerSample / 8;
		var samplesRecorded = args.BytesRecorded / bytesPerSample;


		if (lastBuffer is null || lastBuffer.Length != samplesRecorded)
			lastBuffer = new double[samplesRecorded];
		for (int i = 0; i < samplesRecorded; i++)
			lastBuffer[i] = BitConverter.ToInt16(args.Buffer, i * bytesPerSample);
	}



	private void RunSingleIteration(object sender, EventArgs e)
	{
	}
}