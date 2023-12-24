using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public float totalNormalEnemy = 10;

    public GameObject Player;
    public GameObject MaleMC;
    public GameObject FemaleMC;
    public GameObject Enemy;
    public GameObject Boss;
    public GameObject NormalEnemy;
    public GameObject BossEnemy;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;
    public TMP_Text timer;
    public float elapsedTime;

    public AudioSource normalMusic;
    public AudioSource bossMusic;

    private GameObject playerInstance;
    private bool bossSpawn = false;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        BGMusic.instance.GetComponent<AudioSource>().Stop();

        string characterGender = PlayerPrefs.GetString("CharacterGender");

        if (characterGender == "Male")
        {
            playerInstance = Instantiate(MaleMC);
        }
        else if (characterGender == "Female")
        {
            playerInstance = Instantiate(FemaleMC);
        }

        // Set the instantiated as a child of the Player
        playerInstance.transform.SetParent(Player.transform);

        // Reset local position to zero (optional, depending on your needs)
        playerInstance.transform.localPosition = Vector3.zero;

        for (int i = 0; i < totalNormalEnemy; i++)
        {
            GameObject normalEnemyInstance = Instantiate(NormalEnemy);

            normalEnemyInstance.transform.SetParent(Enemy.transform);
            normalEnemyInstance.transform.localPosition = new Vector3 (2, 2.5f, 0);
        }
    }

    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);
        timer.text = string.Format("{0:00}:{1:00}",minutes,seconds);

        if (Enemy.transform.childCount == 0 && !bossSpawn)
        {
            normalMusic.Stop();
            bossMusic.Play();
            bossSpawn = true;
            GameObject bossEnemyInstance = Instantiate(BossEnemy);
            bossEnemyInstance.transform.SetParent(Boss.transform);
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseMenu.SetActive(true);
    }

    public void Continue()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        bossSpawn = false;

        // Get the index of the current scene
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Reload the current scene
        SceneManager.LoadScene(currentSceneIndex);

        Time.timeScale = 1;
    }


    public void Exit()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("StartMenu");
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameOverMenu.SetActive(true);
    }
}
