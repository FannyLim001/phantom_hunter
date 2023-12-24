using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ResultManager : MonoBehaviour
{
    public TMP_Text timestamp;
    public Image rating;
    public TMP_Text ratingText;

    public Sprite [] ratingStar;

    // Start is called before the first frame update
    void Start()
    {
        float time = GameManager.Instance.elapsedTime;
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timestamp.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        if (time <= 60) // Less than or equal to 1:00
        {
            rating.sprite = ratingStar[0];
            ratingText.text = "Perfect";
        }
        else if (time <= 110) // Less than or equal to 1:50
        {
            rating.sprite = ratingStar[1];
            ratingText.text = "Good";
        }
        else // Greater than 1:50
        {
            rating.sprite = ratingStar[2];
            ratingText.text = "Not Bad";
        }
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("StartMenu");
    }
}
