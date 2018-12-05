using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;
using System;

// This comment is to test the Commit /sync functions of the GitHub extension
// on Visual Studio. -- Raven Tomas
//test on this file - Fate - test again

//Test of the commit/sync function. - Jayson Del Moral

namespace TetrisJFR_GitHub
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>

    /*
        -This class is controls the creation of the board, and the movement of
        the falling Block.

        -It also contains the code necessary to handle the keyboard inputs

         
       - When deleting blocks or clearing rows, have an array that has all the characteritics
        -of the block, so you can bring it down later using the draw function


        ------------------------------------------------------
        NOTE TO SELF: maybe create a updateArray() function, 
        which updates the contents of the array, instead of doing it for each blockType.
        This will prevent the programmer from typing repetitive code
        ------------------------------------------------------
         
    */

    public partial class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Texture for the playing grid
        Texture2D blockForGrid;

        // Object for the falling block that spawns
        fallingBlock currentBlock;

        // Object used to clear rows, by creating blocks that come from the playing grid
        // By doing so, it gives the illusion that the row has been cleared
        fallingBlock deleteBlock;

        // Object used to bring a block down, if the row has been cleared
        fallingBlock bringDownBlock;

        // Texture for the Tetris Logo
        Texture2D tetrisLogo;

        // Creating text for the score
        SpriteFont scoreText;

        // Used when handling Keyboard Inputs
        private KeyboardState oldState;

        //Pause flag initialization:
        int pauseFlag = 0;

        // Initializing our timer
        // Source used to create timer:
        // https://stackoverflow.com/questions/13394892/how-to-create-a-timer-counter-in-c-sharp-xna
        int counter = 0;
        float countDuration = 1; // one second
        float currentTime = 0;

        int score = 100;

        /*
            When deleting blocks or clearing rows, have an array that has all the characteritics
            of the block, so you can bring it down later using the draw function
         
        */

        int xBoard;
        int yBoard;

        // Multiple variable instances used to track the coordinates of different objects
        // on the board, since they all have different sizes.  
        int xBoard2;
        int xBoard3;
        int xBoard4;

        int yBoard2;
        int yBoard3;
        int yBoard4;


        int blockType = 3; // initialize the first object to spawn for testing purposes






        // 20 rows, 10 columns
        int[,] digitalBoard = new int[20, 10]
        {                  //x <-- start here
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        int[,] blockColorArray = new int[20, 10]
        {
            // -21 represends a grey "grid" block
                                     //x <-- start here
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //1
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //2
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //3
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //4
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //5
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //6
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //7
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //8
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //9
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 },//10
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //11
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //12
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 },//13
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //14
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //15
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //16
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //17
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //18
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 }, //19
                {-21, -21, -21, -21, -21, -21, -21, -21, -21, -21 },  //20th row
        };



        int[,] locationYArray = new int[20, 10]
        {                  //x <-- start here
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                {20, 20, 20, 20, 20, 20, 20, 20, 20, 20 },
                {40, 40, 40, 40, 40, 40, 40, 40, 40, 40 },
                {60, 60, 60, 60, 60, 60, 60, 60, 60, 60 },
                {80, 80, 80, 80, 80, 80, 80, 80, 80, 80 },
                {100, 100, 100, 100, 100, 100, 100, 100, 100, 100 },
                {120, 120, 120, 120, 120, 120, 120, 120, 120, 120 },
                {140, 140, 140, 140, 140, 140, 140, 140, 140, 140 },
                {160, 160, 160, 160, 160, 160, 160, 160, 160, 160 },
                {180, 180, 180, 180, 180, 180, 180, 180, 180, 180 },
                {200, 200, 200, 200, 200, 200, 200, 200, 200, 200 },
                {220, 220, 220, 220, 220, 220, 220, 220, 220, 220 },
                {240, 240, 240, 240, 240, 240, 240, 240, 240, 240 },
                {260, 260, 260, 260, 260, 260, 260, 260, 260, 260 },
                {280, 280, 280, 280, 280, 280, 280, 280, 280, 280 },
                {300, 300, 300, 300, 300, 300, 300, 300, 300, 300 },
                {320, 320, 320, 320, 320, 320, 320, 320, 320, 320 },
                {340, 340, 340, 340, 340, 340, 340, 340, 340, 340 },
                {360, 360, 360, 360, 360, 360, 360, 360, 360, 360 },
                {380, 380, 380, 380, 380, 380, 380, 380, 380, 380 }
        };

        int[,] locationXArray = new int[20, 10]
        {                  //x <-- start here
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 },
                {0, 20, 40, 60, 80, 100, 120, 140, 160, 180 }
        };

        int generateNewObject = 0;

        bool gameOver = false; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        
        

        //  Initialize() was here before

        

        // LoadContent() was here before.

        

        // UnloadContent() was here before

        


        // Update() was here before.

        

        // Draw() was here before. 

        void KeyboardHandler()
        {
            KeyboardState newState = Keyboard.GetState();
            //bool leftArrowKeyDown = state.IsKeyDown(Keys.Left);

            if (oldState.IsKeyUp(Keys.M) && newState.IsKeyDown(Keys.M))
            {
                pauseFlag ^= 1;
            }

            // Move Left
            if (oldState.IsKeyUp(Keys.A) && newState.IsKeyDown(Keys.A))
            {
                if (blockType == 0 && pauseFlag == 0)
                {
                    if (currentBlock.x - 20 <= -1)
                    {
                        // Dont move the object left, since its out of the grid
                    }

                    else
                    {
                        currentBlock.x -= 20;
                        xBoard -= 1;
                    }
                }

                else if (blockType == 3 && pauseFlag == 0)
                {
                    if (currentBlock.x - 20 <= -1)
                    {
                        // Dont move the object to the left, since its out of the grid
                    }
                    else
                    {
                        currentBlock.x -= 20;
                        xBoard -= 1;
                        xBoard2 -= 1;
                        xBoard3 -= 1;
                        xBoard4 -= 1;
                    }
                }

                else if (blockType == 1 && pauseFlag == 0)
                {
                    if (currentBlock.x - 20 <= -1)
                    {
                        // Dont move the object to the left, since its out of the grid
                    }
                    else
                    {
                        currentBlock.x -= 20;
                        xBoard -= 1;
                        xBoard2 -= 1;
                        xBoard3 -= 1;
                    }
                }
            }


            // Move Right
            else if (oldState.IsKeyUp(Keys.D) && newState.IsKeyDown(Keys.D))
            {
                if (blockType == 0 && pauseFlag == 0)
                {
                    if (xBoard + 1 >= 10)
                    {
                        // Dont move the object to the right, since its out of the grid
                    }

                    else
                    {
                        currentBlock.x += 20;
                        xBoard += 1;
                    }
                }

                else if (blockType == 3 && pauseFlag == 0)
                {
                    if (xBoard + 2 >= 10)
                    {
                        // Dont move the object to the right, since its out of the grid
                    }
                    else
                    {
                        currentBlock.x += 20;
                        xBoard += 1;
                        xBoard2 += 1;
                        xBoard3 += 1;
                        xBoard4 += 1;
                    }
                }

                else if (blockType == 1 && pauseFlag == 0)
                {
                    if (xBoard + 3 >= 10)
                    {
                        // Dont move the object to the right, since its out of the grid
                    }
                    else
                    {
                        currentBlock.x += 20;
                        xBoard += 1;
                        xBoard2 += 1;
                        xBoard3 += 1;
                    }
                }
            }

            else if (oldState.IsKeyUp(Keys.P) && newState.IsKeyDown(Keys.P))
            {

                if (blockType == 0 && pauseFlag == 0)
                {
                    // currentBlock.changeY();
                    if (isNextSpotFilled() || currentBlock.y + 40 >= 380)
                    { }
                    else
                    {
                        currentBlock.y += 20;
                        yBoard += 1;
                    }
                }

                else if (blockType == 3 && pauseFlag == 0)
                {
                    if (isNextSpotFilled() || currentBlock.y + 60 >= 380)
                    { }
                    else
                    {
                        currentBlock.y += 20;
                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                        yBoard4 += 1;
                    }
                }

                else if (blockType == 1 && pauseFlag == 0)
                {
                    if (isNextSpotFilled() || currentBlock.y + 40 >= 380)
                    { }
                    else
                    {
                        currentBlock.y += 20;
                        yBoard += 1;
                        yBoard2 += 1;
                        yBoard3 += 1;
                    }
                }

            }

            oldState = newState;


        } // end of keyboardhandler

        bool isNextSpotFilled()
        {
            try
            {
                if (blockType == 0)
                {
                    if (currentBlock.y >= 380)
                    {
                        return false;
                    }

                    // Row -> column notation //
                    else if (digitalBoard[yBoard + 1, xBoard] == 0)
                    {
                        return false;
                    }

                    else if (digitalBoard[yBoard + 1, xBoard] == 1)
                    {
                        return true;
                    }
                }

                else if (blockType == 3)
                {
                    if (currentBlock.y >= 380)
                    {
                        return false;
                    }


                    // Row -> column notation
                    else if (digitalBoard[yBoard + 1, xBoard] == 0
                        && digitalBoard[yBoard2 + 1, xBoard2] == 0
                        && digitalBoard[yBoard3 + 1, xBoard3] == 0
                        && digitalBoard[yBoard4 + 1, xBoard4] == 0)
                    {
                        return false;
                    }

                    else if (digitalBoard[yBoard + 1, xBoard] == 1
                        || digitalBoard[yBoard2 + 1, xBoard2] == 1
                        || digitalBoard[yBoard3 + 1, xBoard3] == 1
                        || digitalBoard[yBoard4 + 1, xBoard4] == 1)
                    {
                        return true;
                    }
                }

                else if (blockType == 1)
                {
                    if (currentBlock.y >= 380)
                    {
                        return false;
                    }
                    // Row -> column notation
                    else if (digitalBoard[yBoard + 1, xBoard] == 0
                        && digitalBoard[yBoard2 + 1, xBoard2] == 0
                        && digitalBoard[yBoard3 + 1, xBoard3] == 0)
                    {
                        return false;
                    }

                    else if (digitalBoard[yBoard + 1, xBoard] == 1
                        || digitalBoard[yBoard2 + 1, xBoard2] == 1
                        || digitalBoard[yBoard3 + 1, xBoard3] == 1)
                    {
                        return true;
                    }
                }
            }

            catch
            {
                // throw away the exception and continue playing. 
            }


            return true;
        }


        int randomNumberGenerator()
        {
            /*
                
            From the Microsoft Documentation:
            The following example calls the Next(Int32, Int32) method to
            generate 10 random numbers between -10 and 10. Note that the second
            argument to the method specifies the exclusive upper bound of the 
            range of random values returned by the method. In other words, the largest integer 
            that the method can return is one less than this value.

            Therefore, to randomly generate a number between 0 and 3, it must be
            called like this:
            randomNumber = RNG.Next(0, 4);

             
            */
            Random RNG = new Random();
            int randomNumber = RNG.Next(0, 3);

            while (randomNumber != 0 && randomNumber != 3 && randomNumber != 1)
            {
                randomNumber = RNG.Next(0, 4);
            }

            return randomNumber;
        }


    }
}
