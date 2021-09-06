using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif



public class Menu : MonoBehaviour
{
    private string playerName;
    public Text bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        playerName = GameManager.Instance.highPlayerName;
        DisplayBestPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void DisplayBestPlayer()
    {
        bestScoreText.text = $"Best Score : {GameManager.Instance.highPlayerName}  {GameManager.Instance.highScore}";
    }
    public void startNew()
    {
        SceneManager.LoadScene(1);
    }
    
    public void ExitGame()
    {
        #if UNITY_EDITOR
                EditorApplication.ExitPlaymode();
        #else
                Application.Quit(); // original code to quit Unity player
        #endif
    }
    public void PlayerNameInput(string name)
    {
        playerName = name;
        GameManager.Instance.currentPlayerName = playerName;
    }

}
