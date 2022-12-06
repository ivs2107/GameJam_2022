using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManagement : MonoBehaviour
{
    GameObject goSound;
    // Start is called before the first frame update
    void Start()
    {
        goSound = GameObject.Find("SoundEffectButton");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonStart()
    {
        goSound.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1, LoadSceneMode.Single); // change the scene
    }
    public void ButtonQuit()
    {
        goSound.GetComponent<AudioSource>().Play();
        Application.Quit();
    }
}
