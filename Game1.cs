/*
 * Simon Lopez Jarmillo
 * A00279010
 * GME1011 A3
 */

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace GME1011_A3_SimonLopez
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private Random _rng; // Random number generator
        private SpriteBatch _spriteBatch;
        private Texture2D _background; // bg for the scene
        private List<Comet> _comets; // Create a list of comets
        private List<SpaceShip> _spaceShips; // list of space ships
        private Texture2D[] _spaceShipTextures; // array of diferent space ships textures
        private SpriteFont _font; // just a simple font
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            // ------------------------ //

            _graphics.PreferredBackBufferWidth = 800;   // change dimensions
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();

            // ------------------------ //

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // ------------------------ //

            _comets = new List<Comet>();
            _spaceShips = new List<SpaceShip>();
            _spaceShipTextures = new Texture2D[5];
            _rng = new Random();

            // ------------------------ //
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // ------------------------ //

            // load all the sapceships textures
            _spaceShipTextures[0] = Content.Load<Texture2D>("Ship_1");
            _spaceShipTextures[1] = Content.Load<Texture2D>("Ship_2");
            _spaceShipTextures[2] = Content.Load<Texture2D>("Ship_3");
            _spaceShipTextures[3] = Content.Load<Texture2D>("Ship_4");
            _spaceShipTextures[4] = Content.Load<Texture2D>("Ship_5");

            _font = Content.Load<SpriteFont>("GameFont");
            
            // create the basic comets in the scene
            for (int i = 0; i < 15; i++)
            {      
                Comet temp = new Comet(Content.Load<Texture2D>("comet"), _rng.Next(2, 6), _rng.Next(0, 4), _rng.Next(-70, 71), 0.15f, 371, 291);
                _comets.Add(temp);
            }
            // Create the SpaceShips
            for (int i = 0; i < 8;i++) {

                SpaceShip temp = new SpaceShip(new Vector2(_rng.Next(100,700), _rng.Next(100, 700)), _rng.Next(2, 10), _spaceShipTextures[_rng.Next(0,5)]);
                _spaceShips.Add(temp);
            }

            //_test = new Comet(Content.Load<Texture2D>("comet"), 3, 3,-50f, .3f, 371, 291);
            _background = Content.Load<Texture2D>("nightskycolor");
            
            // ------------------------ //
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ------------------------ //

            // add comets if the user press space
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                _comets.Add(new Comet(Content.Load<Texture2D>("comet"), _rng.Next(2, 6), _rng.Next(0, 4), _rng.Next(-70, 71), 0.15f, 371, 291));
            }
            // update and delete comets
            for (int i = 0; i < _comets.Count; i++)
            {
                _comets[i].Update();
                if (!_comets[i].onScreen()) { // delete if the comets are out of the screen
                    _comets.RemoveAt(i);
                    //_comets[i] = new Comet(Content.Load<Texture2D>("comet"), _rng.Next(2, 6), _rng.Next(0, 4), _rng.Next(-70, 71), 0.2f, 371, 291);
                }
            }

            // update the SpaceShips
            for (int i = 0; i < _spaceShips.Count; i++)
            {
                _spaceShips[i].Update();
            }

            // ------------------------ //

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black); // bg in black as vlad soul

            // ------------------------ //
            _spriteBatch.Begin();
            _spriteBatch.Draw(_background, new Rectangle(0, 0, 800, 800), Color.White); // draw the background
            

            foreach (Comet comet in _comets) { // draw the comets
                comet.Draw(_spriteBatch);
            }


            foreach (SpaceShip ship in _spaceShips) // draw the SpaceShips
            {
                ship.Draw(_spriteBatch);
            }

            _spriteBatch.DrawString(_font, "Press space to create more comets", new Vector2(150, 760), Color.White); // tell the player how to add comets 

            _spriteBatch.End();

            // ------------------------ //

            base.Draw(gameTime);
        }
    }
}