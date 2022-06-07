using NAudio.Wave;

namespace AudioWave.App.Devices;

/// <summary>
/// Audio input devices.
/// </summary>
public interface IInputDevices
{
	/// <summary>
	/// All available input devices' names.
	/// </summary>
	IEnumerable<string> AllNames();

	/// <summary>
	/// Load input device by its' zero-based index. 
	/// </summary>
	WaveInEvent LoadByIndex(int index, EventHandler<WaveInEventArgs> onDataAvailable);
}