using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int highScore;
    public string currentPlayerName;
    public string highPlayerName;
    public bool gameOver=false;
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
        LoadBestScore();
    }
   
    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {

        }
        
    }

    [System.Serializable]
    class SaveData
    {
        public int highScore;
        public string highPlayerName;
    }

    public void SaveBestScore()
    {
        SaveData data = new SaveData();
        data.highScore = highScore;
        data.highPlayerName = highPlayerName;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScore = data.highScore;
            highPlayerName= data.highPlayerName;
        }
    }
}
