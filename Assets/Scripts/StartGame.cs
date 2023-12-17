using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private void Start()
    {
        BGMusic.instance.GetComponent<AudioSource>().Play();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("ChoosePlayer");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
