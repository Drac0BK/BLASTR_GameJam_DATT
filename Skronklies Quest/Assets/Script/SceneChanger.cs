using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameObject instructions;
    public GameObject story;

    public void Start()
    {
        //SceneManager.LoadScene("PlayScene");
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

    public void Instructions()
    {
        instructions.SetActive(true);
        story.SetActive(false);
    }

    public void Story()
    {
        story.SetActive(true);
        instructions.SetActive(false);
    }

}
