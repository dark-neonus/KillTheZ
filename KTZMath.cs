using System;
using System.Collections.Generic;

using Vector2 = Vector2Namespace.Vector2;


namespace KTZEngine
{
    static class KTZMath
    {
        public static bool IsInInterval(int num, int start, int stop, bool checkStart = true, bool checkeStop = true) { return (((num > start) && (num < stop)) || ((num == start) && checkStart) || ((num == stop) && checkeStop)); }
        public static bool IsInInterval(Vector2 point, Vector2 start, Vector2 stop, bool checkStart = true, bool checkeStop = true) { return ((IsInInterval(point.x, start.x, stop.x, checkStart, checkeStop) && IsInInterval(point.y, start.y, stop.y, checkStart, checkeStop))); }

        public static bool IsCubeVectorInFieldVector(Vector2 cubeStart, int cubeWidth, int cubeHeight, Vector2 fieldStart, int fieldWidth, int fieldHeight, bool checkStart = true, bool checkeStop = true)
        {
            Vector2 cubeSize = new (cubeWidth, cubeHeight);
            Vector2 fieldSize = new (fieldWidth, fieldHeight);
            if ((IsInInterval(cubeStart, fieldStart, fieldStart + fieldSize - 1)) || (IsInInterval(cubeStart + cubeSize - 1, fieldStart, fieldStart + fieldSize - 1)) || (IsInInterval(cubeStart + cubeSize.x - 1, fieldStart, fieldStart + fieldSize - 1)) || (IsInInterval(cubeStart + cubeSize.y - 1, fieldStart, fieldStart + fieldSize - 1)))
            {
                return true;
            }
            else
            {
                for (int x = 0; x < cubeSize.x; x++)
                {
                    for (int y = 0; y < cubeSize.y; y++)
                    {
                        if (IsInInterval(new Vector2(x, y), fieldStart, fieldStart + fieldSize - 1, checkStart, checkeStop))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        
        public static int LoopNumberInInterval(int num, int start, int end)
        {
            if (start > end) { throw new Exception("Interval length must be greater than zero"); }
            int newNum = num;
            if (newNum > end) { newNum = start; }
            else if (newNum < start) { newNum = end; }
            return newNum;
        }

        public static int CutNumberToInterval(int num, int start, int end)
        {
            if (start > end) { throw new Exception("Interval length must be greater than zero"); }
            return Math.Max(Math.Min(num, end), start);
        }
        public static Vector2 CutNumberToInterval(Vector2 num, Vector2 start, Vector2 end)
        {
            if (start.x > end.x || start.y > end.y) { throw new Exception("Interval length must be greater than zero"); }
            return new Vector2(CutNumberToInterval(num.x, start.x, end.x), CutNumberToInterval(num.y, start.y, end.y));
        }
    }
}
