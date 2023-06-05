using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GME1011_A3_SimonLopez
{
    internal class SpaceShip
    {

        private Vector2 _position, _destination;  //vectors  to now where to go, jsut like in the class example :)
        private float _speed;
        private Texture2D _sprite; // textures
        private float _speedX, _speedY;

        //argumented constructor
        public SpaceShip( Vector2 position, float speed, Texture2D sprite)
        {
            _position = position;
            _speed = speed;
            _sprite = sprite;
            _speedX = _speed;
            _speedY = _speed;
        }


        // just like the bounce method but a way simpler
        public void Update()
        {
            if (_position.X < 0 || _position.X > 800 - _sprite.Width)
            {
                _speedX = -_speedX;
            }
            if (_position.Y < 0 || _position.Y > 800 - _sprite.Height)
            {
                _speedY = -_speedY;
            }

            _position.X += _speedX;
            _position.Y += _speedY;
        }

        // my super complex and difficult to understand Draw method
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_sprite, _position, Color.White);
        }
    }


}
