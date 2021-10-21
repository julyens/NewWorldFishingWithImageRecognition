//you need these
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

//CLASS CLICK
public class Clickarino
{
    [DllImport("user32.dll")]
    static extern void mouse_event(int dwFlags, int dx, int dy,int dwData, int dwExtraInfo);

    [Flags]
    public enum MouseEventFlags
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010
    }

    public static void leftClick(Point p)
    {
        Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
    }


    public static void holDownLeft(Point p, int tempo)
    {
        Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        Thread.Sleep(tempo);
        mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
    }
}