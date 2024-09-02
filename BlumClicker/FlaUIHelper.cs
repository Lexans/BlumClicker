using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlumClicker
{
    public class FlaUIHelper
    {
        public static UIA3Automation automation = new UIA3Automation();
        public Window appWindow;

        public FlaUIHelper(string windowName)
        {
            WindowSetByName(windowName);
        }

        public FlaUIHelper(string process, string windowClass)
        {
            WindowSetByClass(process, windowClass);
        }

        public void WindowSetByName(string windowName)
        {
            appWindow = automation.GetDesktop().FindFirstDescendant(cf => cf.ByName(windowName))?.AsWindow();
        }

        public void WindowSetByClass(string process, string windowClass)
        {
            var app = FlaUI.Core.Application.Attach(process);
            var mainWindow = app.GetMainWindow(automation);
            var windowByClass = mainWindow.FindFirstByXPath($"Window[@ClassName='{windowClass}']");
            appWindow = mainWindow.AsWindow();
        }

        public void WindowFocus()
        {
            appWindow.Focus();
        }

        public Bitmap WindowCapture()
        {
            var screenshot = appWindow.Capture();

            return screenshot;
        }

        public void WindowMouseClick(Point p)
        {
            var screenX = appWindow.BoundingRectangle.Left + p.X;
            var screenY = appWindow.BoundingRectangle.Top + p.Y;

            Mouse.Click(new Point(screenX, screenY));
        }
    }
}
