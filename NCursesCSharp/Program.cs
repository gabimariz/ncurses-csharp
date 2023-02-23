using NCursesCSharp.Enums;
using NCursesCSharp.Structs;
using NCursesCSharp.Wrappers;

NCursesWrapper curses = new();

Window window1, window2;

int maxX, maxY;
curses.GetMaxY(IntPtr.Zero, out maxY);
curses.GetMaxX(IntPtr.Zero, out maxX);

curses.InitScr();

curses.StartColor();

curses.InitPair(1, (short)Color.White, (short)Color.Blue);
curses.InitPair(2, (short)Color.Blue, (short)Color.White);
curses.InitPair(3, (short)Color.Red, (short)Color.White);
curses.InitPair(4, (short)Color.Green, (short)Color.Black);
curses.InitPair(5, (short)Color.Red, (short)Color.Blue);

curses.Bkgd(curses.ColorPair(1));

for (; ; )
{
	curses.Refresh();

	curses.AttrOn(curses.ColorPair(3));

	curses.MvPrintW(2, 1, "Principal Menu");

	curses.AttrOff(curses.ColorPair(3));

	curses.AttrOn(curses.ColorPair(2));
	curses.MvPrintW(4, 5, "1. Window 1");
	curses.MvPrintW(5, 5, "2. Window 2");

	curses.MvPrintW(6, 5, "3. Exit");
	curses.AttrOff(curses.ColorPair(2));

	curses.MvPrintW(8, 5, "> ");
	var key = Convert.ToChar(curses.Getch());

	curses.Refresh();

	switch (key)
	{
		case '1':
			window1 = curses.NewWin(maxY, maxX, 0, 0);

			curses.WBkgd(window1, curses.ColorPair(4));
			curses.WattrOn(window1, (int)NCursesAttrT.ABold);
			curses.MvWPrintW(window1, 2, 1, "Green WINDOW1 with A_BOLD. Press any key to exit.");
			curses.WattrOff(window1, (int)NCursesAttrT.ABold);
			curses.WRefresh(window1);
			curses.WGetch(window1);
			curses.DelWin(window1);

			curses.TouchWin(window1);
			break;
		case '2':
			window2 = curses.NewWin(maxY, maxX, 0, 0);
			curses.WBkgd(window2, curses.ColorPair(3));
			curses.Box(window2, 0, 0);
			curses.MvWPrintW(window2, 2, 2, "Green WINDOW2 without A_BOLD. Press any key to exit.");
			curses.WRefresh(window2);
			curses.WGetch(window2);
			curses.DelWin(window2);
			break;
		case '3':
			curses.EndWin();
			Environment.Exit(0);
			break;
		default:
			int keyErr;
			do
			{
				curses.AttrOn(curses.ColorPair(5));

				curses.MvPrintW(10, 5, $"INVALID OPTION.. PRESS [ENTER]");
				keyErr = curses.Getch();

				curses.AttrOff(curses.ColorPair(5));
			} while (keyErr != 10);

			break;
	}

	curses.Clear();
	curses.Refresh();
}
