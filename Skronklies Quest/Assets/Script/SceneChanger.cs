using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void Play()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void Win()
    {
        SceneManager.LoadScene("EndScene");
    }

    public void Quit()
    {
        Application.Quit();
    }

}
