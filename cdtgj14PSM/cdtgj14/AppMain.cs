using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;

namespace AssWhipSoftware
{
	public class AppMain
	{
		//private static GraphicsContext graphics;
		private static Game1 game = new Game1(); //Your new line
		
		public static void Main (string[] args)
		{
            //Initialize ();
            
            while (true) 
			{
            	game.Run();
                //SystemEvents.CheckEvents ();
                //Update ();
                //Render ();
			}

		}

	}

}
