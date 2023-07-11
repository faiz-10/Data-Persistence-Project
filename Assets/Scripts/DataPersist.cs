using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class DataPersist : MonoBehaviour
{
    // Start is called before the first frame update
    public static DataPersist instance;
    public string playerName;
    public string currentPlayer;
    public int highestScore;

    private void Awake()
    {
        if(instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int highestScore;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.highestScore = highestScore;
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            playerName = data.playerName;
            highestScore = data.highestScore;
        }
    }
}
