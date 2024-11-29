using System.Runtime.Serialization.Formatters.Binary;
using System.Text.Json;

namespace GamePractice
{
    public class GameSaveData
    {
        public string currentStateKey { get; set; }

        public GameSaveData(string currentStateKey)
        {
            this.currentStateKey = currentStateKey;
        }
    }
    class SaveGame
    {
        private static string filePath = @"saves\gameSaves.txt";

        public static void SaveState(GameSaveData gameData)
        {
            if (!Directory.Exists(@"saves"))
            {
                Directory.CreateDirectory(@"saves");
            }

            // Serialize the game data to JSON and save it to a file
            string jsonString = JsonSerializer.Serialize(gameData);
            File.WriteAllText(filePath, jsonString);
            Console.WriteLine($"Game Saved");

        }
        public static GameSaveData LoadState()
        {
            if (File.Exists(filePath))
            {
                //Read the JSON string from the file and deserialize it to GameSaveData
                string jsonString = File.ReadAllText(filePath);
                GameSaveData loadedData = JsonSerializer.Deserialize<GameSaveData>(jsonString);
                Console.WriteLine($"Game Loaded: {loadedData.currentStateKey}");
                return loadedData;
            }
            else
            {
                Console.WriteLine("No Saved Data");
                return null;
            }
        }

    }
}
