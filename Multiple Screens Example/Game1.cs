using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Multiple_Screens_Example
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        SpriteFont titleFont;
        Screen currentLevel;    //This is where we will store the current level/screen the game is on.  Set it's initial calue in Initialize()

        // Add as many items to this enumeration as you like.
        enum Screen
        {
            Intro,
            LevelOne,
            End
        }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            currentLevel = Screen.Intro;    // We want to start on the Intro screen

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            titleFont = Content.Load<SpriteFont>("TitleText");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (currentLevel == Screen.Intro)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                { 
                    currentLevel = Screen.LevelOne;     // You would put all logic for the intro screen here.
                }        
            }
            else if (currentLevel == Screen.LevelOne)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    currentLevel = Screen.End;          // You would put all logic for your first level screen here.  You could put it in a separate method and call it from here to reduce the size of your Update() methd
                }
            }
            else if(currentLevel == Screen.End)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    Exit();                            // You would put all logic for the end screen here.
                }
            }


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            if(currentLevel == Screen.Intro)
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(titleFont, "This is the Intro.  Hit ENTER to play!", new Vector2(150, 200), Color.White);
                _spriteBatch.End();
            }
            else if (currentLevel == Screen.LevelOne)   
            {
                _spriteBatch.Begin();   // If you have a lot to draw for Level 1, you may wish to put the code in a separate methd and call it from here instead.
                _spriteBatch.DrawString(titleFont, "LEVEL 1.  Hit SPACE to Win!", new Vector2(150, 200), Color.White);
                _spriteBatch.End();
            }
            else if (currentLevel == Screen.End)
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(titleFont, "Game Over.  Hit ENTER to Quit!", new Vector2(150, 200), Color.White);
                _spriteBatch.End();
            }


            base.Draw(gameTime);
        }
    }
}
