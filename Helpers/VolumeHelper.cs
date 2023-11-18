using System;
using System.Runtime.InteropServices;

namespace Auto_VOL.Helpers
{
    public class VolumeHelper
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessageW(IntPtr hWnd, int Msg,
           IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int APPCOMMAND_VOLUME_DOWN = 0x90000;
        private const int WM_APPCOMMAND = 0x319;

        private readonly IntPtr hWnd = FindWindow("Shell_TrayWnd", null);

        private void VolDown()
        {
            SendMessageW(hWnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_DOWN);
        }

        private void VolUp()
        {
            SendMessageW(hWnd, WM_APPCOMMAND, IntPtr.Zero, (IntPtr)APPCOMMAND_VOLUME_UP);
        }

        public void SetVolume(int volume)
        {
            volume >>= 1;

            for (int i = 0; i < 50; i++)
            {
                VolDown();
            }

            for (int i = 0; i < volume; i++)
            {
                VolUp();
            }
        }
    }
}
