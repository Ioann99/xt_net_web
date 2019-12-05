using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7.Game
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Game
    {

    }

    public class Level
    {
        public Level()
        {
            _bonusCounter = 10;
        }

        private byte _bonusCounter;

        public static int BonusCounter { get; set; }
    }

    class Field
    {
        private int _width;
        private int _height;

        public int Width { get; set; }
        public int Height { get; set; }

        //графичсекое оформление поля
    }

    abstract class Bonus
    {
        public abstract void DoEffect();
    }

    class Apple : Bonus
    {
        private int _position_X;
        private int _position_Y;

        public int Position_X { get; set; }
        public int Position_Y { get; set; }

        public override void DoEffect()
        {
            if (Level.BonusCounter == 0)
            {
                //level complited
                //exit level
            }

            Level.BonusCounter--;

            Player.Move_speed += 5;
        }
    }

    class Cherry : Bonus
    {
        private int _position_X;
        private int _position_Y;

        public override void DoEffect()
        {
            if (Level.BonusCounter == 0)
            {
                //level complited
                //exit level
            }

            Level.BonusCounter--;

            Player.Health += 10;
        }
    }

    class Entity
    {

    }

    class LiveEntity : Entity
    {

    }

    class Player : LiveEntity
    {
        private int _position_X;
        private int _position_Y;
        private byte _move_speed;
        private string _direction;
        private byte _health;
        private bool IsBonusEnabled;

        public static int Position_X { get; set; }
        public static int Position_Y { get; set; }
        public static int Move_speed { get; set; }
        public static int Health { get; set; }

        //метод проверки наличия препятсвия впереди
    }

    abstract class Enemy : LiveEntity
    {
        abstract public void Attack();
    }

    class Wolf : Enemy
    {
        private int _position_X;
        private int _position_Y;
        private byte _move_speed;
        private string _direction;
        private byte _health;
        private byte _attack_power;

        public static int Position_X { get; set; }
        public static int Position_Y { get; set; }
        public static byte AttackPower { get; set; }

        override public void Attack()
        {
            if (Wolf.Position_X == Player.Position_X && Wolf.Position_Y == Player.Position_Y)
            {
                Player.Health -= Wolf.AttackPower;

                if (Player.Health <= 0)
                {
                    //game over
                }

                //анимация атаки
            }
        }
        //метод проверки наличия препятсвия впереди
    }

    class Bear : Enemy
    {
        private int _position_X;
        private int _position_Y;
        private byte _move_speed;
        private string _direction;
        private byte _health;
        private byte _attack_power;

        public static int Position_X { get; set; }
        public static int Position_Y { get; set; }
        public static byte AttackPower { get; set; }

        public override void Attack()
        {
            if (Bear.Position_X == Player.Position_X && Bear.Position_Y == Player.Position_Y)
            {
                Player.Health -= Bear.AttackPower;

                //анимация атаки

                if (Player.Health <= 0)
                {
                    //game over
                }
            }
        }
        //метод проверки наличия препятсвия впереди
    }

    class InanimateEnity : Entity
    {

    }

    class Obstacle : InanimateEnity
    {

    }

    class Tree : Obstacle
    {
        private int _position_X;
        private int _position_Y;

        public int Position_X { get; set; }
        public int Position_Y { get; set; }
    }

    class Rock : Obstacle
    {
        private int _position_X;
        private int _position_Y;

        public int Position_X { get; set; }
        public int Position_Y { get; set; }
    }
}
