using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssWhipSoftware
{
    class Player : GameObject
    {

        public void updatePlayerControls()
        {
            if (InputHandler.NextEvent != null)
            {
                if (InputHandler.NextEvent.State == InputState.LEFT)
                {
                    InputHandler.RemoveEvent(InputHandler.NextEvent);
                }
                else
                {
                    InputHandler.RemoveEvent(InputHandler.NextEvent);
                }
            }
        }

        public void updatePlayer()
        {
            updatePlayerControls();
        }
    }
}
