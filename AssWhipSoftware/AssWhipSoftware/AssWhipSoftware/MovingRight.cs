using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware.Backend.Back_head
{
    public class MovingRight : EnemyAI
    {
        bool isAtEdge = false;
        public override void Update(Enemies Enemy)
        {
            // Move the Enemy, however the GameObject class handles that.
            // Check for edge.
            // Check for player within range. If player is near, store player as the Target game object in Enemy.
        }

        public override EnemyAI onExit()
        {
            // if enemy has a target, return new SeenTarget.
            if (isAtEdge)
                return new MovingLeft();
            return this;
        }
    }
}
