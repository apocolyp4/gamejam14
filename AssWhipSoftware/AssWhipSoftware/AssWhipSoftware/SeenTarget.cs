using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware.Backend.Back_head
{
    public class SeenTarget : EnemyAI
    {
        public override void Update(Enemies Enemy)
        {
            //Obtain target information from enemy.
            //Move towards target.
        }

        public override EnemyAI onExit()
        {
            //if within a certain distance of the enemy it may attack.
            return this;
        }
    }
}
