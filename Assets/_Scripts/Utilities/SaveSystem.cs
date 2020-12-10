using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using _Scripts.Models;
using UnityEngine;

namespace _Scripts.Utilities
{
    public static class SaveSystem
    {
        public static void SavePlayerData(PlayerData playerData)
        {
            var path = $"{Application.persistentDataPath}/bobo.bin";
            var formatter = new BinaryFormatter();
            var fileStream = new FileStream(path, FileMode.Create);

            formatter.Serialize(fileStream, playerData);
            fileStream.Close();
        }

        public static PlayerData LoadPlayerData()
        {
            var path = $"{Application.persistentDataPath}/bobo.bin";
            
            if (!File.Exists(path))
            {
                Debug.Log("Save file not found.");
                return null;
            }
            
            var formatter = new BinaryFormatter();
            var fileStream = new FileStream(path, FileMode.Open);

            var playerData = formatter.Deserialize(fileStream) as PlayerData;
            fileStream.Close();

            return playerData;
        }

        public static void InitializePlayerData()
        {
            var playerData = new PlayerData(
                reachedSceneIndex: 0,
                selectedSceneIndex: 1,
                coins: 0,
                pickedSkin: 0,
                levels: new List<Level>
                {
                    new Level(1, 3.5f, 4.5f, 0),
                    new Level(2, 1.7f, 3.7f,  0),
                    new Level(3, 4.2f, 5.4f,  0),
                    new Level(4, 7.6f, 9.0f,  0),
                    new Level(5, 4.5f, 7.0f,  0),
                    new Level(6, 4.2f, 6.0f,  0),
                    new Level(7, 4.2f, 5.2f,  0),
                    new Level(8, 4.2f, 6.0f,  0),
                    new Level(9, 2.5f, 4.5f,  0),
                    new Level(10, 2.8f, 4.5f,  0) 
                },
                skins: new List<Skin>
                {
                    new Skin(0,0,false),
                    new Skin(1,2300,true),
                    new Skin(2,5800,true),
                    new Skin(3,12000,true),
                }
            );
            
            SavePlayerData(playerData);
        }
    }
}
