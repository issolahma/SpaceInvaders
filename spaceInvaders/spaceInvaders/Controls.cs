using System;

namespace spaceInvaders
{
	public class Controls
	{
		public EventHandler upPressed;
		public EventHandler downPressed;
		public EventHandler enterPressed;
		public EventHandler escPressed;
		public EventHandler leftPressed;
		public EventHandler rightPressed;

		public Controls ()
		{
		}

		public void CheckPressedKey ()
		{
			while (true) {
				ConsoleKeyInfo info = Console.ReadKey (true);

				switch (info.Key) {
				case ConsoleKey.UpArrow:
					if (this.upPressed != null)
					{
						this.upPressed(this, new EventArgs());
					}
					break;
				case ConsoleKey.Enter:
					if (this.enterPressed != null)
					{
						this.enterPressed(this, new EventArgs());
					}
					break;
				case ConsoleKey.DownArrow:
					if (this.downPressed != null)
					{
						this.downPressed(this, new EventArgs());
					}
					break;
				case ConsoleKey.LeftArrow:
					if (this.leftPressed != null)
					{
						this.leftPressed(this, new EventArgs());
					}
					break;
				case ConsoleKey.RightArrow:
					if (this.rightPressed != null)
					{
						this.rightPressed(this, new EventArgs());
					}
					break;
				case ConsoleKey.Spacebar:
					//Tir
					break;
				case ConsoleKey.Escape:
					if (this.escPressed != null)
					{
						this.escPressed(this, new EventArgs());
					}
					break;
				default:
					break;
				}
			}
		}
	}
}

