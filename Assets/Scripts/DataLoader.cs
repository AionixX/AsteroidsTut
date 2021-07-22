using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class DataLoader
{
   static string path = "/player.data";
    public static HighScore LoadData()
    {
        string path = Application.persistentDataPath + DataLoader.path;

        if (File.Exists(path))
        {
            // File.Delete(path);
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            HighScore data = formatter.Deserialize(stream) as HighScore;
            stream.Close();
            return data;
        }

        Debug.Log("Load - LOADED PLAYER COMPLETED");
        return new HighScore();
    }

    public static void SaveData(HighScore data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + DataLoader.path;
        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Save - COMPLETED");
    }
}
