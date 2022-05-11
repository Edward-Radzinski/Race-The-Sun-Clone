using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void GameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void MenuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void ApplicationExit()
    {
        Application.Quit();
    }
}
