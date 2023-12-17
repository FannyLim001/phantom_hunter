using System.Collections;
using System.Collections.Generic;
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
    public GameObject NormalEnemy;
    public GameObject PauseMenu;
    public GameObject GameOverMenu;

    private float minX, maxX;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;

        BGMusic.instance.GetComponent<AudioSource>().Stop();

        string characterGender = PlayerPrefs.GetString("CharacterGender");
        if(characterGender == "Male")
        {
            GameObject maleMCInstance = Instantiate(MaleMC);

            // Set the instantiated MaleMC as a child of the Player
            maleMCInstance.transform.SetParent(Player.transform);
        } else if(characterGender == "Female")
        {
            GameObject femaleMCInstance = Instantiate(FemaleMC);

            // Set the instantiated Female as a child of the Player
            femaleMCInstance.transform.SetParent(Player.transform);
        }

        TerrainCollider terrainCollider = Enemy.GetComponent<TerrainCollider>();

        if (terrainCollider != null)
        {
            Bounds terrainBounds = terrainCollider.bounds;

            // Set the range for X positions based on the terrain bounds
            float minX = terrainBounds.min.x;
            float maxX = terrainBounds.max.x;

            for (int i = 0; i < totalNormalEnemy; i++)
            {
                GameObject normalEnemyInstance = Instantiate(NormalEnemy);

                // Set the enemy's position to a random position within the specified range
                float randomX = Random.Range(minX, maxX);

                normalEnemyInstance.transform.position = new Vector3(randomX, 0, 0);

                normalEnemyInstance.transform.SetParent(Enemy.transform);
            }
        }
        else
        {
            Debug.LogError("TerrainCollider not found on the Enemy GameObject.");
        }

    }

    // Update is called once per frame
    void Start()
    {
        PauseMenu.SetActive(false);
        GameOverMenu.SetActive(false);
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
