//https://www.youtube.com/watch?v=jQgwEsJISy0

using System;

namespace spaceInvaders
{
	public class Controls
	{
		public event EventHandler upPressed;
		public event EventHandler downPressed;
		public event EventHandler enterPressed;
		public event EventHandler escPressed;
		public event EventHandler leftPressed;
		public event EventHandler rightPressed;
        public event EventHandler spacePressed;
        
        public Controls ()
		{
          
		}

        public void RunCheckKeys ()
        {
            OnPressedKey();
        }

		protected virtual void OnPressedKey ()
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

