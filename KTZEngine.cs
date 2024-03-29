﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Versioning;
using System.Threading;
using Vector2 = Vector2Namespace.Vector2;


#nullable enable

namespace KTZEngine
{
    public class KTZEngineAplication
    {
        public const string standartWindowTitle = "KTZEngineAplication";
        public const int standartWindowWidth = 85;
        public const int standartWindowHeight = 43;
        public const string KTZEngineMainTabName = "KTZEngineMainTab";
        public GameTab? KTZEngineMainTab;
        public const bool standartConsoleResizable = false;

        public const string smallEnglishAlphabet = "abcdefghijklmnopqrstuvwxyz";

        public static readonly Random random = new();

        public static string windowTitle = standartWindowTitle;
        public static bool consoleResizable = standartConsoleResizable;

        public GameText? gameText;

        public bool isInAplication;

        public static int windowWidth;
        public static int windowHeight;

        public Dictionary<string, GameTab> gameTabs = new() { };
        public Dictionary<string, Action> tabsBehavior = new() { };
        public string currentGameTabName = "";

        DateTime start;
        TimeSpan time;

        public float currentAverageFPS;
        public float[] arrayOfFPS = Array.Empty<float>();

        public ConsoleColor ConsoleBackgroundColor = ConsoleColor.Black;
        public ConsoleColor ConsoleForegroundColor = ConsoleColor.Gray;

        public KTZEngineAplication(int windowW = standartWindowWidth, int windowH = standartWindowHeight, string windowTitle_ = standartWindowTitle, Dictionary<string, Action>? tabsBehavior_ = null, bool _consoleResizable = standartConsoleResizable)
        {
            windowWidth = windowW;
            windowHeight = windowH;
            windowTitle = windowTitle_;
            consoleResizable = _consoleResizable;
            if (tabsBehavior_ != null) { tabsBehavior = tabsBehavior_; }
        }


        public void Init()
        {
            Console.Title = windowTitle;

            Console.TreatControlCAsInput = true;

            Console.CursorVisible = false;
            SetConsoleSizeOnWindows();
            ConsoleBasicSettings.StopConsoleExecuting();

            if (!consoleResizable) { ConsoleBasicSettings.ConsoleResizableDisable_(); }

            KTZEngineMainTab = new GameTab(this, KTZEngineMainTabName);
            currentGameTabName = KTZEngineMainTab.name;

            currentGameTabName = gameTabs[KTZEngineMainTab.name].name;

            isInAplication = true;

            UpdateConsoleColors();


            currentAverageFPS = 0;
            arrayOfFPS = new float[60];
            Array.Fill(arrayOfFPS, gameTabs[currentGameTabName].UPS);
        }

        [SupportedOSPlatform("windows")]
        public static void SetConsoleSizeOnWindows() { Console.SetWindowSize(windowWidth, windowHeight); Console.SetBufferSize(windowWidth, windowHeight); }

        public void UpdateConsoleColors()
        {
            Console.BackgroundColor = ConsoleBackgroundColor;
            Console.ForegroundColor = ConsoleForegroundColor;
        }

        public void Update()
        {

            start = DateTime.Now;

            gameTabs[currentGameTabName].PreUpdateTab();

            gameTabs[currentGameTabName].UpdateTab();
            TabsBehavior();

            gameTabs[currentGameTabName].AfterUpdateTab();


            time = DateTime.Now - start;
            Thread.Sleep(Math.Max(gameTabs[currentGameTabName].delayPerUpdate - time.Milliseconds, 0));
            gameTabs[currentGameTabName].time += (ulong)((DateTime.Now - start).Milliseconds);

            for (int i = 0; i < arrayOfFPS.Length - 1; i++) { arrayOfFPS[i] = arrayOfFPS[i + 1]; }
            arrayOfFPS[^1] = (float)(1 / Math.Max(0.00001, TimeSpan.FromMilliseconds(time.Milliseconds).TotalSeconds));
            currentAverageFPS = arrayOfFPS.Average();
        }

        public void TabsBehavior()
        {
            foreach (var tab in tabsBehavior) { if (currentGameTabName == tab.Key) { tab.Value(); } }
        }

        public static void MessageOutput(string text)
        {
            using StreamWriter sw = File.AppendText("Message.txt");
            sw.WriteLine("{0}\n({1})\n{2}", new string('_', 50), DateTime.Now, text);

        }

        public static string GenerateProtectName()
        {
            return KTZEngineAplication.random.NextDouble().ToString() + KTZEngineAplication.random.Next(Int32.MinValue + 1, Int32.MaxValue - 1).ToString();
        }

    }

    public class GameTab
    {
        public KTZEngineAplication aplication;

        public string name;
        private int _ups;

        public ulong time = 0;

        public int UPS
        {
            get { return _ups; }
            set
            {
                if (value <= 0) { _ups = 1; }
                else { _ups = value; }
            }
        }
        public int delayPerUpdate;
        public int frameInd;

        public KeyManager keyManager;

        public GameTab(KTZEngineAplication aplication_, string name_, int ups_ = 1)
        {
            aplication = aplication_;
            name = name_;
            UPS = ups_;
            delayPerUpdate = (int)(1000 / UPS);
            frameInd = 0;
            aplication.gameTabs.Add(name, this);

            keyManager = new KeyManager();
        }

        public void PreUpdateTab()
        {
            PreUpdate();
        }
        public void UpdateTab()
        {

            Update();
            keyManager.Update();

            KeyManager.ClearKeyPressBuffer();
        }
        public void AfterUpdateTab()
        {
            AfterUpdate();
        }

        public virtual void PreUpdate() { }
        public virtual void Update() { }
        public virtual void AfterUpdate() { }
    }

    public class SelectListTab : GameTab
    {
        public const int standartDistanceBetweenElements = 1;
        public const string standartSelectItemRightSign = " <";
        public const string standartSelectItemLeftSign = "> ";

        public List<SLTItem> itemList = new() { };
        public int selectedElemIndex = 0;
        public int distanceBetweenElements;
        public string selectItemRightSign;
        public string selectItemLeftSign;
        public bool drawRightSign = true;
        public bool drawLeftSign = true;


        public List<KeyValuePair<Vector2, string>> regularPostProcessingData = new() { };
        public List<KeyValuePair<Vector2, string>> disposablePostProcessingData = new() { };
        public List<KeyValuePair<Vector2, string>> sumPostProcessingData = new() { };

        public SelectListTab(KTZEngineAplication aplication_, List<SLTItem> SLTItemList, string name_, int ups_, string selectItemRightSign_ = standartSelectItemRightSign, string selectItemLeftSign_ = standartSelectItemLeftSign, int distanceBetweenElements_ = standartDistanceBetweenElements) : base(aplication_, name_, ups_)
        {
            itemList = SLTItemList;
            selectItemRightSign = selectItemRightSign_;
            selectItemLeftSign = selectItemLeftSign_;
            for (int i = 0; i < itemList.Count; i++) { itemList[i].orderNumber = i; }
            distanceBetweenElements = distanceBetweenElements_;

            keyManager = new KeyManager(new Dictionary<ConsoleKey, Action> {
            {ConsoleKey.UpArrow, SelectPreviousElement },
            {ConsoleKey.W, SelectPreviousElement },
            {ConsoleKey.DownArrow, SelectNextElement },
            {ConsoleKey.S, SelectNextElement },
            { ConsoleKey.Enter, SelectItem }
            });
        }

        public override void Update()
        {
            if (itemList.Count > 0) { selectedElemIndex = KTZMath.LoopNumberInInterval(selectedElemIndex, 0, itemList.Count - 1); }
        }

        public virtual void Draw()
        {
            Vector2 cursorPos = Vector2.zero;
            string leftSign;
            string rightSign;


            foreach (SLTItem item in itemList)
            {
                leftSign = new string(' ', selectItemLeftSign.Length);
                rightSign = new string(' ', selectItemRightSign.Length);
                if (item.sideOffset - selectItemLeftSign.Length >= 0 && drawLeftSign && itemList.IndexOf(item) == selectedElemIndex) { leftSign = selectItemLeftSign; rightSign = selectItemRightSign; }
                if (KTZEngineAplication.standartWindowWidth - item.sideOffset - item.text.Length - selectItemRightSign.Length >= 0 && drawRightSign && itemList.IndexOf(item) == selectedElemIndex) { rightSign = selectItemRightSign; }

                cursorPos.y += item.topOffset + 1;
                cursorPos.x = item.sideOffset - rightSign.Length;
                Console.SetCursorPosition(cursorPos.x, cursorPos.y);

                Console.WriteLine(leftSign + item.text + rightSign);
            }

            sumPostProcessingData = regularPostProcessingData.Concat(disposablePostProcessingData).ToList();
            for (int i = 0; i < sumPostProcessingData.Count; i++)
            {
                if (KTZMath.IsInInterval(sumPostProcessingData[i].Key, Vector2.zero, new Vector2(KTZEngineAplication.windowWidth, KTZEngineAplication.windowHeight)))
                {
                    Console.SetCursorPosition(sumPostProcessingData[i].Key.x, sumPostProcessingData[i].Key.y);
                    Console.Write(sumPostProcessingData[i].Value);
                }
            }

            disposablePostProcessingData = new List<KeyValuePair<Vector2, string>>() { };

        }

        public void HeightAlignToCenter()
        {
            itemList[0].topOffset = 0;
            int listHeight = itemList.Count;
            for (int i = 0; i < itemList.Count; i++)
            {
                listHeight += itemList[i].topOffset;
            }
            if (listHeight > Console.BufferHeight) { Console.BufferHeight = listHeight; }

            itemList[0].topOffset = (int)((Console.BufferHeight - listHeight * 1.5) / 2);
        }

        public void AlignToCenter()
        {
            foreach (var item in itemList)
            {
                item.sideOffset = (int)Math.Round((double)((KTZEngineAplication.windowWidth - item.text.Length) / 2));
            }
        }

        public void SelectNextElement() { selectedElemIndex++; }
        public void SelectPreviousElement() { selectedElemIndex--; }
        public void SelectItem() { if (itemList.Count > 0) { itemList[selectedElemIndex].Activate(); } }
    }

    public class SLTItem
    {
        public const int standartSideOffset = 0;
        public const int standartTopOffset = 0;

        public string name;
        public string text;
        public Action activateMethod;
        public int orderNumber;
        public int sideOffset;
        public int topOffset;

        public SLTItem(string name_, string text_, Action activateMethod_, int topOffset_ = standartTopOffset, int sideOffset_ = standartSideOffset)
        {
            name = name_;
            text = text_;
            activateMethod = activateMethod_;
            sideOffset = sideOffset_;
            topOffset = topOffset_;
        }

        public void Activate()
        {
            activateMethod();
        }
    }

    public class SelectSelectListTab : GameTab
    {
        public const int standartDistanceBetweenElements = 0;
        public const string standartSelectItemRightSign = " >";
        public const string standartSelectItemLeftSign = "< ";

        public List<SSLTItem> itemList = new() { };
        public int selectedElemIndex = 0;
        public int distanceBetweenElements;
        public string selectItemRightSign;
        public string selectItemLeftSign;
        public bool drawRightSign = true;
        public bool drawLeftSign = true;


        public SelectSelectListTab(KTZEngineAplication aplication_, List<SSLTItem> SSLTItemList, string name_, int ups_, string selectItemRightSign_ = standartSelectItemRightSign, string selectItemLeftSign_ = standartSelectItemLeftSign, int distanceBetweenElements_ = standartDistanceBetweenElements) : base(aplication_, name_, ups_)
        {
            itemList = SSLTItemList;
            selectItemRightSign = selectItemRightSign_;
            selectItemLeftSign = selectItemLeftSign_;
            for (int i = 0; i < itemList.Count; i++) { itemList[i].orderNumber = i; }
            distanceBetweenElements = distanceBetweenElements_;

            keyManager = new KeyManager(new Dictionary<ConsoleKey, Action> {
            {ConsoleKey.Enter, ActivateCurrentElement },
            {ConsoleKey.Spacebar, ActivateCurrentElement },
            {ConsoleKey.UpArrow, SelectPreviousElement },
            {ConsoleKey.W, SelectPreviousElement },
            {ConsoleKey.DownArrow, SelectNextElement },
            {ConsoleKey.S, SelectNextElement },
            {ConsoleKey.RightArrow, SelectRightItem },
            {ConsoleKey.D, SelectRightItem },
            {ConsoleKey.LeftArrow, SelectLeftItem },
            {ConsoleKey.A, SelectLeftItem },
            });

        }

        public override void Update()
        {
            if (itemList.Count > 0) { selectedElemIndex = KTZMath.LoopNumberInInterval(selectedElemIndex, 0, itemList.Count - 1); }
            SSListTabUpdate();
        }

        public virtual void SSListTabUpdate() { }

        public virtual void Draw()
        {
            Vector2 cursorPos = Vector2.zero;
            string leftSign;
            string rightSign;


            foreach (SSLTItem item in itemList)
            {
                item.AlignItemToCenter();
                leftSign = new string(' ', selectItemLeftSign.Length);
                rightSign = new string(' ', selectItemRightSign.Length);
                if (item.sideOffset - selectItemLeftSign.Length >= 0 && drawLeftSign && itemList.IndexOf(item) == selectedElemIndex) { leftSign = selectItemLeftSign; rightSign = selectItemRightSign; }
                if (KTZEngineAplication.standartWindowWidth - item.sideOffset - item.variants[item.selectedIndex].text.Length - selectItemRightSign.Length >= 0 && drawRightSign && itemList.IndexOf(item) == selectedElemIndex) { rightSign = selectItemRightSign; }

                cursorPos.y += item.topOffset + 1;
                cursorPos.x = item.sideOffset;

                Console.SetCursorPosition(0, cursorPos.y);
                Console.Write(new string(' ', KTZEngineAplication.windowWidth - 1));
                Console.SetCursorPosition(cursorPos.x, cursorPos.y);
                Console.WriteLine(item.title);

                cursorPos.y += item.selectorTopOffset + 1;
                cursorPos.x = item.sideOffset + item.selectorSideOffset - rightSign.Length;
                Console.SetCursorPosition(0, cursorPos.y);
                Console.Write(new string(' ', KTZEngineAplication.windowWidth - 1));
                Console.SetCursorPosition(cursorPos.x, cursorPos.y);
                Console.WriteLine(leftSign + item.variants[item.selectedIndex].text + rightSign);
            }

        }

        public void AlignToCenter()
        {
            foreach (var item in itemList)
            {
                item.sideOffset = (int)Math.Round((double)((KTZEngineAplication.windowWidth - item.title.Length) / 2));
            }
        }

        public void SelectNextElement() { selectedElemIndex++; }
        public void SelectPreviousElement() { selectedElemIndex--; }
        public void SelectLeftItem()
        {
            itemList[selectedElemIndex].ChangeSelectIndex(-1);
            if (itemList[selectedElemIndex].isActivateWhenVisible)
            {
                ActivateCurrentElement();
            }
        }
        public void SelectRightItem()
        {
            itemList[selectedElemIndex].ChangeSelectIndex(1);
            if (itemList[selectedElemIndex].isActivateWhenVisible)
            {
                ActivateCurrentElement();
            }
        }
        public void ActivateCurrentElement() { itemList[selectedElemIndex].variants[itemList[selectedElemIndex].selectedIndex].selectAction(); }
    }

    public class SSLTItem
    {
        public const int standartSideOffset = 0;
        public const int standartTopOffset = 0;
        public const int standartselectorOffset = 0;

        public string name;
        public string title;
        public int orderNumber;
        public int sideOffset;
        public int topOffset;

        public int selectorTopOffset;
        public int selectorSideOffset;

        public List<SSLTItemItem> variants;
        public int selectedIndex = 0;

        public bool isActivateWhenVisible = true;

        public SSLTItem(string name_, string title_, List<SSLTItemItem> variants_, int topOffset_ = standartTopOffset, int sideOffset_ = standartSideOffset, int selectorOffset_ = standartselectorOffset, bool isActivateWhenVisible_ = true)
        {
            name = name_;
            title = title_;
            sideOffset = sideOffset_;
            topOffset = topOffset_;
            variants = variants_;
            selectorTopOffset = selectorOffset_;
            isActivateWhenVisible = isActivateWhenVisible_;
        }

        public void ChangeSelectIndex(int change)
        {
            selectedIndex += change;
            selectedIndex = KTZMath.LoopNumberInInterval(selectedIndex, 0, variants.Count - 1);
        }

        public void AlignItemToCenter()
        {
            selectorSideOffset = (int)((title.Length - variants[selectedIndex].text.Length) / 2);
        }
    }

    public class SSLTItemItem
    {
        public string text;
        public Action selectAction;

        public SSLTItemItem(string text_, Action activateMethod_)
        {
            text = text_;
            selectAction = activateMethod_;
        }
    }




    public static class ConsoleEvents
    {
        public static ConsoleKey? GetKey()
        {
            if (Console.KeyAvailable) { return Console.ReadKey(true).Key; }
            else { return null; }
        }
    }

    public class Language
    {
        public string name;
        public Dictionary<string, string> dictionary = new() { };

        public Language(string languageName)
        {
            name = languageName;
        }
    }

    public class GameText
    {
        public Dictionary<string, Language> languages = new() { };
        public string currentLanguageName;
        public int languagesCount;

        public GameText(string currentLanguageName_, List<Language> languages_)
        {
            currentLanguageName = currentLanguageName_;
            foreach (Language lang in languages_)
            {
                languages.Add(lang.name, lang);
            }
            languagesCount = languages.Count;
        }

        public void AddSomeText(Dictionary<string, Dictionary<string, string>> words)
        {
            foreach (var wordsList in words)
            {
                if (wordsList.Value.Count != languages.Count) { throw new Exception("Count of given arguments(=" + wordsList.Value.Count + ") must equal to languages count(=" + languages.Count + ")"); }
                foreach (var langPair in wordsList.Value)
                {
                    if (languages.ContainsKey(langPair.Key)) { languages[langPair.Key].dictionary.Add(wordsList.Key, langPair.Value); }
                    else { throw new Exception("Cant find \"" + langPair.Key + "\" in \"" + String.Join(", ", languages.Keys.ToArray()) + "\""); }
                }
            }
        }

        public string GetText(string textKey)
        {
            if (languages[currentLanguageName].dictionary.ContainsKey(textKey)) { return languages[currentLanguageName].dictionary[textKey]; }
            else { throw new Exception("Cant find \"" + textKey + "\" in \"" + String.Join(", ", languages[currentLanguageName].dictionary.Keys.ToArray()) + "\""); }
        }
    }

    public class Grid
    {
        public const char standartEmptyChar = ' ';

        public string name;
        public Vector2 startPosition;
        public char[,] grid;
        public int Width;
        public int Height;
        public char emptyChar;

        public Grid(string name_, Vector2 startPosition_, int gridW, int gridH, char emptyChar_ = standartEmptyChar)
        {
            name = name_;
            startPosition = startPosition_;
            Width = gridW;
            Height = gridH;
            grid = new char[Width, Height];
            emptyChar = emptyChar_;
            Clear();
        }

        public void Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    grid[x, y] = emptyChar;
                }
            }
        }

        public void Draw()
        {
            int conBuffHeight = Math.Min(Height, Console.BufferHeight);
            System.Text.StringBuilder outString = new();
            if (KTZMath.IsCubeVectorInFieldVector(startPosition, Width, Height, Vector2.zero, KTZEngineAplication.windowWidth, KTZEngineAplication.windowHeight))
            {
                for (int y = conBuffHeight - 1; y >= 0; y--)
                {
                    for (int x = 0; x < Math.Min(Width, KTZEngineAplication.windowWidth); x++)
                    {
                        outString.Append(grid[x, y]);
                    }
                }
            }
            for (int y = 0; y < Height - 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write(outString.ToString(y * Width, Width));
            }
            Console.SetCursorPosition(0, Height - 1);
            Console.Write(outString.ToString((Height - 1) * Width, Width - 1));


        }
    }

    public class KeyManager
    {
        public Dictionary<ConsoleKey, Action> keyPressActions = new() { };
        public ConsoleKey? pressedKey = ConsoleEvents.GetKey();
        public bool isAnyKeyPressed = false;

        public KeyManager(Dictionary<ConsoleKey, Action>? keyOrActionDictionary = null) { if (keyOrActionDictionary != null) { keyPressActions = keyOrActionDictionary; } }

        public void Update()
        {
            if (Console.KeyAvailable)
            {
                isAnyKeyPressed = true;

                pressedKey = ConsoleEvents.GetKey();

                foreach (var keyAndAction in keyPressActions)
                {
                    if (pressedKey == keyAndAction.Key) { keyAndAction.Value(); }

                }
            }
            else
            {
                isAnyKeyPressed = false;
            }
        }

        public static void ClearKeyPressBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }

}
