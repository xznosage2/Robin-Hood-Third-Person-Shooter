using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    public void TargetPracticeOpen()
    {
        SceneManager.LoadScene("Test Scene");
    }

    public void ZombiesOpen()
    {
        SceneManager.LoadScene("Waiting For Players");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
}
