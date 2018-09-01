using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class SaveLoadManager {

    public static void Save(GameSave gs)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/GameSave.tcl", FileMode.Create);

        GameDate data = new GameDate(gs);

        bf.Serialize(stream, data);
        stream.Close();
    }

    public static int Load()
    {
        if (File.Exists(Application.persistentDataPath + "/GameSave.tcl"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/GameSave.tcl", FileMode.Open);

            GameDate date = bf.Deserialize(stream) as GameDate;

            stream.Close();
            return date.HighScore;
        } else
        {
            Debug.LogError("File does not exist.");
            return 0;
        }
    }

}

[Serializable]
public class GameDate{

    public int HighScore;

    public GameDate(GameSave gs)
    {
        HighScore = gs.HighScore;
    }
}
