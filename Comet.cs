using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace GME1011_A3_SimonLopez
{
    internal class Comet
    {
        private Random rng = new Random(); // random numbers
        private int _speed; // the speed of movement
        private float _scale, _angle; // size of the prop, the angle of movement
        private Texture2D _texture; // just a texture
        private int _x, _y; // position
        private int _direction; // where is the comet starting point
        private Vector2 _speedVector; // the speed vector

        //argumented constructor
        public Comet(Texture2D texture, int speed, int direction, float angle, float scale, int sizeX, int sizeY)
        { 
            _texture = texture;
            _direction = direction;
            _speed = speed;
            _scale = scale;
            _angle = angle;
            if (_direction == 0) // this is hard to explain but lets make it simple, 0 = left, 1 = top, 2 = right, 3 = bottom 
            {
                _x = 0;
                _y = rng.Next(0, 800 - (int)(sizeY * _scale));
                if (_angle < 0 )// negative angle
                    _speedVector = new Vector2(_speed * -(_angle / 90), -(_speed * ((90 + _angle) / 90)));
                else if (_angle > 0) // positive angle
                    _speedVector = new Vector2(_speed * (_angle / 90), _speed * ((90 - _angle) / 90));
                else // "90"deg 
                    _speedVector = new Vector2(_speed, 0);
            } 
            else if (_direction == 1) //this is the same as above but ajust to the direction of the movement
            {
                _x = rng.Next(0, 800 - (int)(sizeX * _scale));
                _y = 0;
                if (_angle < 0)
                    _speedVector = new Vector2(_speed * (_angle / 90), _speed * ((90 + _angle) / 90));
                else if (_angle > 0)
                    _speedVector = new Vector2(_speed * (_angle / 90), _speed * ((90 - _angle) / 90));
                else
                    _speedVector = new Vector2(0, _speed);

            } 
            else if (_direction == 2)//this is the same as above but ajust to the direction of the movement
            {
                _x = 800;
                _y = rng.Next(0, (800 - (int)(sizeY * _scale)));
                if (_angle < 0)
                    _speedVector = new Vector2(_speed * (_angle / 90), -(_speed * ((90 + _angle) / 90)));
                else if (_angle > 0)
                    _speedVector = new Vector2(_speed * -(_angle / 90), _speed * ((90 - _angle) / 90));
                else
                    _speedVector = new Vector2(-_speed, 0);
            }
            else // 3 or anything else
            {
                _x = rng.Next(0, 800 - (int)(sizeX * _scale));
                _y = 800;
                if (_angle < 0)
                    _speedVector = new Vector2((_speed * (_angle / 90)), -(_speed * ((90 - _angle) / 90)));
                else if (_angle > 0)
                    _speedVector = new Vector2(_speed * (_angle / 90), -(_speed * ((90 - _angle) / 90)));
                else
                    _speedVector = new Vector2(0, -_speed);
            }
            
        }

        public void Update() 
        {
            // move the comet 
            _x += (int)_speedVector.X;
            _y += (int)_speedVector.Y;
        }

        public bool onScreen() // check if it is on the screen
        {
            if (_x > (800 + (_texture.Width * _scale)) || _y > (800 + (_texture.Height * _scale)) || _x < (0 - (_texture.Width * _scale)) || _y < (0 - (_texture.Height * _scale)))
                return false;
            else return true;
        }

        public void Draw(SpriteBatch spriteBatch) // my small draw method
        {

            spriteBatch.Draw(
                _texture, 
                new Vector2(_x,_y), 
                null, 
                Color.White, 
                0,
                new Vector2((int)(_texture.Width / 2), (int)(_texture.Height / 2)), 
                new Vector2(_scale, _scale),
                SpriteEffects.None,
                0
                );

        }
    }
}
