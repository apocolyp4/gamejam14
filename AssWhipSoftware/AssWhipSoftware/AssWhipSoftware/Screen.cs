using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
namespace AssWhipSoftware
{
    public abstract class Screen
    {
        public virtual bool isLive
        {
            get { return true; }
        }
        public abstract void Update();
        public abstract void Draw(); 
    }
}
