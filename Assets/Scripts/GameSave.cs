using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSave : MonoBehaviour {

    public int HighScore;

    public void Save()
    {
        SaveLoadManager.Save(this);
    }

    public void Load()
    {
        int loadedScore = SaveLoadManager.Load();

        HighScore = loadedScore;
    }

}
