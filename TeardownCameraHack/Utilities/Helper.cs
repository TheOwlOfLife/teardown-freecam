using System;
using System.Runtime.InteropServices;

namespace TeardownCameraHack.Utilities
{
    public static class Helper
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct Point
        {
            public int X, Y;
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        public static System.Drawing.Rectangle GetWindowRectangle(IntPtr handle)
        {
            return User32.ClientToScreen(handle, out var point) && User32.GetWindowRect(handle, out var rect)
                ? new System.Drawing.Rectangle(point.X, point.Y, rect.Right - rect.Left, rect.Bottom - rect.Top)
                : default;
        }
        public static bool IsRunning(this System.Diagnostics.Process process)
        {
            try
            {
                System.Diagnostics.Process.GetProcessById(process.Id);
            }
            catch (InvalidOperationException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
            return true;
        }
    }
}
