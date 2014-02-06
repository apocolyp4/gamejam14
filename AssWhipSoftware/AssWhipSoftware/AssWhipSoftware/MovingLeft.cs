using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware.Backend.Back_head
{
    public class MovingLeft : EnemyAI
    {
        bool isAtEdge = false;
        public override void Update(Enemies Enemy)
        {
            // Move the Enemy, however the GameObject class handles that.
            // Check for edge.
        }

        public override EnemyAI onExit()
        {
            if (isAtEdge)
                return new MovingRight();
            return this;
        }
    }
}
