using System.Collections.Immutable;
using NAudio.Wave;

namespace AudioWave.App.Devices;

/// <inheritdoc />
internal class InputDevices : IInputDevices
{
	/// <inheritdoc />
	IEnumerable<string> IInputDevices.AllNames()
		=> Enumerable
			.Range(0, WaveIn.DeviceCount)
			.Select(index => WaveIn.GetCapabilities(index).ProductName)
			.ToImmutableArray();

	/// <inheritdoc />
	WaveInEvent IInputDevices.LoadByIndex(int index, EventHandler<WaveInEventArgs> onDataAvailable)
	{
		var waveInEvent = new WaveInEvent();
		waveInEvent.DeviceNumber = index;
		waveInEvent.WaveFormat = new WaveFormat(rate: 44100, bits: 16, channels: 1);
		waveInEvent.DataAvailable += onDataAvailable;
		waveInEvent.BufferMilliseconds = 20;
		waveInEvent.StartRecording();
		return waveInEvent;
	}
}