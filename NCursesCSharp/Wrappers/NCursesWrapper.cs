using System.Runtime.InteropServices;
using NCursesCSharp.Enums;
using NCursesCSharp.Structs;

namespace NCursesCSharp.Wrappers;

public class NCursesWrapper
{
	private const string NCURSES_LIB = "libncursesw.so.6";

	// Import C/C++ ncurses.h functions

	[DllImport(NCURSES_LIB, EntryPoint = "attroff")]
	private static extern int attroff(NCursesAttrT attrT);

	[DllImport(NCURSES_LIB, EntryPoint = "attron")]
	private static extern int attron(NCursesAttrT attrT);

	[DllImport(NCURSES_LIB, EntryPoint = "bkgd")]
	private static extern int bkgd(uint ch);

	/*
   * The NCURSES.H library has standard constants representing the characters for the creation of
   * borders. By default I decided to use the value (uint) as a base, if you want to keep compatibility on
   * different operating systems I recommend the use of "(uint)'-'" that the character will be converted.
   */
	[DllImport(NCURSES_LIB, EntryPoint = "box")]
	private static extern int box(Window window, uint num, uint num2);

	[DllImport(NCURSES_LIB, EntryPoint = "clear")]
	private static extern int clear();

	[DllImport(NCURSES_LIB, EntryPoint = "COLOR_PAIR")]
	private static extern uint COLOR_PAIR(short value);

	[DllImport(NCURSES_LIB, EntryPoint = "delwin")]
	private static extern int delwin(Window window);

	[DllImport(NCURSES_LIB, EntryPoint = "endwin")]
	private static extern int endwin();

	[DllImport(NCURSES_LIB, EntryPoint = "getch")]
	private static extern int getch();

	[DllImport(NCURSES_LIB, EntryPoint = "getmaxx")]
	private static extern int getmaxx(IntPtr ptr, out int x);

	[DllImport(NCURSES_LIB, EntryPoint = "getmaxy")]
	private static extern int getmaxy(IntPtr ptr, out int y);

	[DllImport(NCURSES_LIB, EntryPoint = "init_pair")]
	private static extern int init_pair(short value1, short value2, short value3);

	[DllImport(NCURSES_LIB, EntryPoint = "initscr")]
	private static extern void initscr();

	/*
	 * the NCURSES function MVPRINTW() expects two parameters "char*" and "...", to maintain compatibility
	 * to maintain compatibility of parameters defined within the function I chose to send only the
	 * string to print a variable by C# should be expected to use $"{variable}".
	 */
	[DllImport(NCURSES_LIB, EntryPoint = "mvprintw")]
	private static extern int mvprintw(int num, int num2, string str);

	/*
	 * the NCURSES function MVWPRINTW() expects two parameters "char*" and "..." in addition to numbers, to maintain compatibility
	 * to maintain compatibility of parameters defined within the function I chose to send only the
	 * string to print a variable by C# should be expected to use $"{variable}".
	 */
	[DllImport(NCURSES_LIB, EntryPoint = "mvwprintw")]
	private static extern int mvwprintw(Window window, int num, int num2, string str);

	[DllImport(NCURSES_LIB, EntryPoint = "newwin")]
	private static extern Window newwin(int rows, int columns, int row, int column);

	/*
	 * the NCURSES function PRINTW() expects two parameters "char*" and "..." in addition to numbers, to maintain compatibility
	 * to maintain compatibility of parameters defined within the function I chose to send only the
	 * string to print a variable by C# should be expected to use $"{variable}".
	 */
	[DllImport(NCURSES_LIB, EntryPoint = "printw")]
	private static extern int printw(string str);

	[DllImport(NCURSES_LIB, EntryPoint = "refresh")]
	private static extern int refresh();

	[DllImport(NCURSES_LIB, EntryPoint = "start_color")]
	private static extern int start_color();

	[DllImport(NCURSES_LIB, EntryPoint = "touchwin")]
	private static extern int touchwin(Window window);

	[DllImport(NCURSES_LIB, EntryPoint = "wattroff")]
	private static extern int wattroff(Window window, int num);

	[DllImport(NCURSES_LIB, EntryPoint = "wattron")]
	private static extern int wattron(Window window, int num);

	[DllImport(NCURSES_LIB, EntryPoint = "wbkgd")]
	private static extern int wbkgd(Window window, uint ch);

	[DllImport(NCURSES_LIB, EntryPoint = "wclear")]
	private static extern int wclear(Window window);

	[DllImport(NCURSES_LIB, EntryPoint = "werase")]
	private static extern int werase(Window window);

	[DllImport(NCURSES_LIB, EntryPoint = "wgetch")]
	private static extern int wgetch(Window window);

	[DllImport(NCURSES_LIB, EntryPoint = "wrefresh")]
	private static extern int wrefresh(Window window);

	/// <summary>
	/// Disable one text attribute.
	/// </summary>
	/// <param name="attrs">Attribute to be deactivated.</param>
	/// <returns>Returns 0 if the operation was successful or a negative value if it failed.</returns>
	public int AttrOff(uint attrs)
	{
		// Convert the value of attrs to the type NCursesAttrT.
		NCursesAttrT ncursesAttrT = (NCursesAttrT)attrs;

		return attroff(ncursesAttrT);
	}

	/// <summary>
	/// Activate a new text attribute.
	/// </summary>
	/// <param name="attrs">Attribute to be active.</param>
	/// <returns>Returns 0 if the operation was successful or a negative value if it failed.</returns>
	public int AttrOn(uint attrs)
	{
		// Convert the value of attrs to the type NCursesAttrT.
		NCursesAttrT ncursesAttribute = (NCursesAttrT)attrs;

		return attron(ncursesAttribute);
	}

	/// <summary>
	/// Changes the background and text color in the window.
	/// </summary>
	/// <param name="value">Receives the defined colors.</param>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int Bkgd(uint value)
	{
		return bkgd(value);
	}

	/// <summary>
	/// Adds borders to the window.
	/// </summary>
	/// <param name="window">Receives the current window.</param>
	/// <param name="num">Takes a value (uint) that represents an alphanumeric character.</param>
	/// <param name="num2">Takes a value (uint) that represents an alphanumeric character.</param>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int Box(Window window, uint num, uint num2)
	{
		return box(window, num, num2);
	}

	/// <summary>
	/// Clears the previous screen.
	/// </summary>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int Clear()
	{
		return clear();
	}

	/// <summary>
	/// Selects the chosen color setting.
	/// </summary>
	/// <param name="value">Chosen value that has the colors set.</param>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public uint ColorPair(short value)
	{
		return COLOR_PAIR(value);
	}

	/// <summary>
	/// Delete a window.
	/// </summary>
	/// <param name="window">Get the window to be deleted.</param>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int DelWin(Window window)
	{
		return delwin(window);
	}

	/// <summary>
	/// Closes the window
	/// </summary>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int EndWin()
	{
		return endwin();
	}

	/// <summary>
	/// Waits for the user to type a key.
	/// </summary>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int Getch()
	{
		return getch();
	}

	/// <summary>
	/// Checks the column size of the terminal and returns the total number of columns.
	/// </summary>
	/// <param name="ptr">Receives an empty pointer.</param>
	/// <param name="x">Variable that will be attributed to the total value of columns.</param>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int GetMaxX(IntPtr ptr, out int x)
	{
		return getmaxx(ptr, out x);
	}

	/// <summary>
	/// Check the row size of the terminal and returns the total number of rows.
	/// </summary>
	/// <param name="ptr">Receives ab empty pointer.</param>
	/// <param name="y">Variable that will be attributed to the total value of rows.</param>
	/// <returns>Return 0 if the operation was successful or a negative value if it failed.</returns>
	public int GetMaxY(IntPtr ptr, out int y)
	{
		return getmaxy(ptr, out y);
	}

	/// <summary>
	/// Defines the background and text colors of the window.
	/// </summary>
	/// <param name="value">Value that will represent the colors.</param>
	/// <param name="textColor">Text color.</param>
	/// <param name="backgroundColor">Background color.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int InitPair(short value, short textColor, short backgroundColor)
	{
		return init_pair(value, textColor, backgroundColor);
	}

	/// <summary>
	/// Starts the NCURSES mode.
	/// </summary>
	public void InitScr()
	{
		initscr();
	}

	/// <summary>
	/// It sets the position and prints the text.
	/// </summary>
	/// <param name="row">Sets the line number.</param>
	/// <param name="col">Sets the column number.</param>
	/// <param name="str">Text to be printed.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int MvPrintW(int row, int col, string str)
	{
		return mvprintw(row, col, str);
	}

	/// <summary>
	/// It sets the position and prints the text in the window.
	/// </summary>
	/// <param name="window">Current window.</param>
	/// <param name="row">Sets the line number.</param>
	/// <param name="col">Sets the column number.</param>
	/// <param name="str">Text to be printed.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int MvWPrintW(Window window, int row, int col, string str)
	{
		return mvwprintw(window, row, col, str);
	}

	/// <summary>
	/// Create a new window
	/// </summary>
	/// <param name="rows">Sets the lines number.</param>
	/// <param name="columns">Sets the columns number.</param>
	/// <param name="row">Set the line number.</param>
	/// <param name="column">Set the column number.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public Window NewWin(int rows, int columns, int row, int column)
	{
		return newwin(rows, columns, row, column);
	}

	/// <summary>
	/// Prints a text.
	/// </summary>
	/// <param name="str">Text to be printed.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int PrintW(string str)
	{
		return printw(str);
	}

	/// <summary>
	/// Updates the window display.
	/// </summary>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int Refresh()
	{
		return refresh();
	}

	/// <summary>
	/// Enables the possibility to use colors in the program.
	/// </summary>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int StartColor()
	{
		return start_color();
	}

	/// <summary>
	/// Marks the entire window as modified.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int TouchWin(Window window)
	{
		return touchwin(window);
	}

	/// <summary>
	/// Disables one or more text attributes in the current window.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <param name="num">Attribute to be deactivated</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WattrOff(Window window, int num)
	{
		return wattroff(window, num);
	}

	/// <summary>
	/// Activate a new text attribute in the current window
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <param name="num">Attribute to be enabled.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WattrOn(Window window, int num)
	{
		return wattron(window, num);
	}

	/// <summary>
	/// Changes the background color and text in the current window.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <param name="ch">attribute to add color</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WBkgd(Window window, uint ch)
	{
		return wbkgd(window, ch);
	}

	/// <summary>
	/// Clear curr window.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WClear(Window window)
	{
		return wclear(window);
	}

	/// <summary>
	/// Deletes the window contents.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WErase(Window window)
	{
		return werase(window);
	}

	/// <summary>
	/// Waits for the user to type a key in curr window.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WGetch(Window window)
	{
		return wgetch(window);
	}

	/// <summary>
	/// Updates the window display in curr window.
	/// </summary>
	/// <param name="window">Curr window.</param>
	/// <returns>Return 0 if operation was successful or a negative value if it failed.</returns>
	public int WRefresh(Window window)
	{
		return wrefresh(window);
	}
}
