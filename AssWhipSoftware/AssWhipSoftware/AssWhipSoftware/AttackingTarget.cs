using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware.Backend.Back_head
{
    public class AttackingTarget :  EnemyAI
    {
        public override void Update(Enemies Enemy)
        {
            //attack player
        }

        public override EnemyAI onExit()
        {
            //if player out of range, return new SeenTarget()
            return this;
        }
    }
}
