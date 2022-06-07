using System.Windows.Forms;

namespace AudioWave.App;

/// <summary>
/// Application entry point. 
/// </summary>
internal static class Program
{
	/// <summary>
	/// Entry point method. 
	/// </summary>
	private static void Main() => Application.Run(new DisplayFftForm());
}