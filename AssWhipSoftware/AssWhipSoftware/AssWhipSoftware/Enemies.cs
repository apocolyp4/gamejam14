using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AssWhipSoftware.Backend;

namespace AssWhipSoftware
{
    public class Enemies : GameObject
    {
        private int health = 2;
        private GameObject target;
        private EnemyAI AI;
        public int Health
        {
            get { return health; }
        }
        public GameObject Target
        {
            get { return target; }
            set { target = value; }
        }
        public Enemies(Texture2D Texture, int Health)
        {
            AI = new Backend.Back_head.MovingLeft();
        }
        public void Update()
        {
            AI.Update(this);
            AI = AI.onExit();
        }
        public void AttackTarget()
        {
            
            //at behest of designer. Something that can be done with less people, potentially.
            // ^-- I can't remember what this was for.
        }
    }
}
