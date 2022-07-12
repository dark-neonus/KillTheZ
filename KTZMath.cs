using System;
using System.Collections.Generic;

using Vector2 = Vector2Namespace.Vector2;


namespace KTZEngine
{
    ////─────────────────────────────────────────────────────────────────class KZMath─────────────────────────────────────────────────────────────────|
    static class KTZMath
    {

        //────────────────────────────────────────────IsInInterval────────────────────────────────────────────|
        /// <summary>
        /// Returns the value of whether there is a number in the interval
        /// </summary>
        /// <param name="num">Number that being checked is belong to interval</param>
        /// <param name="start">Start interval value</param>
        /// <param name="stop">Stop interval value</param>
        /// <param name="checkStart">What return if number = start of interval</param>
        /// <param name="checkeStop">What return if number = stop of interval</param>
        /// <returns></returns>
        public static bool IsInInterval(int num, int start, int stop, bool checkStart = true, bool checkeStop = true) { return (((num > start) && (num < stop)) || ((num == start) && checkStart) || ((num == stop) && checkeStop)); }
        /// <summary>
        /// Returns the value of whether there is a number in the interval
        /// </summary>
        /// <param name="num">Number that being checked is belong to interval</param>
        /// <param name="start">Start interval value</param>
        /// <param name="stop">Stop interval value</param>
        /// <param name="checkStart">What return if number = start of interval</param>
        /// <param name="checkeStop">What return if number = stop of interval</param>
        /// <returns></returns>
        public static bool IsInInterval(float num, float start, float stop, bool checkStart = true, bool checkeStop = true) { return (((num > start) && (num < stop)) || ((num == start) && checkStart) || ((num == stop) && checkeStop)); }
        /// <summary>
        /// Returns the value of whether there is a Vector2 point is in box place between start vector and stop vector
        /// </summary>
        /// <param name="point">Vector that being checked is belong to interval</param>
        /// <param name="start">Start interval value</param>
        /// <param name="stop">Stop interval value</param>
        /// <param name="checkStart">What return if point = start of interval</param>
        /// <param name="checkeStop">What return if point = stop of interval</param>
        /// <returns></returns>
        public static bool IsInInterval(Vector2 point, Vector2 start, Vector2 stop, bool checkStart = true, bool checkeStop = true) { return ((IsInInterval(point.x, start.x, stop.x, checkStart, checkeStop) && IsInInterval(point.y, start.y, stop.y, checkStart, checkeStop))); }

        //────────────────────────────────────────────IsCubeVectorInCubeVector────────────────────────────────────────────|
        public static bool IsCubeVectorInFieldVector(Vector2 cubeStart, Vector2 cubeSize, Vector2 fieldStart, Vector2 fieldSize, bool checkStart = true, bool checkeStop = true)
        {
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
        public static bool IsCubeVectorInFieldVector(Vector2 cubeStart, int cubeWidth, int cubeHeight, Vector2 fieldStart, int fieldWidth, int fieldHeight, bool checkStart = true, bool checkeStop = true)
        {
            Vector2 cubeSize = new Vector2(cubeWidth, cubeHeight);
            Vector2 fieldSize = new Vector2(fieldWidth, fieldHeight);
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
        public static bool IsCubeVectorInFieldVector(Vector2 cubeStart, Vector2 cubeSize, Vector2 fieldStart, int fieldWidth, int fieldHeight, bool checkStart = true, bool checkeStop = true)
        {
            Vector2 fieldSize = new Vector2(fieldWidth, fieldHeight);
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
        public static bool IsCubeVectorInFieldVector(Vector2 cubeStart, int cubeWidth, int cubeSizeY, Vector2 fieldStart, Vector2 fieldSize, bool checkStart = true, bool checkeStop = true)
        {
            Vector2 cubeSize = new Vector2(cubeWidth, cubeSizeY);
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

        //────────────────────────────────────────────GetMaxStringLengthInList────────────────────────────────────────────|
        public static int GetMaxStringLengthInList(List<string> list)
        {
            int maxLenth = 0;
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Length > maxLenth) { maxLenth = list[i].Length; }
                }
            }
            return maxLenth;
        }

        //────────────────────────────────────────────LoopNumberInInterval────────────────────────────────────────────|
        public static int LoopNumberInInterval(int num, int start, int end)
        {
            if (start > end) { throw new Exception("Interval length must be greater than zero"); }
            int newNum = num;
            if (newNum > end) { newNum = start; }
            else if (newNum < start) { newNum = end; }
            return newNum;
        }
        public static float LoopNumberInInterval(float num, float start, float end)
        {
            if (start > end) { throw new Exception("Interval length must be greater than zero"); }
            float newNum = num;
            if (newNum > end) { newNum = start; }
            else if (newNum < start) { newNum = end; }
            return newNum;
        }

        //────────────────────────────────────────────CutNumberToInterval────────────────────────────────────────────|
        public static int CutNumberToInterval(int num, int start, int end)
        {
            if (start > end) { throw new Exception("Interval length must be greater than zero"); }
            return Math.Max(Math.Min(num, end), start);
        }
        public static float CutNumberToInterval(float num, float start, float end)
        {
            if (start > end) { throw new Exception("Interval length must be greater than zero"); }
            return Math.Max(Math.Min(num, end), start);
        }
        public static Vector2 CutNumberToInterval(Vector2 num, Vector2 start, Vector2 end)
        {
            if (start.x > end.x || start.y > end.y) { throw new Exception("Interval length must be greater than zero"); }
            return new Vector2(CutNumberToInterval(num.x, start.x, end.x), CutNumberToInterval(num.y, start.y, end.y));
        }

        //────────────────────────────────────────────GetCurrentNumberPersent────────────────────────────────────────────|
        public static int GetCurrentNumberPersent(int num, int measureNum, int start = 0, int end = 100, bool absolute = false, bool cutToMax = true, bool cutToMin = true)
        {
            if (start >= end) { throw new Exception("Interval length must be greater than zero"); }
            if (absolute) { int change = Math.Abs(Math.Min(0, start)); start = 0; end = Math.Abs(end) + change; num = Math.Abs(num); }
            int percents = (int)Math.Round((float)(num / measureNum * (end - start)));


            if (percents < start && cutToMin) { percents = start; }
            if (percents > end && cutToMax) { percents = end; }


            return percents;
        }
        public static float GetCurrentNumberPersent(float num, float measureNum, float start = 0, float end = 100, bool absolute = false, bool cutToMax = true, bool cutToMin = true)
        {
            if (start >= end) { throw new Exception("Interval length must be greater than zero"); }
            if (absolute) { float change = Math.Abs(Math.Min(0, start)); start = 0; end = Math.Abs(end) + change; }
            float percents = (float)Math.Round((float)(num / measureNum * (end - start)));


            if (percents < start && cutToMin) { percents = start; }
            if (percents > end && cutToMax) { percents = end; }


            return percents;
        }

        //────────────────────────────────────────────GetFloatNuberPersentes────────────────────────────────────────────|
        public static float GetFloatNuberPersentes(int num, int measureNum, bool absolute = true)
        {
            return GetCurrentNumberPersent(num, measureNum, 0, 100, absolute) / 100;
        }
        public static float GetFloatNuberPersentes(float num, float measureNum, bool absolute = true)
        {
            return GetCurrentNumberPersent(num, measureNum, 0, 100, absolute) / 100;
        }
    }
}
