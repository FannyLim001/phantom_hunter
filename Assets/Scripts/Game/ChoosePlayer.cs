using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChoosePlayer : MonoBehaviour
{
    public string PlayerGender;

    public void ChooseMaleMC()
    {
        PlayerGender = "Male";
        PlayerPrefs.SetString("CharacterGender", PlayerGender);
        // Load the "Game" scene
        SceneManager.LoadScene("Game");
    }

    public void ChooseFemaleMC()
    {
        PlayerGender = "Female";
        PlayerPrefs.SetString("CharacterGender", PlayerGender);
        // Load the "Game" scene
        SceneManager.LoadScene("Game");
    }
}
