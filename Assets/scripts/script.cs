using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class script : MonoBehaviour
{
    public Button newGameButton;

    public Button loadButton;

    public Button exitGameButton;

    public Button Settings;

    public Button Back;

    public string newGameSceneName;

    public GameObject loadGameMenu;

    public GameObject mainMenu;

    public GameObject settings;


    void Start()
    {
    }

    void Update()
    {
    }


    public void OpenMainMenu()
    {       
            mainMenu.SetActive(true);
           
    }

    public void OpenSettings ()
    {
        settings.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(newGameSceneName);
    }

    public void OpenLoadGameMenu()
    {
        loadGameMenu.SetActive(true);
    }

    public void back()
    {
        gameObject.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
