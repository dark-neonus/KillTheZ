using System;
using System.Collections.Generic;
using System.Linq;
using Vector2 = Vector2Namespace.Vector2;


#nullable enable

namespace KTZEngine
{
    public class Game : GameTab
    {
        public KTZEngineAplication aplication;
        public GameGrid gameGrid;
        public bool isInGame;

        public Vector2 windowSize;

        public Dictionary<string, GameObject> gameObjects = new();
        public List<GameObject> gameObjectsList = new();

        private GameObject gmObj;

        public Game(ref KTZEngineAplication aplication_, Vector2 gameGridSize, string name_, int ups_) : base(aplication_, name_, ups_)
        {
            aplication = aplication_;
            isInGame = true;
            gameGrid = new GameGrid("mainGameGrid", gameGridSize.x, gameGridSize.y, Vector2.zero);
            windowSize = new Vector2(Console.WindowWidth, Console.WindowHeight);
        }

        public void AddExistGameObject(GameObject newGameObj)
        {
            try { gameObjects.Add(newGameObj.name, newGameObj); gameObjectsList.Add(newGameObj); }
            catch (ArgumentException e) { KTZEngineAplication.MessageOutput(e.GetType().Name.ToString() + ": " + e.Message.ToString()); throw new Exception(e.Message); }
        }
        public void AddExistGameObject(GameObject newGameObj, Vector2 pos, string name)
        {
            try
            {
                newGameObj.globalPosition = pos;
                newGameObj.name = name;
                gameObjects.Add(newGameObj.name, newGameObj);
                gameObjectsList.Add(newGameObj);
            }
            catch (ArgumentException e) { KTZEngineAplication.MessageOutput(e.GetType().Name.ToString() + ": " + e.Message.ToString()); throw new Exception(e.Message); }
        }
        public int DeleteGameObject(string name)
        {
            try
            {
                if (gameObjects.ContainsKey(name))
                {
                    GameObject remObj = gameObjects[name];
                    if (KTZMath.IsInInterval(remObj.localPosition, Vector2.zero, new Vector2(remObj.layer.layerWidth, remObj.layer.layerHeight) - 1)) { remObj.layer.grid[remObj.localPosition.x, remObj.localPosition.y] = remObj.layer.emptyChar; }

                    gameObjectsList.Remove(remObj);
                    gameObjects.Remove(name);

                    remObj = null;
                    return 1;
                }

                return 0;
            }
            catch (ArgumentException e) { KTZEngineAplication.MessageOutput(e.GetType().Name.ToString() + ": " + e.Message.ToString()); throw new Exception(e.Message); }
        }

        public override void PreUpdate() { gameObjectsList = gameObjects.Values.ToList(); }
        public override void Update()
        {
            // Self Update

            // Global Update
            PreUpdateGame();
            GameObjectsPreUpdate();

            // SpecialUpdate();

            gameGrid.Update();
            UpdateGame();
            GameObjectsUpdate();
            GameObjectsDrawOnGrid();
            gameGrid.LayersCompression();
            gameGrid.Draw();

            AfterUpdateGame();
            GameObjectsAfterUpdate();
            // UpdateTab();
        }
        public override void AfterUpdate() { }

        public virtual void PreUpdateGame() { }
        public virtual void UpdateGame() { }
        public virtual void AfterUpdateGame() { }


        public void GameObjectsPreUpdate()
        {
            for (int i = 0; i < gameObjectsList.Count; i++)
            {
                gameObjectsList[i].GameObjectPreUpdate();
            }
        }
        public void GameObjectsUpdate()
        {
            for (int i = 0; i < gameObjectsList.Count; i++)
            {
                gmObj = gameObjectsList[i];
                if (KTZMath.IsInInterval(gmObj.localPosition, Vector2.zero, new Vector2(gmObj.layer.layerWidth - 1, gmObj.layer.layerHeight - 1)))
                {
                    gmObj.layer.grid[gmObj.localPosition.x, gmObj.localPosition.y] = gmObj.layer.emptyChar;
                }
                gmObj.GameObjectUpdate();
                gmObj.GameObjectAfterMoveUpdate();
            }
        }
        public void GameObjectsAfterUpdate()
        {
            for (int i = 0; i < gameObjectsList.Count; i++)
            {
                gameObjectsList[i].GameObjectAfterUpdate();
            }
        }
        public void GameObjectsDrawOnGrid()
        {
            foreach (var gmObj in gameObjectsList.OrderBy(o => o.priority))
            {
                if (KTZMath.IsInInterval(gmObj.localPosition, Vector2.zero, new Vector2(gmObj.layer.layerWidth - 1, gmObj.layer.layerHeight - 1)))
                {
                    gmObj.layer.grid[gmObj.localPosition.x, gmObj.localPosition.y] = gmObj.icon;
                }
            }
        }

        public void PostProcessing(Vector2 coord, char symbol)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(coord.x, windowSize.y - coord.y - 1);
            Console.Write(symbol);
        }
        public void PostProcessing(Vector2 coord, string text)
        {
            Console.CursorVisible = false;
            Console.SetCursorPosition(coord.x, windowSize.y - coord.y - 1);
            Console.Write(text);
        }

    }


    public class GameGrid
    {

        public Dictionary<string, GameLayer> layers = new() { };
        public char emptyChar = ' ';

        public Grid grid;
        public GameLayer[] layersArr;

        public Vector2 currPos;
        public Vector2 currPosInLayer;

        public List<KeyValuePair<Vector2, string>> regularPostProcessingData = new List<KeyValuePair<Vector2, string>>() { };
        public List<KeyValuePair<Vector2, string>> disposablePostProcessingData = new List<KeyValuePair<Vector2, string>>() { };
        public List<KeyValuePair<Vector2, string>> sumPostProcessingData = new List<KeyValuePair<Vector2, string>>() { };

        private int postProcessX;
        private int postProcessY;

        public GameGrid(string name_, int gridW, int gridH, Vector2? startPosition = null)
        {
            if (startPosition == null) { startPosition = Vector2.zero; }
            grid = new Grid(name_, (Vector2)startPosition, gridW, gridH, emptyChar);
        }

        public void LayersCompression(bool ignoreEmptyChar = true)
        {
            if (layers.Count > 0)
            {
                layersArr = layers.Values.OrderBy(c => c.priority).ToArray();

                grid.Clear();

                if (ignoreEmptyChar)
                {
                    for (int y = 0; y < grid.Height; y++)
                    {
                        for (int x = 0; x < grid.Width; x++)
                        {
                            currPos = new Vector2(x, y);
                            foreach (GameLayer layer in layersArr)
                            {
                                if (KTZMath.IsInInterval(currPos, layer.layerStartPosition, layer.layerStartPosition + new Vector2(layer.layerWidth, layer.layerHeight) + Vector2.downLeft))
                                {
                                    currPosInLayer = currPos - layer.layerStartPosition;
                                    if (layer.grid[currPosInLayer.x, currPosInLayer.y] != layer.emptyChar) { grid.grid[x, y] = layer.grid[currPosInLayer.x, currPosInLayer.y]; }
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int y = 0; y < grid.Height; y++)
                    {
                        for (int x = 0; x < grid.Width; x++)
                        {
                            currPos = new Vector2(x, y);

                            foreach (GameLayer layer in layersArr)
                            {
                                if (KTZMath.IsInInterval(currPos, layer.layerStartPosition, layer.layerStartPosition + new Vector2(layer.layerWidth - 1, layer.layerHeight - 1)))
                                {
                                    currPosInLayer = currPos - layer.layerStartPosition;
                                    grid.grid[x, y] = layer.grid[currPosInLayer.x, currPosInLayer.y];
                                }
                            }
                        }
                    }
                }
            }
            sumPostProcessingData = regularPostProcessingData.Concat(disposablePostProcessingData).ToList();
            for (int i = 0; i < sumPostProcessingData.Count; i++)
            {
                int q = 0;
                postProcessY = sumPostProcessingData.ElementAt(i).Key.y;
                if (KTZMath.IsInInterval(postProcessY, 0, grid.Height - 1))
                {

                    postProcessX = sumPostProcessingData.ElementAt(i).Key.x;
                    for (int x = postProcessX; x < grid.Width && x >= 0 && q < sumPostProcessingData.ElementAt(i).Value.Length; x++)
                    {
                        grid.grid[x, postProcessY] = sumPostProcessingData.ElementAt(i).Value[q];
                        q++;
                    }
                }
            }

            disposablePostProcessingData = new List<KeyValuePair<Vector2, string>>() { };
        }
        public void Update()
        {

        }
        public void Draw() { grid.Draw(); }

        public GameLayer CreateLayer(string name_, int width, int height, Vector2 layerStartPos, char emptyChar, int priority)
        {
            Vector2 layerSize = new(width, height);
            GameLayer newLayer = new(layerSize.x, layerSize.y, name_, emptyChar, priority, layerStartPos);
            layers.Add(newLayer.name, newLayer);
            return layers[newLayer.name];
        }

        public void AddDisposablePostProcessingText(Vector2 pos, string text)
        {
            disposablePostProcessingData.Add(new KeyValuePair<Vector2, string>(pos, text));
        }

    }

    public class GameLayer
    {
        public string name;

        public char[,] grid;
        public char emptyChar;

        public int layerWidth;
        public int layerHeight;

        public Vector2 layerStartPosition;

        public List<StaticGameObject> staticObjects;

        public int priority;

        public GameLayer(int gridW, int gridH, string name_, char emptCh, int priority_, Vector2 gameLayerStartPosition)
        {
            layerWidth = gridW;
            layerHeight = gridH;

            name = name_;

            layerStartPosition = gameLayerStartPosition;

            grid = new char[layerWidth, layerHeight];
            emptyChar = emptCh;

            priority = priority_;

            staticObjects = new List<StaticGameObject>();

            Clear();
        }

        public void Clear()
        {
            for (int x = 0; x < layerWidth; x++)
            {
                for (int y = 0; y < layerHeight; y++)
                {
                    grid[x, y] = emptyChar;
                }
            }
        }

        public StaticGameObject CreateStaticObject(Vector2 position_, char ico, List<string> ids = null)
        {
            StaticGameObject newStaticGameObj = new(position_, this, ico, ids);
            staticObjects.Add(newStaticGameObj);
            newStaticGameObj.DrawOnLayerGrid();
            return newStaticGameObj;
        }

        public void AddExistStaticObject(StaticGameObject obj_, Vector2 localPos)
        {
            StaticGameObject obj = obj_.Copy();
            obj.layer = this;
            obj.localPosition = localPos;
            staticObjects.Add(obj);
            obj.DrawOnLayerGrid();
            // obj.DrawOnLayerGrid();
        }

    }

    public class GameObject
    {
        public string name;
        public Vector2 globalPosition;
        public Vector2 localPosition;
        public Vector2 disposableVelocity;
        public Vector2 regularVelocity;
        public Vector2 finalVelocity;
        public GameLayer layer;
        public int priority = 1;
        public char icon;

        public List<string> id = new();
        public List<Vector2> blockedDirections = new();

        public GameObject(string objName, GameLayer thisLayer, Vector2 _position, char ico, List<string> ids = null, int priority_ = 1)
        {
            layer = thisLayer;
            name = objName;
            priority = priority_;
            globalPosition = _position;
            localPosition = globalPosition - layer.layerStartPosition;
            disposableVelocity = Vector2.zero;
            regularVelocity = Vector2.zero;
            icon = ico;
            if (ids != null) { id = ids; }
            id.Add("GameObject");
        }

        public void GameObjectPreUpdate()
        {
            PreUpdate();
        }

        public void GameObjectUpdate()
        {

            // Update position
            finalVelocity = disposableVelocity + regularVelocity;

            localPosition = blockedDirections.Contains(finalVelocity.Direction) ? localPosition : localPosition + finalVelocity;

            // if (!blockedDirections.Contains(finalVelocity.Direction))
            // {
            //     localPosition += finalVelocity;
            // }

            globalPosition = layer.layerStartPosition + localPosition;

            // currentLayerStartPos = layer.layerStartPosition;

            // ChildUpdate
            Update();

        }
        public void GameObjectAfterUpdate()
        {
            disposableVelocity = Vector2.zero;

            AfterUpdate();
        }

        public void GameObjectAfterMoveUpdate() { AfterMoveUpdate(); }

        public virtual void PreUpdate() { }
        public virtual void Update() { }
        public virtual void AfterMoveUpdate() { }
        public virtual void AfterUpdate() { }

    }

    public class StaticGameObject
    {
        public Vector2 localPosition;
        public Vector2 _globalPosition;
        public Vector2 globalPosition
        {
            get { _globalPosition = localPosition + layer.layerStartPosition; return _globalPosition; }
        }
        public GameLayer layer;
        public char ico;

        public List<string> id = new();

        public StaticGameObject(Vector2 position_, GameLayer layer_, char ico_, List<string> ids = null)
        {
            localPosition = position_;
            layer = layer_;
            ico = ico_;
            if (ids != null) { id = ids; }
            id.Add("StaticGameObject");
        }

        public void DrawOnLayerGrid()
        {
            if (KTZMath.IsInInterval(localPosition, Vector2.zero, new Vector2(layer.layerWidth - 1, layer.layerHeight - 1)))
            {
                layer.grid[localPosition.x, localPosition.y] = ico;
            }
        }

        public StaticGameObject Copy()
        {
            return new StaticGameObject(localPosition, layer, ico, id);
        }
    }
}


