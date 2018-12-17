using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace TetrisJFR_GitHub
{
    public class fallingBlock : DrawableGameComponent
    {

        Game1 game;
        SpriteBatch spriteBatch;
        Texture2D droppingBlock;
        static float globalVariable = 380;


        //Location of the block
        // Spawns on top middle -ish
        public float x = 80;
        public float y = 0;

        int blockType = 0;
        int blockColor = 0;

        // Default Constructor
        public fallingBlock(Game1 game) : base(game)
        {
            this.game = game;

        }

        // This constructor used to create different shapes
        public fallingBlock(Game1 game, int _blockType) : base(game)
        {
            this.game = game;
            this.blockType = _blockType;
        }

        // This constructor used to create 1x1 of the desired color from a specific block
        // For example. A blockColor of 3 will result in a yellow 1x1 block

        // This constructor is used in tandem with the delete row.
        // 11/26/18 NOTE TO SELF, REDEFINE _X AND _Y TO BE ROW AND COLUMN
        // TO PREVENT ANY CONFUSION
        public fallingBlock(Game1 game, int _blockColor, int COLUMN, int ROW) : base(game)
        {
            this.game = game;
            this.blockColor = _blockColor;
            this.x = COLUMN;
            this.y = ROW;

            this.blockType = 9000; // blockType not used here, so give it a random value.
        }

        public override void Initialize()
        {
            /* // REMOVING THIS FIXES THE WEIRD PLACEMENT OF BLOCK L ON BOARD
            if (this.blockType == 3)
            {
                this.y = 40; // Set the bottom of the block to be this y coordinate
                // ERROR/ BUG HERE 
            }
            */
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load the texture
            droppingBlock = game.Content.Load<Texture2D>("greyBlock");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            // Creates a 1x1 block
            //  *
            if (blockType == 0)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.MediumPurple);
            }

            //creates shape of 3 blocks looking like
            // * * *
            else if (blockType == 1)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Red);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y), Color.Red);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 40, y), Color.Red);
            }


            // Creates a block looking like this    *
            //                                      *      
            //                                      *

            else if ( blockType == 2)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.IndianRed);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.IndianRed);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 40), Color.IndianRed);
            }
            // Creates a shape with four blocks
            //  *
            //  *
            //  * *
            else if (blockType == 3)
            {


                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Yellow);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.Yellow);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 40), Color.Yellow);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 40), Color.Yellow);

            }
            //Creates a block looking like this
            //      *
            //      * *
            //        *
            else if (blockType == 4)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Green);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.Green);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 20), Color.Green);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 40), Color.Green);
            }

            //Creates a block looking like this
            //  * *
            //  * *
            else if(blockType == 5)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Orange);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y), Color.Orange);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.Orange);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 20), Color.Orange);
            }
            //Creates a block looking like this
            //    * *
            //  * *
            else if(blockType == 6)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y), Color.LightSeaGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 40, y), Color.LightSeaGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 20), Color.LightSeaGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.LightSeaGreen);
            }

            //Creates a block looking like this
            // * *
            //   * *
            else if (blockType == 7)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.LimeGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y), Color.LimeGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 20), Color.LimeGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 40, y + 20), Color.LimeGreen);
            }

            //Creates a block looking like this
            //        *
            //      * *
            //      *
            else if (blockType == 8)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y), Color.YellowGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 20), Color.YellowGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.YellowGreen);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 40), Color.YellowGreen);
            }
            //Creates an upside-down T block looking like this
            //    *
            //  * * *
            else if (blockType == 9)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y), Color.HotPink);
                spriteBatch.Draw(droppingBlock, new Vector2(x, y + 20), Color.HotPink);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 20, y + 20), Color.HotPink);
                spriteBatch.Draw(droppingBlock, new Vector2(x + 40, y + 20), Color.HotPink);

            }
            // Creates the block from the grid itself. (greyBlock) This block is used in tandem
            // with the clearing of the rows
            else if (blockColor == -21)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.White);
            }

            // Creates a MediumPurple block
            else if (blockColor == 0)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.MediumPurple);
            }
            // Creates Red block
            else if (blockColor == 1)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Red);
            }
            //Creates an Indian red block
            else if ( blockColor == 2)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.IndianRed);
            }
            // Creates a Yellow block
            else if (blockColor == 3)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Yellow);
            }
            //Creates a Green block
            else if (blockColor == 4)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Green);
            }

            //Creates an Orange block
            else if (blockColor == 5)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.Orange);
            }

            //Creates Light Sea Green Block
            else if(blockColor == 6)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.LightSeaGreen);
            }
            
            //Creates Lime Green Block
            else if(blockColor == 7)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.LimeGreen);
            }

             // Creates Yellow Green Block
             else if(blockColor == 8)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.YellowGreen);
            }
            else if (blockColor == 9)
            {
                spriteBatch.Draw(droppingBlock, new Vector2(x, y), Color.HotPink);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void changeY()
        {
            this.y = globalVariable;
        }
    }
}
