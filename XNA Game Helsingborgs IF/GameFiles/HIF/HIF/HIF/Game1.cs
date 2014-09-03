using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;
using GifAnimation;


namespace HIF
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //MenuComponent menuComponent;
        //  KeyboardState keyboardState;
        //    KeyboardState oldKeyboardState;
        //    GameScreen activeScreen;
        //    StartScreen startScreen;
            
        //    ActionScreen actionScreen;

        Texture2D background;

        Texture2D may;
        Vector2 mayPosition = Vector2.Zero;

        Texture2D ball;
        Vector2 ballPosition = Vector2.Zero;

        GifAnimation.GifAnimation mayLeft;
        GifAnimation.GifAnimation mayRight;

        Vector2 mayRightPosition = Vector2.Zero;
        Vector2 mayLeftPosition = Vector2.Zero;

        //Texture2D[] blocks = new Texture2D[40];
        //Vector2[] blocksPosition = new Vector2[40];

        Rectangle mainFrame;

        Boolean movingUp;
        //Boolean  movingLeft;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 1680;
            graphics.PreferredBackBufferHeight = 1050;
            //this.graphics.IsFullScreen = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
           // // Create a new SpriteBatch, which can be used to draw textures.
           //  string[] menuItems = { "Start Game", "High Scores", "End Game" };
           // spriteBatch = new SpriteBatch(GraphicsDevice);

          
           //startScreen = new StartScreen(
            
           //    this,
           //     spriteBatch,
           //     Content.Load<SpriteFont>("menufont"),
           //     Content.Load<Texture2D>("ball"));
           //     Components.Add(startScreen);
           //     startScreen.Hide();

           // actionScreen = new ActionScreen(
           // this,
           // spriteBatch,
           // Content.Load<Texture2D>("ball"));
           // Components.Add(actionScreen);
           // actionScreen.Hide();
           // activeScreen = startScreen;
           // activeScreen.Show();



            background = Content.Load<Texture2D>("difHIF");
	 

        	mainFrame = new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height);

            movingUp = true;
            //movingLeft = true;

            may = Content.Load<Texture2D>("mayStatic");
            mayPosition = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - (may.Width / 2), graphics.GraphicsDevice.Viewport.Height - 300);

            ball = Content.Load<Texture2D>("ball");
            ballPosition = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - (ball.Width / 2), graphics.GraphicsDevice.Viewport.Height - 350);

            mayLeft = Content.Load<GifAnimation.GifAnimation>("mayLeft");
            mayLeftPosition = mayPosition;
            mayRight = Content.Load<GifAnimation.GifAnimation>("mayRight");
            mayRightPosition = new Vector2((graphics.GraphicsDevice.Viewport.Width / 2) - (may.Width / 2), graphics.GraphicsDevice.Viewport.Height - 300);

            

            //int bCount = 0;

            //for (int x = 0; x < 8; x++)
            //{
            //    for (int y = 0; y < 5; y++)
            //    {
            //        blocks[bCount] = Content.Load<Texture2D>("block");
            //        blocksPosition[bCount].X = 200 + (x * 45);
            //        blocksPosition[bCount].Y = 15 + (y * 30);
            //        bCount++;
            //    }
            //}
            
            //mayPosition.X = 300;
            //mayPosition.Y = 180;
            

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            //// Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //    this.Exit();

            //keyboardState = Keyboard.GetState();
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            //this.Exit();
            //if (activeScreen == startScreen)
            //{
            //    if (CheckKey(Keys.Enter))
            //    {
            //        if (startScreen.SelectedIndex == 0)
            //        {
            //            activeScreen.Hide();
            //            activeScreen = actionScreen;
            //            activeScreen.Show();
            //        }
            
            //     if (startScreen.SelectedIndex == 1)
            //    {
            //    this.Exit();
            //    }
            //}
            //    }
                




            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left) && mayPosition.X>=0)
            {
                mayPosition.X -= 8;
                mayLeft.Play();
            }

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right) && mayPosition.X <= graphics.GraphicsDevice.Viewport.Width - may.Width)
            {
                mayPosition.X += 8;
                mayRight.Play();
            }

            // EXIT GAME
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            if (movingUp)
            {
                ballPosition.Y -= 7;
            }

            //if (movingLeft)
            //{
            //    ballPosition.X -= 7;
            //}
            if (!movingUp)
            {
                ballPosition.Y += 7;
            }

            //if (!movingLeft)
            //{
            //    ballPosition.X += 7;
            //}

            //if (ballPosition.X <= 0 && movingLeft) movingLeft = false;
            if (ballPosition.Y <= 0 && movingUp) movingUp = false;

            //if (ballPosition.X >= (graphics.GraphicsDevice.Viewport.Width - ball.Width) && !movingLeft) movingLeft = true;

            if (DetectMayBallCollision())
            {
                movingUp = true;
            }


            // TODO: Add your update logic here

            base.Update(gameTime);

            //oldKeyboardState = keyboardState;
        }

        //private bool CheckKey(Keys theKey)
        //{
        //    return keyboardState.IsKeyUp(theKey) &&
        //    oldKeyboardState.IsKeyDown(theKey);
        //}

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Red);

           
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

            spriteBatch.Draw(may, mayPosition, Color.White);
            spriteBatch.Draw(ball, ballPosition, Color.White);
            spriteBatch.Draw(background, mainFrame, Color.White);

            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Left) && mayPosition.X <= graphics.GraphicsDevice.Viewport.Width - may.Width)
            {
                spriteBatch.Draw(mayLeft.GetTexture(), new Vector2(0, 0), Color.White);
            }
            if (Keyboard.GetState(PlayerIndex.One).IsKeyDown(Keys.Right) && mayPosition.X <= graphics.GraphicsDevice.Viewport.Width - may.Width)
            {
                spriteBatch.Draw(mayRight.GetTexture(), new Vector2(0, 0), Color.White);
            }
           

            //for (int blockC = 0; blockC < 40; blockC++)
            //{
            //     spriteBatch.Draw(blocks[blockC], blocksPosition[blockC], Color.White);
            //}

            spriteBatch.End();

           

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public Boolean DetectMayBallCollision()
        {
            if (ballPosition.Y>= mayPosition.Y 
                && (ballPosition.Y + ball.Height) < (mayPosition.Y+150) 
                && ballPosition.X > mayPosition.X 
                && (ballPosition.X < mayPosition.X + may.Width))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
