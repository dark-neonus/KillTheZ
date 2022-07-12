using System;
using System.Collections.Generic;

#nullable enable

namespace Vector2Namespace
{
    public struct Vector2 : IEquatable<Vector2>// , ICollection<Vector2>
    {
        public int x;
        public int y;

        public Vector2 Direction { get { return new Vector2(Math.Sign(x), Math.Sign(y)); } set { x *= Math.Sign(value.x); y *= Math.Sign(value.y); } }

        public int Absolute { get { return (int)Math.Round(Math.Sqrt(x * x + y * y)); } }

        // Constructor
        public Vector2(int X, int Y) { this.x = X; this.y = Y; }
        public Vector2(int XandY) { this.x = XandY; this.y = XandY; }

        public static Vector2 zero = new(0, 0);

        public static Vector2 right = new(1, 0);
        public static Vector2 left = new(-1, 0);
        public static Vector2 up = new(0, 1);
        public static Vector2 down = new(0, -1);

        public static Vector2 upRight = new(1, 1);
        public static Vector2 upLeft = new(-1, 1);
        public static Vector2 downRight = new(1, -1);
        public static Vector2 downLeft = new(-1, -1);

        public static List<Vector2> fourDirections = new()
        {
            right,
            left,
            up,
            down
        };
        public static Dictionary<string, Vector2> namedFourDirections = new()
        {
            { "right", right },
            { "left", left },
            { "up", up },
            { "down", down }
        };

        public static List<Vector2> diagonalDirections = new()
        {
            upRight,
            upLeft,
            downRight,
            downLeft
        };
        public static Dictionary<string, Vector2> namedDiagonalDirections = new()
        {
            { "upRight", upRight },
            { "upLeft", upLeft },
            { "downRight", downRight },
            { "downLeft", downLeft }

        };

        public static List<Vector2> eightDirections = new()
        {
            right,
            left,
            up,
            down,
            upRight,
            upLeft,
            downRight,
            downLeft
        };
        public static Dictionary<string, Vector2> namedEightDirections = new()
        {
            { "right", right },
            { "left", left },
            { "up", up },
            { "down", down },
            { "upRight", upRight },
            { "upLeft", upLeft },
            { "downRight", downRight },
            { "downLeft", downLeft }
        };


        public void RotationToRight90(int times = 1)
        {
            if (times != 0)
            {
                int x_;
                int y_;
                switch (times % 4)
                {
                    case 1:
                        x_ = x;
                        y_ = y;
                        x = y_;
                        y = -x_;
                        break;
                    case 2:
                        x = -x;
                        y = -y;
                        break;
                    case 3:
                        x_ = x;
                        y_ = y;
                        x = -y_;
                        y = x_;
                        break;
                }
            }
        }

        public void RotationToLeft90(int times = 1)
        {
            if (times != 0)
            {
                int x_;
                int y_;
                switch (times % 4)
                {
                    case 3:
                        x_ = x;
                        y_ = y;
                        x = y_;
                        y = -x_;
                        break;
                    case 2:
                        x = -x;
                        y = -y;
                        break;
                    case 1:
                        x_ = x;
                        y_ = y;
                        x = -y_;
                        y = x_;
                        break;
                }
            }
        }

        public static Vector2 GetVectorRotatedRight90(Vector2 vec, int times = 1)
        {
            vec.RotationToRight90(times);
            return vec;
        }

        public static Vector2 GetVectorRotatedLeft90(Vector2 vec, int times = 1)
        {
            vec.RotationToLeft90(times);
            return vec;
        }

        public bool Equals(Vector2 o) => (x == o.x) && (y == o.y);


        public static Vector2 operator +(Vector2 a, Vector2 b) { return new Vector2(a.x + b.x, a.y + b.y); }
        public static Vector2 operator +(Vector2 a, int b) { return new Vector2(a.x + b, a.y + b); }
        public static Vector2 operator -(Vector2 a, Vector2 b) { return new Vector2(a.x - b.x, a.y - b.y); }
        public static Vector2 operator -(Vector2 a, int b) { return new Vector2(a.x - b, a.y - b); }
        public static Vector2 operator *(Vector2 a, int b) { return new Vector2(a.x * b, a.y * b); }

        public static bool operator ==(Vector2 a, Vector2 b) { return (a.x == b.x) && (a.y == b.y); }
        public static bool operator !=(Vector2 a, Vector2 b) { return (a.x != b.x) || (a.y != b.y); }

        public static bool operator <(Vector2 a, Vector2 b) { return (a.x < b.x && a.y < b.y); }
        public static bool operator <(Vector2 a, int b) { return (a.x < b && a.y < b); }
        public static bool operator <(int a, Vector2 b) { return (a < b.x && a < b.y); }
        public static bool operator >(Vector2 a, Vector2 b) { return (a.x > b.x && a.y > b.y); }
        public static bool operator >(Vector2 a, int b) { return (a.x > b && a.y > b); }
        public static bool operator >(int a, Vector2 b) { return (a > b.x && a > b.y); }

        public static Vector2 operator -(Vector2 a) { return new Vector2(-a.x, -a.y); }


    }

}