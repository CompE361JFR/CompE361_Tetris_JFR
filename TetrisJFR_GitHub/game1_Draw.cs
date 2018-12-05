using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System;

namespace TetrisJFR_GitHub
{
    public partial class Game1: Game
    {
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            if (pauseFlag == 1)
            { }
            else
            {
                GraphicsDevice.Clear(Color.CornflowerBlue);

                // TODO: Add your drawing code here
                spriteBatch.Begin();


                // Using two nested for loops allows us to create our 20 x 10 block grid.
                // 20 x 10 = 20 rows and 10 columns
                // Rows
                for (int j = 0; j <= 19; j++)
                {
                    // Columns
                    for (int i = 0; i <= 9; i++)
                    {
                        spriteBatch.Draw(blockForGrid, new Vector2((i * 20), (j * 20)), Color.White);
                    }
                }

                // Draw the logo
                spriteBatch.Draw(tetrisLogo, new Vector2(250, 10), Color.White);

                // Draw the Score
                spriteBatch.DrawString(scoreText, score.ToString(), new Vector2(300, 100), Color.Black);

                // Game Over text that spawns
                if (gameOver == true)
                {
                    spriteBatch.DrawString(scoreText, "GAME OVER", new Vector2(280, 150), Color.Red);
                }


                ///////////////////////////////////////////////////////////////////////
                // Checking if a row has been completed, if it has, increment the score
                // and bring every block down. 
                ///////////////////////////////////////////////////////////////////////
                ///

                /* 
                // Note, merge this with other statement OR DELETE IT
                if (digitalBoard[19, 0] == 1 && digitalBoard[19, 1] == 1 &&
                    digitalBoard[19, 2] == 1 && digitalBoard[19, 3] == 1 &&
                    digitalBoard[19, 4] == 1 && digitalBoard[19, 5] == 1 &&
                    digitalBoard[19, 6] == 1 && digitalBoard[19, 7] == 1 &&
                    digitalBoard[19, 8] == 1 && digitalBoard[19, 9] == 1)
                {
                    score += 100;

                }
                */
                spriteBatch.End();



                spriteBatch.Begin();

                for (int f = 19; f > 0; f--)
                {

                    // Check if a row is filled. If a row is filled, delete the row
                    // increment your score and bring every block down. 
                    if (digitalBoard[f, 0] == 1 && digitalBoard[f, 1] == 1 &&
                        digitalBoard[f, 2] == 1 && digitalBoard[f, 3] == 1 &&
                        digitalBoard[f, 4] == 1 && digitalBoard[f, 5] == 1 &&
                        digitalBoard[f, 6] == 1 && digitalBoard[f, 7] == 1 &&
                        digitalBoard[f, 8] == 1 && digitalBoard[f, 9] == 1)
                    {

                        // Bring blocks down from every row of the playing grid
                        for (int row = f; row > 0; row--)
                        {
                            // int row = 19; // DELETE ME LATER PLEASE

                            // For loop used to delete the nth row that is FILLED. 
                            for (int i = 0; i < 10; i++)
                            {
                                // Arrays follow the _array[row,column] notation
                                // Constructor follows this _fallingBlock(this, blockColor, column, row)
                                deleteBlock = new fallingBlock(this, -21, locationXArray[row, i], locationYArray[row, i]); // ERROROROROR HEREEEEE 380!!!!!!! I FIXED IT!!!! 12/1/18 4:24 PM
                                Components.Add(deleteBlock);
                                digitalBoard[row, i] = 0; // Reset that spot back to 0, indicating no 
                                                          // block has been placed
                                blockColorArray[row, i] = -21;
                            }

                            // Now drop the (n-1)th row down and repopulate the digitalBoard
                            // after dropping the row, make row (n-1) clear for now

                            for (int i = 0; i < 10; i++) // handles the columns
                            {
                                // Dropping row
                                bringDownBlock = new fallingBlock(this, blockColorArray[row - 1, i],
                                    locationXArray[row, i], locationYArray[row, i]);
                                blockColorArray[row, i] = blockColorArray[row - 1, i];
                                Components.Add(bringDownBlock);

                                // Resetting the contents of the row that was dropped down
                                digitalBoard[row - 1, i] = 0; // Reset that spot back to 0
                                blockColorArray[row - 1, i] = -21;

                                // Clear the dropped row
                                // Arrays follow the _array[row,column] notation
                                deleteBlock = new fallingBlock(this, -21, locationXArray[row - 1, i], locationYArray[row - 1, i]);
                                Components.Add(deleteBlock);
                                digitalBoard[row - 1, i] = 0; // Reset that spot back to 0, indicating no 
                                                              // block has been placed

                                // Repopulating the digitalBoard
                                if (blockColorArray[row, i] == 0 || blockColorArray[row, i] == 3 || blockColorArray[row, i] == 1)
                                {
                                    digitalBoard[row, i] = 1;
                                }


                            }


                            score += 1; // 

                        }

                        score += 1;
                        score += 100;
                        // Should increment score by 120. This can be changed if we
                        // want to increment it by a different score. 
                        break;

                    } // end of the " if f " statement

                } // end of " for f " loop

                spriteBatch.End();

                // Generates a new block after placing the current Block. 
                // This is drawn last so that it draws over other objects, so it
                // can be seen and not hide under other blocks.
                spriteBatch.Begin();

                if (generateNewObject == 1)
                {
                    // Create a new block
                    blockType = randomNumberGenerator();

                    currentBlock = new fallingBlock(this, blockType);
                    Components.Add(currentBlock); // add it to the Game1 object
                    generateNewObject = 0;

                    // Restarting the coordinates of the randomly generate shape

                    // Reset coordinates to match 1x1 shape 
                    if (blockType == 0)
                    {
                        xBoard = 4; // change this for different blocks
                        yBoard = 0;
                    }

                    // Reset coordinates to match 1x3  "- - -" shape
                    else if (blockType == 1)
                    {
                        yBoard = 0;
                        yBoard2 = 0;
                        yBoard3 = 0;

                        xBoard = 4;
                        xBoard2 = 5;
                        xBoard3 = 6;
                    }

                    // Reset coordinates to match 3x2 "L" shape
                    else if (blockType == 3)
                    {
                        yBoard = 0;
                        yBoard2 = 1;
                        yBoard3 = 2;
                        yBoard4 = 2;

                        xBoard = 4;
                        xBoard2 = 4;
                        xBoard3 = 4;
                        xBoard4 = 5;
                    }


                }

                spriteBatch.End();


                base.Draw(gameTime);
            }
        }
    }
}
