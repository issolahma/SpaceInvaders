﻿using System;

namespace spaceInvaders
{
	public class Ship:ShipMasterClass
	{

		public Ship(int lives, int xPos, int yPos, string skin, bool isAlive):base(lives, xPos, yPos, skin, isAlive)
		{

		}

		public void SpawnPlayer()
		{
			Console.SetCursorPosition(xPos, yPos);
			Console.WriteLine(skin);
		}

		public void KeyListener(Controls ctrl)
		{
			ctrl.leftPressed += MoveLeft;
			ctrl.rightPressed += MoveRight;
			//ctrl.spacePressed += Fire;
		}

		public void MoveLeft(object sender, EventArgs e)
		{
			MoveLeft ();
		}

		public void MoveRight(object sender, EventArgs e)
		{
			MoveRight ();
		}
	}
}
