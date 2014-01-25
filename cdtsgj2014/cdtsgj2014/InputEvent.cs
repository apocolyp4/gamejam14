using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssWhipSoftware
{
    public class InputEvent
    {
        private InputType type;
        private InputState state;
        private float value;

        public InputType Type
        {
            get { return type; }
        }

        public InputState State
        {
            get { return state; }
        }

        public float Duration
        {
            get { return value; }
        }

        public InputEvent(InputState State, InputType Type, float Value)
        {
            type = Type;
            state = State;
            value = Value;
        }
    }
}
