﻿using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;
namespace INFT2051_Project.Services.PartialMethods
{
    static partial class WindowSizeHandler
    {
        const int WindowWidth = 400;
        const int WindowHeight = 780;
        static partial void SetWindowSize()
        {
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(nameof(IWindow),
            (handler, view) =>
            {
                var mauiWindow = handler.VirtualView;
                var nativeWindow = handler.PlatformView;
                nativeWindow.Activate();
                IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                WindowId windowId =
    Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                AppWindow appWindow =
    Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
            });
        }
    }
}