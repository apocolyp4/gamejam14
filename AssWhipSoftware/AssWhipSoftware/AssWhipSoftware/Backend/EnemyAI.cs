using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssWhipSoftware.Backend
{
    public abstract class EnemyAI
    {
        public abstract void Update(Enemies Enemy);
        public abstract EnemyAI onExit();
    }
}
