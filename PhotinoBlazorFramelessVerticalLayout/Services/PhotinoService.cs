using Photino.Blazor;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace PhotinoBlazorFramelessVerticalLayout.Services
{
    public class PhotinoService
    {
        public PhotinoBlazorApp? App { get; set; } = null;

        // TODO: move interop to photino.NET and expose API
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SetCapture(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern bool PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);


        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_LBUTTONUP = 0x202;
    }

}
