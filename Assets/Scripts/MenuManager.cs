using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuManager : MonoBehaviour
{
    public Text bestScoreText;
    // Start is called before the first frame update
    void Awake()
    {
        bestScoreText.text = $"Best Score: {NameManager.Instance.playerName} : {NameManager.Instance.bestScore}";
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}