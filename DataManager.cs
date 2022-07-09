using System;
using System.Text;
using System.IO;
using System.Text.Json;

namespace KillTheZGame
{
    static class DataManager
    {
        public static JSONData data;

        public static string dataFileName = "KTZData.json";

        public static void CreateData()
        {
            data = new JSONData
            {
                score = 0,
                virtualTime = new DateTime(2022, 4, 24),
                warStartVirtualTime = new DateTime(2014, 2, 20),
                currentCityIndex = 3,
                languageIndex = 0,
                themeIndex = 0
            };
        }

        public static void RestartData()
        {
            CreateData();
            File.WriteAllText(dataFileName, JsonSerializer.Serialize(data));
            LoadData();
        }

        public static void SaveData()
        {
            data.score = GameData.score;
            data.virtualTime = GameData.virtualTime;
            data.warStartVirtualTime = GameData.warStartVirtualTime;
            data.currentCityIndex = GameData.currentCityIndex;
            data.languageIndex = GameData.settingsMenu.itemList[0].selectedIndex;
            data.themeIndex = GameData.settingsMenu.itemList[1].selectedIndex;

            File.WriteAllText(dataFileName, JsonSerializer.Serialize(data));
        }

        public static void LoadData()
        {
            if (File.Exists(dataFileName))
            {
                data = JsonSerializer.Deserialize<JSONData>(File.ReadAllText(dataFileName));
            }
            else { CreateData(); }

            GameData.score = data.score;

            GameData.virtualTime = data.virtualTime;

            GameData.warStartVirtualTime = data.warStartVirtualTime;

            GameData.currentCityIndex = data.currentCityIndex;

            GameData.settingsMenu.itemList[0].selectedIndex = data.languageIndex;
            GameData.settingsMenu.itemList[0].variants[GameData.settingsMenu.itemList[0].selectedIndex].selectAction();

            GameData.settingsMenu.itemList[1].selectedIndex = data.themeIndex;
            GameData.settingsMenu.itemList[1].variants[GameData.settingsMenu.itemList[1].selectedIndex].selectAction();
        }
    }

    public class JSONData
    {
        public int score { get; set; }

        public DateTime virtualTime { get; set; }
        public DateTime warStartVirtualTime { get; set; }

        public int currentCityIndex { get; set; }

        public int languageIndex { get; set; }
        public int themeIndex { get; set; }
    }
}
