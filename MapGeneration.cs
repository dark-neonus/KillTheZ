using System;
using System.Collections.Generic;
using System.Linq;

using Vector2 = Vector2Namespace.Vector2;

namespace KTZEngine
{
    public class KTZMapsGeneration
    {
        public static int[,] mediumBoxKnot = new int[5, 5] {
            { 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0 }, };
        public static int[,] smallBoxKnot = new int[3, 3] {
            { 0, 0, 0 },
            { 0, 1, 0 },
            { 0, 0, 0 }, };
        public static int[,] bigBoxKnot = new int[7, 7] {
            { 0, 0, 0, 0, 0, 0, 0 },
            { 0, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 0 },
            { 0, 1, 1, 1, 1, 1, 0 },
            { 0, 0, 0, 0, 0, 0, 0 }, };
        public static int zoneHeight = 6;
        public static int cityZoneHeight = 3;
        public static int centralStreetOffset = 7;
        public static int smallSideStreetDiagonalCoef = 3;
        public static Dictionary<Vector2, int> aloneWallVectorStructure = new() { { Vector2.zero, 1 }, { Vector2.up, 0 }, { Vector2.right, 0 }, { Vector2.down, 0 }, { Vector2.left, 0 } };

        public static Dictionary<Vector2, int> leftUpCornerVectorStructure = new() { { Vector2.zero, 0 }, { Vector2.up, 1 }, { Vector2.left, 1 }, { Vector2.down, 0 }, { Vector2.right, 0 }, };
        public static Dictionary<Vector2, int> leftDownCornerVectorStructure = new() { { Vector2.zero, 0 }, { Vector2.down, 1 }, { Vector2.left, 1 }, { Vector2.up, 0 }, { Vector2.right, 0 }, };
        public static Dictionary<Vector2, int> rightUpCornerVectorStructure = new() { { Vector2.zero, 0 }, { Vector2.up, 1 }, { Vector2.right, 1 }, { Vector2.down, 0 }, { Vector2.left, 0 }, };
        public static Dictionary<Vector2, int> rightDownCornerVectorStructure = new() { { Vector2.zero, 0 }, { Vector2.down, 1 }, { Vector2.right, 1 }, { Vector2.up, 0 }, { Vector2.left, 0 }, };

        public static List<int> allUsageNums = new() { 0, 1, 2, 3, 4 };

        public static int[,] UkrainCityMapGeneration(int[,] virtualMap, List<string> cityNames, int currCityIndex)
        {
            Vector2 virtualMapSize = new(virtualMap.GetLength(0), virtualMap.GetLength(1));


            DrawRectOnVirtualMap(virtualMap, new Vector2(1, virtualMapSize.y - 1 - zoneHeight), new Vector2(virtualMapSize.x - 1, zoneHeight), 0);
            DrawRectOnVirtualMap(virtualMap, new Vector2(1), new Vector2(virtualMapSize.x - 2, zoneHeight), 0);

            for (int i = 0; i < 2; i++)
            {
                RunSmallWormInVirtualMap(virtualMap, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), virtualMapSize.y - zoneHeight), Vector2.upRight, virtualMapSize - 1, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), zoneHeight), allUsageNums, 0, randomChanceGo: -100);
            }
            for (int i = 0; i < 5; i++)
            {
                RunMediumWormInVirtualMap(virtualMap, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), virtualMapSize.y - zoneHeight), Vector2.upRight, virtualMapSize - 1, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), zoneHeight), allUsageNums, 0, randomChanceGo: -100);
            }
            for (int i = 0; i < 3; i++)
            {
                RunBigWormInVirtualMap(virtualMap, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), virtualMapSize.y - zoneHeight), Vector2.upRight, virtualMapSize - 1, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), zoneHeight), allUsageNums, 0, randomChanceGo: -100);
            }

            for (int i = -1; i <= 1; i += 2)
            {
                Vector2 startPos;
                Vector2 targetPos;
                if (Convert.ToBoolean(KTZEngineAplication.random.Next(2)))
                {
                    startPos = new Vector2(2, (int)(virtualMapSize.y / 2) + i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                    targetPos = new Vector2(virtualMapSize.x - 1, (int)(virtualMapSize.y / 2) - i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                }
                else
                {
                    startPos = new Vector2(virtualMapSize.x - 1, (int)(virtualMapSize.y / 2) - i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                    targetPos = new Vector2(2, (int)(virtualMapSize.y / 2) + i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                }

                RunBigWormInVirtualMap(
                    virtualMap,
                    startPos,
                    Vector2.upRight,
                    virtualMapSize - 1,
                    targetPos,
                    allUsageNums,
                    0,
                    randomChanceGo: -100
                    );
            }
            for (int i = 0; i < 3; i++)
            {
                Vector2 startPos;
                Vector2 targetPos;
                if (Convert.ToBoolean(KTZEngineAplication.random.Next(2)))
                {
                    startPos = new(2, KTZEngineAplication.random.Next(zoneHeight + 1, virtualMapSize.y - zoneHeight - 1));
                    targetPos = new(virtualMapSize.x - 1, startPos.y + KTZEngineAplication.random.Next(-smallSideStreetDiagonalCoef, smallSideStreetDiagonalCoef));
                }
                else
                {
                    startPos = new(virtualMapSize.x - 1, KTZEngineAplication.random.Next(zoneHeight + 1, virtualMapSize.y - zoneHeight - 1));
                    targetPos = new(2, startPos.y + KTZEngineAplication.random.Next(-smallSideStreetDiagonalCoef, smallSideStreetDiagonalCoef));
                }


                RunSmallWormInVirtualMap(
                    virtualMap,
                    startPos,
                    Vector2.upRight,
                    virtualMapSize - 1,
                    targetPos,
                    new List<int>() { 0, 1 },
                    0,
                    randomChanceGo: -100
                    );
            }


            for (int i = 0; i < 13; i++) { CreateStructureHard(virtualMap, mediumBoxKnot, new Vector2(KTZEngineAplication.random.Next(mediumBoxKnot.GetLength(0), virtualMapSize.x - mediumBoxKnot.GetLength(0)), KTZEngineAplication.random.Next(mediumBoxKnot.GetLength(1) + zoneHeight, virtualMapSize.y - mediumBoxKnot.GetLength(1) - zoneHeight))); }
            for (int i = 0; i < 10; i++) { CreateStructureHard(virtualMap, smallBoxKnot, new Vector2(KTZEngineAplication.random.Next(smallBoxKnot.GetLength(0), virtualMapSize.x - smallBoxKnot.GetLength(0)), KTZEngineAplication.random.Next(smallBoxKnot.GetLength(1) + zoneHeight, virtualMapSize.y - smallBoxKnot.GetLength(1) - zoneHeight))); }

            for (int i = 0; i < 3; i++) { CreateStructureHard(virtualMap, bigBoxKnot, new Vector2(KTZEngineAplication.random.Next(bigBoxKnot.GetLength(0), virtualMapSize.x - bigBoxKnot.GetLength(0)), KTZEngineAplication.random.Next(bigBoxKnot.GetLength(1) + zoneHeight, virtualMapSize.y - bigBoxKnot.GetLength(1) - zoneHeight))); }

            VectorsClearStructureOnVirtualMap(virtualMap, aloneWallVectorStructure, 0, new Vector2(0, zoneHeight), virtualMapSize - new Vector2(0, zoneHeight));


            // Create zones
            DrawRectOnVirtualMap(virtualMap, new Vector2(1, virtualMapSize.y - 1 - cityZoneHeight), new Vector2(virtualMapSize.x - 1, cityZoneHeight), 2);
            DrawRectOnVirtualMap(virtualMap, new Vector2(1), new Vector2(virtualMapSize.x - 2, cityZoneHeight), 2);

            BombHoleGenerate(virtualMap, 4);

            CityNameBoxGeneration(virtualMap, new Vector2((int)Math.Round((double)((virtualMapSize.x - cityNames[currCityIndex + 1].Length) / 2)), virtualMapSize.y - (cityZoneHeight + 2)), cityNames[currCityIndex + 1]);
            CityNameBoxGeneration(virtualMap, new Vector2((int)Math.Round((double)((virtualMapSize.x - cityNames[currCityIndex].Length) / 2)), cityZoneHeight + 3), cityNames[currCityIndex]);



            virtualMap = OptimizationOfWalls(virtualMap, 1, 3);


            return virtualMap;
        }

        public static int[,] ShitrussiaCityMapGeneration(int[,] virtualMap, List<string> cityNames, int currCityIndex)
        {

            Vector2 virtualMapSize = new(virtualMap.GetLength(0), virtualMap.GetLength(1));

            DrawRectOnVirtualMap(virtualMap, new Vector2(1, virtualMapSize.y - 1 - zoneHeight), new Vector2(virtualMapSize.x - 1, zoneHeight), 0);
            DrawRectOnVirtualMap(virtualMap, new Vector2(1), new Vector2(virtualMapSize.x - 2, zoneHeight), 0);

            ChaoticGeneration(virtualMap);

            // for (int i = 0; i < 3; i++) { RunSmallWormInVirtualMap(virtualMap, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), virtualMapSize.y - zoneHeight), Vector2.upRight, virtualMapSize - 1, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), zoneHeight), allUsageNums, 0, randomChanceGo: -100); }
            for (int i = 0; i < 5; i++) { RunMediumWormInVirtualMap(virtualMap, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), virtualMapSize.y - zoneHeight), Vector2.upRight, virtualMapSize - 1, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), zoneHeight), allUsageNums, 0, randomChanceGo: -100); }
            // for (int i = 0; i < 3; i++) { RunBigWormInVirtualMap(virtualMap, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), virtualMapSize.y - zoneHeight), Vector2.upRight, virtualMapSize - 1, new Vector2(KTZEngineAplication.random.Next(0, virtualMapSize.x), zoneHeight), allUsageNums, 0, randomChanceGo: -100); }

            for (int i = -1; i <= 1; i += 2)
            {
                Vector2 startPos;
                Vector2 targetPos;
                if (Convert.ToBoolean(KTZEngineAplication.random.Next(2)))
                {
                    startPos = new Vector2(2, (int)(virtualMapSize.y / 2) + i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                    targetPos = new Vector2(virtualMapSize.x - 1, (int)(virtualMapSize.y / 2) - i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                }
                else
                {
                    startPos = new Vector2(virtualMapSize.x - 1, (int)(virtualMapSize.y / 2) - i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                    targetPos = new Vector2(2, (int)(virtualMapSize.y / 2) + i * KTZEngineAplication.random.Next(0, centralStreetOffset));
                }

                RunBigWormInVirtualMap(
                    virtualMap,
                    startPos,
                    Vector2.upRight,
                    virtualMapSize - 1,
                    targetPos,
                    allUsageNums,
                    0,
                    randomChanceGo: -100
                    );
            }
            for (int i = 0; i < 3; i++)
            {
                Vector2 startPos;
                Vector2 targetPos;
                if (Convert.ToBoolean(KTZEngineAplication.random.Next(2)))
                {
                    startPos = new(2, KTZEngineAplication.random.Next(zoneHeight + 1, virtualMapSize.y - zoneHeight - 1));
                    targetPos = new(virtualMapSize.x - 1, startPos.y + KTZEngineAplication.random.Next(-smallSideStreetDiagonalCoef, smallSideStreetDiagonalCoef));
                }
                else
                {
                    startPos = new(virtualMapSize.x - 1, KTZEngineAplication.random.Next(zoneHeight + 1, virtualMapSize.y - zoneHeight - 1));
                    targetPos = new(2, startPos.y + KTZEngineAplication.random.Next(-smallSideStreetDiagonalCoef, smallSideStreetDiagonalCoef));
                }


                RunSmallWormInVirtualMap(
                    virtualMap,
                    startPos,
                    Vector2.upRight,
                    virtualMapSize - 1,
                    targetPos,
                    new List<int>() { 0, 1 },
                    0,
                    randomChanceGo: -100
                    );
            }


            DrawRectOnVirtualMap(virtualMap, new Vector2(1, virtualMapSize.y - 1 - cityZoneHeight), new Vector2(virtualMapSize.x - 1, cityZoneHeight), 2);
            DrawRectOnVirtualMap(virtualMap, new Vector2(1), new Vector2(virtualMapSize.x - 2, cityZoneHeight), 2);

            CityNameBoxGeneration(virtualMap, new Vector2((int)Math.Round((double)((virtualMapSize.x - cityNames[currCityIndex + 1].Length) / 2)), virtualMapSize.y - (cityZoneHeight + 2)), cityNames[currCityIndex + 1]);
            CityNameBoxGeneration(virtualMap, new Vector2((int)Math.Round((double)((virtualMapSize.x - cityNames[currCityIndex].Length) / 2)), cityZoneHeight + 3), cityNames[currCityIndex]);

            virtualMap = OptimizationOfWalls(virtualMap, 1, 3);

            return virtualMap;
        }

        public static int[,] ChaoticGeneration(int[,] virtualMap, int eggsCount = 1000, int growTimes = 2, int fullNum = 1)
        {
            Vector2 virtualMapSize = new(virtualMap.GetLength(0), virtualMap.GetLength(1));
            Vector2 pos;
            int chance;

            for (int i = 0; i < eggsCount; i++)
            {
                virtualMap[KTZEngineAplication.random.Next(1, virtualMapSize.x - 1), KTZEngineAplication.random.Next(zoneHeight, virtualMapSize.y - zoneHeight)] = 1;
            }

            for (int i = 0; i < growTimes; i++)
            {
                for (int x = 1; x < virtualMapSize.x - 1; x++)
                {
                    for (int y = 1; y < virtualMapSize.y - 1; y++)
                    {
                        pos = new Vector2(x, y);
                        chance = 1;
                        for (int q = 0; q < Vector2.eightDirections.Count; q++)
                        {
                            if (virtualMap[x + Vector2.eightDirections[q].x, y + Vector2.eightDirections[q].y] == fullNum) { chance += 4; }
                        }

                        if (KTZEngineAplication.random.Next(chance) > 4) { virtualMap[x, y] = fullNum; }
                    }
                }

            }

            return virtualMap;
        }
        public static int[,] CreateStructureHard(int[,] virtualMap, int[,] structure, Vector2 position)
        {
            Vector2 mapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            // Vector2 structureSize = new Vector2(structure.GetLength(0), structure.GetLength(1));
            if (KTZMath.IsInInterval(position, Vector2.zero, mapSize))
            {
                for (int x = 0; x < structure.GetLength(0); x++)
                {
                    for (int y = 0; y < structure.GetLength(1); y++)
                    {
                        if (KTZMath.IsInInterval(new Vector2(x + position.x, y + position.y), Vector2.zero, mapSize)) { virtualMap[x + position.x, y + position.y] = structure[x, y]; }
                    }
                }
            }
            return virtualMap;
        }

        public static bool CreateStructureOnlyIfAllNotEmptyEqual(ref int[,] virtualMap, int[,] structure, Vector2 position, List<int> structEmptyNums, List<int> allowZoneNums)
        {
            int[,] basicVirtualMap = VirtualMapCopy(virtualMap);
            Vector2 mapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            if (KTZMath.IsInInterval(position, Vector2.zero, mapSize))
            {
                for (int x = 0; x < structure.GetLength(0); x++)
                {
                    for (int y = 0; y < structure.GetLength(1); y++)
                    {
                        if (KTZMath.IsInInterval(new Vector2(x + position.x, y + position.y), Vector2.zero, mapSize) && allowZoneNums.Contains(virtualMap[x + position.x, y + position.y]))
                        {
                            if (structEmptyNums.Contains(structure[x, y])) { continue; }
                            else { virtualMap[x + position.x, y + position.y] = structure[x, y]; }
                        }

                        else { virtualMap = basicVirtualMap; return false; }
                    }
                }
            }
            return true;
        }

        public static int[,] VirtualMapCopy(int[,] virtualMapBase)
        {
            {
                int[,] newVirtualMap = CreateVirtualMap(virtualMapBase.GetLength(0), virtualMapBase.GetLength(1));

                for (int x = 0; x < virtualMapBase.GetLength(0); x++)
                {
                    for (var y = 0; y < virtualMapBase.GetLength(1); y++)
                    {
                        newVirtualMap[x, y] = virtualMapBase[x, y];
                    }
                }

                return newVirtualMap;
            }
        }

        public static int[,] GenerateMapByReference(Dictionary<int, StaticGameObject> objects, int[,] virtualMap)
        {
            GameLayer layer;
            for (int i = 0; i < objects.Count; i++)
            {
                layer = objects.Values.ElementAt(i).layer;
                for (int x = 0; x < layer.layerWidth; x++)
                {
                    for (int y = 0; y < layer.layerHeight; y++)
                    {
                        if (virtualMap[x, y] == objects.Keys.ElementAt(i)) { layer.AddExistStaticObject(objects.Values.ElementAt(i), new Vector2(x, y)); }
                    }
                }
            }

            return virtualMap;
        }

        public static int[,] CreateVirtualMap(int width, int height, int fillValue = 0)
        {
            int[,] virtualMap = new int[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    virtualMap[x, y] = fillValue;
                }
            }
            return virtualMap;
        }

        public static int[,] EdgeGeneration(int[,] virtualMap)
        {
            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            for (int x = 0; x < virtualMap.GetLength(0); x++)
            {
                virtualMap[x, 0] = 1;
                virtualMap[x, virtualMapSize.y] = 1;
            }
            for (int y = 1/*ignore corners*/; y < virtualMap.GetLength(1) - 1/*ignore corners*/; y++)
            {
                virtualMap[0, y] = 1;
                virtualMap[virtualMapSize.x, y] = 1;
            }
            return virtualMap;
        }

        public static int[,] DrawRectOnVirtualMap(int[,] virtualMap, Vector2 start, Vector2 size, int fillValue)
        {
            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            for (int x = 0; x < size.x; x++)
            {
                if (KTZMath.IsInInterval(x + start.x, 0, virtualMapSize.x))
                {
                    for (int y = 0; y < size.y; y++)
                    {
                        if (KTZMath.IsInInterval(y + start.y, 0, virtualMapSize.y)) { virtualMap[x + start.x, y + start.y] = fillValue; }
                    }
                }
            }

            return virtualMap;
        }

        public static int[,] RunSmallWormInVirtualMap(int[,] virtualMap, Vector2 start, Vector2 fieldStart, Vector2 fieldEnd, Vector2 target, List<int> allowedNums, int traceNum, int minRoadLength = 1, int maxRoadLength = 10, int xChanceGo = 30, int yChanceGo = 30, int randomChanceGo = -10, int liveTime = -1)
        {
            if (liveTime <= 0) { liveTime = virtualMap.Length; }

            int[,] path = CreateVirtualMap(virtualMap.GetLength(0), virtualMap.GetLength(1), 0);
            path[fieldStart.x, fieldStart.y] = traceNum;

            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            Vector2 pos = start;
            Vector2 targetDir = (target - pos).Direction;
            Vector2 moveDir = targetDir;
            Vector2 newPos;

            bool isInTarget = false;
            int action;

            for (int cycle = 0; cycle < liveTime && !isInTarget; cycle++)
            {
                action = KTZEngineAplication.random.Next(Math.Max(xChanceGo + yChanceGo + randomChanceGo + (target - pos).Absolute, xChanceGo + yChanceGo));
                targetDir = (target - pos).Direction;
                if (action < xChanceGo) { moveDir = new Vector2(0, targetDir.y); }
                else if (action >= xChanceGo && action < yChanceGo + xChanceGo) { moveDir = new Vector2(targetDir.x, 0); }
                else if (action >= yChanceGo + xChanceGo && action < randomChanceGo + yChanceGo + xChanceGo + (target - pos).Absolute) { moveDir = Vector2.fourDirections[KTZEngineAplication.random.Next(Vector2.fourDirections.Count)]; }

                for (int i = 0; i < KTZEngineAplication.random.Next(minRoadLength, maxRoadLength) && !isInTarget; i++)
                {
                    newPos = KTZMath.CutNumberToInterval(KTZMath.CutNumberToInterval(pos + moveDir, Vector2.zero, virtualMapSize), fieldStart, fieldEnd);
                    if (allowedNums.Contains(virtualMap[newPos.x, newPos.y]))
                    {
                        pos = newPos;
                        path[pos.x, pos.y] = 1;
                        isInTarget = (pos == target) ? true : false;
                    }
                }

            }

            if (isInTarget)
            {
                for (int x = 0; x < path.GetLength(0); x++)
                {
                    for (int y = 0; y < path.GetLength(1); y++)
                    {
                        if (path[x, y] == 1) { virtualMap[x, y] = traceNum; }
                    }
                }
            }

            return virtualMap;
        }
        public static int[,] RunMediumWormInVirtualMap(int[,] virtualMap, Vector2 start, Vector2 fieldStart, Vector2 fieldEnd, Vector2 target, List<int> allowedNums, int traceNum, int minRoadLength = 1, int maxRoadLength = 10, int xChanceGo = 30, int yChanceGo = 30, int randomChanceGo = -10, int liveTime = -1)
        {
            if (liveTime <= 0) { liveTime = virtualMap.Length; }

            int[,] path = CreateVirtualMap(virtualMap.GetLength(0), virtualMap.GetLength(1), 0);
            path[fieldStart.x, fieldStart.y] = traceNum;

            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            Vector2 pos = start;
            Vector2 targetDir = new(Math.Sign(target.x - pos.x), Math.Sign(target.y - pos.y));
            Vector2 moveDir = targetDir;
            Vector2 newPos;
            Vector2 drawTilePos;
            Vector2[] sideGoDirs = new Vector2[4] { Vector2.zero, Vector2.downRight, Vector2.right, Vector2.down };

            bool isInTarget = false;
            int action;

            for (int cycle = 0; cycle < liveTime && !isInTarget; cycle++)
            {
                action = KTZEngineAplication.random.Next(Math.Max(xChanceGo + yChanceGo + randomChanceGo + (target - pos).Absolute, xChanceGo + yChanceGo));
                targetDir = new Vector2(Math.Sign(target.x - pos.x), Math.Sign(target.y - pos.y));
                if (action < xChanceGo) { moveDir = new Vector2(0, targetDir.y); }
                else if (action >= xChanceGo && action < yChanceGo + xChanceGo) { moveDir = new Vector2(targetDir.x, 0); }
                else if (action >= yChanceGo + xChanceGo && action < randomChanceGo + yChanceGo + xChanceGo + (target - pos).Absolute) { moveDir = Vector2.fourDirections[KTZEngineAplication.random.Next(Vector2.fourDirections.Count)]; }

                for (int i = 0; i < KTZEngineAplication.random.Next(minRoadLength, maxRoadLength) && !isInTarget; i++)
                {
                    newPos = KTZMath.CutNumberToInterval(KTZMath.CutNumberToInterval(pos + moveDir * 2, Vector2.zero, virtualMapSize), fieldStart, fieldEnd);
                    for (int q = 0; q < sideGoDirs.Length && !isInTarget; q++)
                    {
                        drawTilePos = KTZMath.CutNumberToInterval(KTZMath.CutNumberToInterval(newPos + sideGoDirs[q], Vector2.zero, virtualMapSize), fieldStart, fieldEnd);
                        if (allowedNums.Contains(virtualMap[drawTilePos.x, drawTilePos.y]))
                        {
                            pos = newPos;
                            path[drawTilePos.x, drawTilePos.y] = 1;
                            if (drawTilePos == target) { isInTarget = true; }
                        }
                    }
                }

            }

            if (isInTarget)
            {
                for (int x = 0; x < path.GetLength(0); x++)
                {
                    for (int y = 0; y < path.GetLength(1); y++)
                    {
                        if (path[x, y] == 1) { virtualMap[x, y] = traceNum; }
                    }
                }
            }

            return virtualMap;
        }
        public static int[,] RunBigWormInVirtualMap(int[,] virtualMap, Vector2 start, Vector2 fieldStart, Vector2 fieldEnd, Vector2 target, List<int> allowedNums, int traceNum, int minRoadLength = 1, int maxRoadLength = 10, int xChanceGo = 30, int yChanceGo = 30, int randomChanceGo = -10, int liveTime = -1)
        {
            if (liveTime <= 0) { liveTime = virtualMap.Length; }

            int[,] path = CreateVirtualMap(virtualMap.GetLength(0), virtualMap.GetLength(1), 0);
            path[fieldStart.x, fieldStart.y] = traceNum;

            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            Vector2 pos = start;
            Vector2 targetDir = new(Math.Sign(target.x - pos.x), Math.Sign(target.y - pos.y));
            Vector2 moveDir = targetDir;
            Vector2 newPos;
            Vector2 drawTilePos;

            int action;
            bool isInTarget = false;

            for (int cycle = 0; cycle < liveTime && !isInTarget; cycle++)
            {
                action = KTZEngineAplication.random.Next(Math.Max(xChanceGo + yChanceGo + randomChanceGo + (target - pos).Absolute, xChanceGo + yChanceGo));
                targetDir = new Vector2(Math.Sign(target.x - pos.x), Math.Sign(target.y - pos.y));
                if (action < xChanceGo) { moveDir = new Vector2(0, targetDir.y); }
                else if (action >= xChanceGo && action < yChanceGo + xChanceGo) { moveDir = new Vector2(targetDir.x, 0); }
                else if (action >= yChanceGo + xChanceGo && action < randomChanceGo + yChanceGo + xChanceGo + (target - pos).Absolute) { moveDir = Vector2.fourDirections[KTZEngineAplication.random.Next(Vector2.fourDirections.Count)]; }

                for (int i = 0; i < KTZEngineAplication.random.Next(minRoadLength, maxRoadLength) && !isInTarget; i++)
                {
                    newPos = KTZMath.CutNumberToInterval(KTZMath.CutNumberToInterval(pos + moveDir * 3, Vector2.zero, virtualMapSize), fieldStart, fieldEnd);
                    if (allowedNums.Contains(virtualMap[newPos.x, newPos.y]))
                    {
                        pos = newPos;
                        path[newPos.x, newPos.y] = 1;
                        if (newPos == target) { isInTarget = true; }
                    }
                    for (int q = 0; q < Vector2.eightDirections.Count && !isInTarget; q++)
                    {
                        drawTilePos = KTZMath.CutNumberToInterval(KTZMath.CutNumberToInterval(newPos + Vector2.eightDirections[q], Vector2.zero, virtualMapSize), fieldStart, fieldEnd);
                        if (allowedNums.Contains(virtualMap[drawTilePos.x, drawTilePos.y]))
                        {
                            pos = newPos;
                            path[drawTilePos.x, drawTilePos.y] = 1;
                            if (drawTilePos == target) { isInTarget = true; }
                        }
                    }
                }

            }

            if (isInTarget)
            {
                for (int x = 0; x < path.GetLength(0); x++)
                {
                    for (int y = 0; y < path.GetLength(1); y++)
                    {
                        if (path[x, y] == 1) { virtualMap[x, y] = traceNum; }
                    }
                }
            }

            return virtualMap;
        }

        public static int[,] VectorsClearStructureOnVirtualMap(int[,] virtualMap, Dictionary<Vector2, int> tiles, int emptyInt, Vector2 startFieldForClear, Vector2 endFieldForClear)
        {
            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            // Vector2 structureSize = new Vector2(structureForClear.GetLength(0) - 1, structureForClear.GetLength(1) - 1);


            List<Vector2> tilesKeys = tiles.Keys.ToList();
            List<int> tilesValues = tiles.Values.ToList();
            startFieldForClear = KTZMath.CutNumberToInterval(startFieldForClear, Vector2.zero - new Vector2(Math.Min(tilesKeys.MinBy(o => o.x).x, 0), Math.Min(tilesKeys.MinBy(o => o.y).y, 0)), virtualMapSize);
            endFieldForClear = KTZMath.CutNumberToInterval(endFieldForClear, Vector2.zero, virtualMapSize - new Vector2(Math.Max(tilesKeys.MaxBy(o => o.x).x, 0), Math.Max(tilesKeys.MaxBy(o => o.y).y, 0)));

            bool zoneNice;

            if (startFieldForClear < endFieldForClear)
            {
                for (int x = startFieldForClear.x; x < endFieldForClear.x; x++)
                {
                    for (int y = startFieldForClear.y; y < endFieldForClear.y; y++)
                    {
                        zoneNice = true;
                        for (int i = 0; i < tilesKeys.Count && zoneNice; i++)
                        {
                            if (virtualMap[x + tilesKeys[i].x, y + tilesKeys[i].y] != tilesValues[i]) { zoneNice = false; }
                        }
                        if (zoneNice)
                        {
                            for (int i = 0; i < tilesKeys.Count; i++)
                            {
                                virtualMap[x + tilesKeys[i].x, y + tilesKeys[i].y] = emptyInt;
                            }
                        }
                    }
                }
            }


            return virtualMap;
        }

        public static int[,] OptimizationOfWalls(int[,] virtualMap, int fullWallNum, int emptyWallNum)
        {
            int[,] optimizateMap = CreateVirtualMap(virtualMap.GetLength(0), virtualMap.GetLength(1), 0);
            Vector2 virtualMapSize = new(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            Vector2 pos;
            Vector2 chekedPos;
            bool isNeedOptimizate;

            for (int x = 1; x < virtualMapSize.x; x++)
            {
                for (int y = 1; y < virtualMapSize.y; y++)
                {
                    isNeedOptimizate = true;
                    pos = new Vector2(x, y);
                    for (int q = 0; q < Vector2.fourDirections.Count; q++)
                    {
                        chekedPos = pos + Vector2.fourDirections[q];
                        if (virtualMap[chekedPos.x, chekedPos.y] != fullWallNum) { isNeedOptimizate = false; break; }
                    }
                    if (isNeedOptimizate) { optimizateMap[pos.x, pos.y] = 1; }
                }
            }
            for (int x = 1; x < virtualMapSize.x; x++)
            {
                for (int y = 1; y < virtualMapSize.y; y++)
                {
                    if (optimizateMap[x, y] == 1) { virtualMap[x, y] = emptyWallNum; }

                }
            }

            return virtualMap;
        }

        public static int[,] BombHoleGenerate(int[,] virtualMap, int holeNum, int eggsCount = 14, int growTimes = 8)
        {
            Vector2 virtualMapSize = new Vector2(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            Vector2 currVectorpos;
            int xEgg;
            int yEgg;
            int chance;
            for (int i = 0; i < eggsCount; i++)
            {
                xEgg = KTZEngineAplication.random.Next(1, virtualMapSize.x - 1);
                yEgg = KTZEngineAplication.random.Next(1 + zoneHeight, virtualMapSize.y - 1 - zoneHeight);
                virtualMap[xEgg, yEgg] = holeNum;
                for (int q = 0; q < Vector2.fourDirections.Count; q++) { virtualMap[xEgg + Vector2.fourDirections[q].x, yEgg + Vector2.fourDirections[q].y] = holeNum; }
            }

            for (int i = 0; i < growTimes; i++)
            {
                for (int x = 1; x < virtualMapSize.x; x++)
                {
                    for (int y = 1; y < virtualMapSize.y; y++)
                    {
                        chance = 1;
                        for (int dirI = 0; dirI < Vector2.eightDirections.Count; dirI++)
                        {
                            currVectorpos = new Vector2(x + Vector2.eightDirections[dirI].x, y + Vector2.eightDirections[dirI].y);
                            chance = (virtualMap[currVectorpos.x, currVectorpos.y] == holeNum) ? chance + 2 : chance;
                        }
                        if (KTZEngineAplication.random.Next(chance) > 4) { virtualMap[x, y] = holeNum; }
                    }
                }
            }

            return virtualMap;
        }

        public static int[,] CityNameBoxGeneration(int[,] virtualMap, Vector2 pos, string text)
        {
            int textLen = text.Length;
            int[,] generateStruct = CreateVirtualMap(textLen + 4, 5, 0);
            for (int x = 1; x < textLen + 3; x++) { generateStruct[x, 1] = 1; generateStruct[x, 3] = 1; }

            generateStruct[1, 2] = 1;
            generateStruct[textLen + 2, 2] = 1;

            CreateStructureHard(virtualMap, generateStruct, pos + new Vector2(-2, -3));



            return virtualMap;
        }

        public static int[,] GeneratePricklyHedgehogs(int[,] refVirtualMap, List<int> genCounts = null)
        {
            if (genCounts == null) { genCounts = new List<int>() { 4, 4, 3, 6 }; }

            int[,] virtualMap = VirtualMapCopy(refVirtualMap);
            Vector2 virtualMapSize = new Vector2(virtualMap.GetLength(0) - 1, virtualMap.GetLength(1) - 1);
            List<int[,]> gS2 = new List<int[,]>()
            {

                new int[,]{
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                },
                new int[,]
                {
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                }
            };
            List<int[,]> gS3 = new List<int[,]>()
            {

                new int[,]{
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                },
                new int[,]
                {
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                }
            };
            List<int[,]> gS4 = new List<int[,]>()
            {

                new int[,]{
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                },
                new int[,]
                {
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 5, 0 },
                    { 0, 0, 0 },
                    { 0, 0, 0 },
                }
            };

            List<List<int[,]>> structures = new List<List<int[,]>> { gS2, gS3, gS4 };


            for (int i = 0; i < structures.Count; i++)
            {
                for (int q = 0; q < genCounts[i];)
                {
                    if (CreateStructureOnlyIfAllNotEmptyEqual(ref virtualMap, structures[i][KTZEngineAplication.random.Next(2)], new Vector2(KTZEngineAplication.random.Next(virtualMapSize.x), KTZEngineAplication.random.Next(virtualMapSize.y - zoneHeight)), new List<int>() { 0 }, new List<int>() { 0, 4 })) { q++; }
                }
            }


            return virtualMap;
        }
    }
}
