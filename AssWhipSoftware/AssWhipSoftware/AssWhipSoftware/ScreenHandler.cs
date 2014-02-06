using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssWhipSoftware
{
    public static class ScreenHandler
    {
        private static List<Screen> screens = new List<Screen>();

        public static Screen NextScreen
        {
            get { try { return screens[screens.Count - 1]; } catch { /*Console.WriteLine("No Screen");*/  return null; } }
            set { screens.Add(value); }
        }

        public static void RemoveScreen(Screen Screen)
        {
            screens.Remove(Screen);
        }
    }
}
