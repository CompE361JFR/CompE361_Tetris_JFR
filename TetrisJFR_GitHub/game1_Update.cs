using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System;

/*
 
    The update function is in charge of making the block fall by using the clock that
    has been initialized from the beginning of the game, as well as to 
    tell the program to make a new block, should the block reach the bottom
    of the board, or if the block comes in contact with another block.

 */

namespace TetrisJFR_GitHub
{
    public partial class Game1 : Game
    {
        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // Activating the handler that handles the keyboard inputs, 
            KeyboardHandler();

            // ERROR: Only occured once. It printed game over when
            // the highest block was on the half way mark

            // Check if the top is filled, If it is, that means one of the
            // blocks on the second row is filled. So end the game.
            if (
                                      (isNextSpotFilled())
                                                  &&
                      (digitalBoard[1, 0] == 1 || digitalBoard[1, 1] == 1 ||
                        digitalBoard[1, 2] == 1 || digitalBoard[1, 3] == 1 ||
                        digitalBoard[1, 4] == 1 || digitalBoard[1, 5] == 1 ||
                        digitalBoard[1, 6] == 1 || digitalBoard[1, 7] == 1 ||
                        digitalBoard[1, 8] == 1 || digitalBoard[1, 9] == 1)

                ) // end of if statement
            {
                gameOver = true;
            }


            if (pauseFlag == 1)
            { }

            else if (gameOver == true)
            {
                // Do nothing, since the game is over. 
                // It prints out a statement, which can be seen in the draw function
            }
            else
            {
                // Increment the timer by 1 second....
                currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;

                // If one second has elapsed, bring the block down
                if (currentTime >= countDuration)
                {

                    counter++; // This may be removed.
                    currentTime = 0; //Restart the timer...

                    // Move the 1x1 block.
                    if (blockType == 0)
                    {


                        currentBlock.y += 20;
                        yBoard += 1;

                        // Used to prevent any out of bounds error with the board array
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // If the block reaches the bottom, place it there,
                        // populate the arrays and generate a new block
                        if (currentBlock.y >= 380)
                        {
                            // Row -> Column notation
                            digitalBoard[yBoard, xBoard] = 1; //Populate the digitalBoard
                            blockColorArray[yBoard, xBoard] = 0; //Populate the blockColorArray

                            // Reset the board coordinates
                            xBoard = 4; // change this for different blocks
                            yBoard = 0;

                            // Used for generating a new block
                            generateNewObject = 1;
                        }

                        else if (isNextSpotFilled())
                        {
                            // Row -> Column notation
                            digitalBoard[yBoard, xBoard] = 1; //Populate the digitalBoard
                            blockColorArray[yBoard, xBoard] = 0; //Populate the blockColorArray

                            // Reset the board coordinates
                            xBoard = 4; // change this for different blocks
                            yBoard = 0;

                            // Used for generating a new block
                            generateNewObject = 1;
                        }

                    } // end of the code used to move the 1x1 block
                    // Move the 1x3 "---" block
                    else if (blockType == 1)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 1;
                            blockColorArray[yBoard2, xBoard2] = 1;
                            blockColorArray[yBoard3, xBoard3] = 1;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 0;
                            yBoard3 = 0;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;

                            blockColorArray[yBoard, xBoard] = 1;
                            blockColorArray[yBoard2, xBoard2] = 1;
                            blockColorArray[yBoard3, xBoard3] = 1;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 0;
                            yBoard3 = 0;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                    }

                    // Move the vertical " - - - " block. 
                    else if (blockType == 2)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;

                        // These if statements are used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        if (yBoard2 == 20)
                        {
                            yBoard--;
                        }

                        if (yBoard3 == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 2;
                            blockColorArray[yBoard2, xBoard2] = 2;
                            blockColorArray[yBoard3, xBoard3] = 2;

                            

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;

                            blockColorArray[yBoard, xBoard] = 2;
                            blockColorArray[yBoard2, xBoard2] = 2;
                            blockColorArray[yBoard3, xBoard3] = 2;

                            

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                    }
                    //Move the "L" block with 4 blocks.
                    else if (blockType == 3)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // If the block reaches the bottom, place it there,
                        // populate the arrays and generate a new block
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 3;
                            blockColorArray[yBoard2, xBoard2] = 3;
                            blockColorArray[yBoard3, xBoard3] = 3;
                            blockColorArray[yBoard4, xBoard4] = 3;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 1;
                            yBoard3 = 2;
                            yBoard4 = 2;

                            xBoard = 4;
                            xBoard2 = 4;
                            xBoard3 = 4;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        // WEIRD ANOMALY< OUT OF RANGE EXCEPTION WHEN GOING TO THE LEFT
                        // OCCURS RANDOMLY AT TIMES, when simultaneously pressing A and P
                        else if (isNextSpotFilled())
                        {
                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 3;
                            blockColorArray[yBoard2, xBoard2] = 3;
                            blockColorArray[yBoard3, xBoard3] = 3;
                            blockColorArray[yBoard4, xBoard4] = 3;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 1;
                            yBoard3 = 2;
                            yBoard4 = 2;

                            xBoard = 4;
                            xBoard2 = 4;
                            xBoard3 = 4;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;
                        }

                    }
                    else if (blockType == 4)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 4;
                            blockColorArray[yBoard2, xBoard2] = 4;
                            blockColorArray[yBoard3, xBoard3] = 4;
                            blockColorArray[yBoard4, xBoard4] = 4;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 1;
                            yBoard3 = 1;
                            yBoard4 = 2;

                            xBoard = 4;
                            xBoard2 = 4;
                            xBoard3 = 5;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            blockColorArray[yBoard, xBoard] = 4;
                            blockColorArray[yBoard2, xBoard2] = 4;
                            blockColorArray[yBoard3, xBoard3] = 4;
                            blockColorArray[yBoard4, xBoard4] = 4;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 1;
                            yBoard3 = 1;
                            yBoard4 = 2;

                            xBoard = 4;
                            xBoard2 = 4;
                            xBoard3 = 5;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }
                    }
                    else if (blockType == 5)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 5;
                            blockColorArray[yBoard2, xBoard2] = 5;
                            blockColorArray[yBoard3, xBoard3] = 5;
                            blockColorArray[yBoard4, xBoard4] = 5;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 0;
                            yBoard3 = 1;
                            yBoard4 = 1;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 4;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            blockColorArray[yBoard, xBoard] = 5;
                            blockColorArray[yBoard2, xBoard2] = 5;
                            blockColorArray[yBoard3, xBoard3] = 5;
                            blockColorArray[yBoard4, xBoard4] = 5;

                            // Reset the board coordinates
                            yBoard = 0;
                            yBoard2 = 0;
                            yBoard3 = 1;
                            yBoard4 = 1;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 4;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }
                    }
                    else if (blockType == 6)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 6;
                            blockColorArray[yBoard2, xBoard2] = 6;
                            blockColorArray[yBoard3, xBoard3] = 6;
                            blockColorArray[yBoard4, xBoard4] = 6;

                            // Reset the board coordinates
                            yBoard = 1;     //Looks like this
                            yBoard2 = 1;    //    * *
                            yBoard3 = 0;    //  * *
                            yBoard4 = 0;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 5;
                            xBoard4 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            blockColorArray[yBoard, xBoard] = 6;
                            blockColorArray[yBoard2, xBoard2] = 6;
                            blockColorArray[yBoard3, xBoard3] = 6;
                            blockColorArray[yBoard4, xBoard4] = 6;

                            //Reset board coordinates
                            yBoard = 1;     //Looks like this
                            yBoard2 = 1;    //    * *
                            yBoard3 = 0;    //  * *
                            yBoard4 = 0;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 5;
                            xBoard4 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }
                    }
                    else if (blockType == 7)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 7;
                            blockColorArray[yBoard2, xBoard2] = 7;
                            blockColorArray[yBoard3, xBoard3] = 7;
                            blockColorArray[yBoard4, xBoard4] = 7;

                            // Reset the board coordinates
                            yBoard = 0;     //Looks like this
                            yBoard2 = 0;    //  * *
                            yBoard3 = 1;    //    * *
                            yBoard4 = 1;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 5;
                            xBoard4 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            blockColorArray[yBoard, xBoard] = 7;
                            blockColorArray[yBoard2, xBoard2] = 7;
                            blockColorArray[yBoard3, xBoard3] = 7;
                            blockColorArray[yBoard4, xBoard4] = 7;

                            // Reset the board coordinates
                            yBoard = 0;     //Looks like this
                            yBoard2 = 0;    //  * *
                            yBoard3 = 1;    //    * *
                            yBoard4 = 1;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 5;
                            xBoard4 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }
                    }
                    else if (blockType == 8)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 8;
                            blockColorArray[yBoard2, xBoard2] = 8;
                            blockColorArray[yBoard3, xBoard3] = 8;
                            blockColorArray[yBoard4, xBoard4] = 8;

                            // Reset the board coordinates
                            //Vertical Z block
                            yBoard = 2;     //Looks like this
                            yBoard2 = 1;    //    *
                            yBoard3 = 1;    //  * *
                            yBoard4 = 0;    //  *

                            xBoard = 4;
                            xBoard2 = 4;
                            xBoard3 = 5;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            blockColorArray[yBoard, xBoard] = 8;
                            blockColorArray[yBoard2, xBoard2] = 8;
                            blockColorArray[yBoard3, xBoard3] = 8;
                            blockColorArray[yBoard4, xBoard4] = 8;

                            //Vertical Z block
                            yBoard = 2;     //Looks like this
                            yBoard2 = 1;    //    *
                            yBoard3 = 1;    //  * *
                            yBoard4 = 0;    //  *

                            xBoard = 4;
                            xBoard2 = 4;
                            xBoard3 = 5;
                            xBoard4 = 5;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }
                    }
                    else if (blockType == 9)
                    {
                        currentBlock.y += 20;

                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;

                        // This if statement used to prevent any out-of-bounds errors
                        if (yBoard == 20)
                        {
                            yBoard--;
                        }

                        // if you reach the bottom, stop here and change the board array
                        if (currentBlock.y >= 380)
                        {

                            // Row -> Column notation //

                            //Populate the digitalBoard
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            //Populate the blockColorArray
                            blockColorArray[yBoard, xBoard] = 9;
                            blockColorArray[yBoard2, xBoard2] = 9;
                            blockColorArray[yBoard3, xBoard3] = 9;
                            blockColorArray[yBoard4, xBoard4] = 9;

                            // Reset the board coordinates
                            //Upside down T
                            yBoard = 1;     //Looks like this
                            yBoard2 = 1;    //   *
                            yBoard3 = 0;    // * * *
                            yBoard4 = 1;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 5;
                            xBoard4 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }

                        else if (isNextSpotFilled())
                        {
                            digitalBoard[yBoard, xBoard] = 1;
                            digitalBoard[yBoard2, xBoard2] = 1;
                            digitalBoard[yBoard3, xBoard3] = 1;
                            digitalBoard[yBoard4, xBoard4] = 1;

                            blockColorArray[yBoard, xBoard] = 9;
                            blockColorArray[yBoard2, xBoard2] = 9;
                            blockColorArray[yBoard3, xBoard3] = 9;
                            blockColorArray[yBoard4, xBoard4] = 9;

                            //Upside down T
                            yBoard = 1;     //Looks like this
                            yBoard2 = 1;    //   *
                            yBoard3 = 0;    // * * *
                            yBoard4 = 1;

                            xBoard = 4;
                            xBoard2 = 5;
                            xBoard3 = 5;
                            xBoard4 = 6;

                            // Used for generating a new block
                            generateNewObject = 1;

                        }
                    }

                }
                // Checking if the user fills the board up to the top row.
                // If true, the game is over, so stop the game and print
                // "Game Over"
                if (digitalBoard[0, 0] == 1 || digitalBoard[0, 1] == 1 ||
                        digitalBoard[0, 2] == 1 || digitalBoard[0, 3] == 1 ||
                        digitalBoard[0, 4] == 1 || digitalBoard[0, 5] == 1 ||
                        digitalBoard[0, 6] == 1 || digitalBoard[0, 7] == 1 ||
                        digitalBoard[0, 8] == 1 || digitalBoard[0, 9] == 1)
                {
                    gameOver = true;
                }
                base.Update(gameTime);
            }
        } // End of the Update function
    }
}
