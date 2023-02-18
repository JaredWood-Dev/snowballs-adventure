using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public AudioSource audioSrc;
    public void StartGame()
    {
        Debug.Log("Game Started!");
        audioSrc.Play();
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitGame()
    {
        Debug.Log("Game Exited!");
        audioSrc.Play();
        Application.Quit();
    }
}
