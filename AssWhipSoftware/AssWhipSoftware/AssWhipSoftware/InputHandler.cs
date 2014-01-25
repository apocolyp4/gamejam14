using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssWhipSoftware
{
    public static class InputHandler
    {
        private static List<InputEvent> Events = new List<InputEvent>();
        public static InputEvent NextEvent
        {
            get
            {
                try
                {
                    return Events[0];
                }
                catch
                {
                    Console.WriteLine("No Event");
                    return null;
                }
            }
            set { Events.Add(value);
            Console.WriteLine("adding Event");
            }
            
        }

        public static void RemoveEvent(InputEvent Event)
        {
            Events.Remove(Event);
            //Events.Clear();
        }
    }
    public enum InputType
    {
        PRESSED,
        HELD,
        RELEASED,
        MULTIPLE
    }

    public enum InputState
    {
        JUMP,
        ASSWHIP,
        CLAW,
        BITE,
        LEFT,
        RIGHT,
        UP,
        DOWN,
        PAUSE,
        SELECT,
        NULL
    }
}
