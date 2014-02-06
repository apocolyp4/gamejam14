using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace AssWhipSoftware
{
    class Animation
    {
        private List<Texture2D> frames = new List<Texture2D>();
        private int timer;
        private int count;
        private int pos;
        private bool loop;
        private bool finished;

        public Animation()
        {
            timer = 0;
            count = 0;
            pos = 0;
        }

        public void addFrame(string frameName)
        {
            frames.Add(Settings.Content.Load<Texture2D>(frameName));
        }

        public int Timer
        {
            get { return timer; }
            set { timer = value; }
        }

        public void start()
        {
            pos = 0;
            finished = false;
        }

        public int Count
        {
            get { return count; }
            set { count = value; }
        }

        public int Pos
        {
            get { return pos; }
            set { pos = value; }
        }

        public Texture2D Frame
        {
            get { return frames[pos]; }
        }

        public bool Loop
        {
            get { return loop; }
            set { loop = value; }
        }

        public bool Finished
        {
            get { return finished; }
            set { finished = value; }
        }

        public void update()
        {
            count += 1;
            if (count > timer)
            {
                pos += 1;
                count = 0;
            }

            if (pos > frames.Count - 1)
            {
                if (loop)
                {
                    pos = 0;
                }
                else
                {
                    pos = frames.Count - 1;
                    finished = true;
                }
            }
            Console.WriteLine(pos);
        }

    }
}
