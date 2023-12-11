using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject MaleMC;

    // Start is called before the first frame update
    void Awake()
    {
        BGMusic.instance.GetComponent<AudioSource>().Stop();

        string characterGender = PlayerPrefs.GetString("CharacterGender");
        if(characterGender == "Male")
        {
            Instantiate(MaleMC);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
