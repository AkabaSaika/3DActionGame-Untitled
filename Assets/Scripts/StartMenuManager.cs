using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuManager : MonoBehaviour
{
    private Button startGameButton;
    private Button optionButton;
    private Button quitGameButton;
   
    void Start()
    {
        startGameButton = GameObject.Find("StartGame").GetComponent<Button>();
        optionButton = GameObject.Find("Option").GetComponent<Button>();
        quitGameButton = GameObject.Find("QuitGame").GetComponent<Button>();
        startGameButton.onClick.AddListener(StartGame);
        optionButton.onClick.AddListener(Option);
        quitGameButton.onClick.AddListener(QuitGame);
    }

    private void StartGame()
    {
        SceneManager.LoadScene("Stage1");
    }

    private void Option()
    {
        Debug.Log("option");
    }

    private void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }


}
