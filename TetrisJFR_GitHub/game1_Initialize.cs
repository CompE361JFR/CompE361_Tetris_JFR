using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System;

namespace TetrisJFR_GitHub
{
    public partial class Game1 : Game
    {
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Creates the size for our "game window" //
            graphics.PreferredBackBufferHeight = 500;
            graphics.PreferredBackBufferWidth = 500;
            graphics.ApplyChanges();

            // Makes the mouse visible to the user.
            this.IsMouseVisible = true;

            // Generate the blockType using a randomNumberGenerator
            blockType = randomNumberGenerator();

            // Create the block that will be falling
            currentBlock = new fallingBlock(this, blockType);
            Components.Add(currentBlock); // add it to the Game1 object.

            // POTENTIAL ERROR HERE: Once we add more blocks, these xBoard and yBoard
            // coordinates might overlap write over each other, causing weird
            // out of bound exceptions.

            // ERROR - you get a out of bound exception of the "L" block is the block
            // that spawns first. This could be because it's coordinates are overwritten
            // by the 1x3 "---" block. This can be seen below. 


            if (blockType == 0)
            {
                // 1x1 Block // BlockType = 0 // 
                yBoard = 0;          // Looks like this
                xBoard = 4;          // *
            }
            else if (blockType == 1)
            {
                // 1x3 "---" Block // BlockType = 1 //
                yBoard = 0;
                yBoard2 = 0;        // Looks like this
                yBoard3 = 0;        // * * *

                xBoard = 4;
                xBoard2 = 5;
                xBoard3 = 6;

            }
            else if (blockType == 2)
            {
                // 3x1 block, the vertical version of " - - - " Block // BlockType = 2 //
                yBoard = 0;
                yBoard2 = 1;
                yBoard3 = 2;

                xBoard = 4;
                xBoard2 = 4;
                xBoard3 = 4;
            }
            else if (blockType == 3)
            {
                // 3x2 "L" Block // BlockType = 3 // 
                yBoard = 0;
                yBoard2 = 1;         // Looks like this
                yBoard3 = 2;         // *
                yBoard4 = 2;         // *
                                     // * *
                xBoard = 4;
                xBoard2 = 4;
                xBoard3 = 4;
                xBoard4 = 5;
            }
            else if (blockType == 4)
            {
                //Vertical Z block
                yBoard = 0;     //Looks like this
                yBoard2 = 1;    //  *
                yBoard3 = 1;    //  * *
                yBoard4 = 2;    //    *

                xBoard = 4;
                xBoard2 = 4;
                xBoard3 = 5;
                xBoard4 = 5;
            }
            else if (blockType == 5)
            {
                yBoard = 0;     //Looks like this
                yBoard2 = 0;    //  * *
                yBoard3 = 1;    //  * *
                yBoard4 = 1;

                xBoard = 4;
                xBoard2 = 5;
                xBoard3 = 4;
                xBoard4 = 5;
            }



            base.Initialize();


        }
    }
}
