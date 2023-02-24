using System.Runtime.InteropServices;

namespace NCursesCSharp.Utils;

public class Library
{
	private static readonly string[] LinuxLibraryNames = new string[]
	{
		"ncurses",
		"ncursesw",
		"libncurses.so",
		"libncurses.so.5",
		"libncursesw.so",
		"libncursesw.so.6"
	};
	public static void Load(out string library)
	{
		if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
		{
			library = "";

			foreach (string name in LinuxLibraryNames)
			{
				try
				{
					NativeLibrary.Load(name);
					library = name;
					break;
				}
				catch (DllNotFoundException) { }
			}

			if (library == "")
			{
				throw new DllNotFoundException("Could not find ncurses library.");
			}
		}
		else
		{
			throw new ArgumentException("OS not supported!");
		}

	}
}
