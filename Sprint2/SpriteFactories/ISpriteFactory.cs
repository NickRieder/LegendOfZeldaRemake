using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Sprint2
{

	public interface ISpriteFactory
	{
		void LoadSpriteSheet(ContentManager content);
	}
}
