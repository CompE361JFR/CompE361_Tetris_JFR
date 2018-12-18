using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System;


/*
 
    The LoadContent.cs function includes MonoGame's Loadcontent function
    This functions loads all the images that we used in our game,
    such as the blocks that were used to make the playing field, the tetris shapes, and
    all the text fonts and logos that were used within the game

 */
namespace TetrisJFR_GitHub
{
    public partial class Game1 : Game
    {
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the texture for the playing field
            blockForGrid = Content.Load<Texture2D>("greyBlock");

            // Load the texture for the Tetris Logo
            tetrisLogo = Content.Load<Texture2D>("tetrisLogoRed");

            // Load the spriteFont for the score
            scoreText = Content.Load<SpriteFont>("score");

            // Load the texture for the background menu
            startGameSplash = Content.Load<Texture2D>("start-splash");

            // Load the texture for the block that is falling.  
            // Note to self - this is done in the fallingBlock.cs file
            base.LoadContent();

            // TODO: use this.Content to load your game content here
        }
    }
}
