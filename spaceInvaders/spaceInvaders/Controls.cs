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
        public EventHandler spacePressed;

        public Controls ()
		{
		}

		public void CheckPressedKey ()
		{
			while (true) {
				ConsoleKeyInfo info = Console.ReadKey (true);

				switch (info.Key) {
				case ConsoleKey.UpArrow:
                        upPressed?.Invoke(this, new EventArgs());
                        break;
				case ConsoleKey.Enter:
                        enterPressed?.Invoke(this, new EventArgs());
                        break;
				case ConsoleKey.DownArrow:
                        downPressed?.Invoke(this, new EventArgs());
                        break;
				case ConsoleKey.LeftArrow:
                        leftPressed?.Invoke(this, new EventArgs());
                        break;
				case ConsoleKey.RightArrow:
                        rightPressed?.Invoke(this, new EventArgs());
                        break;
				case ConsoleKey.Spacebar:
                        spacePressed?.Invoke(this, new EventArgs());
                        break;
				case ConsoleKey.Escape:
                        escPressed?.Invoke(this, new EventArgs());
                        break;
				default:
					break;
				}
			}
		}
	}
}

