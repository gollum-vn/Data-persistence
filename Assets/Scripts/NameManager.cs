using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class NameManager : MonoBehaviour
{
    public static NameManager Instance;
    public string playerName;
    public int bestScore;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void readPlayerName(string input)
    {
        playerName = input;
        Debug.Log(input);
    }
    [System.Serializable]
    class SaveData
    {
        public string PlayerName;
        public int BestScore;
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.PlayerName = playerName;
        data.BestScore = bestScore;
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
        Debug.Log(bestScore);
    }
    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            playerName = data.PlayerName;
            bestScore = data.BestScore;
            Debug.Log("load");
        }
    }
}
