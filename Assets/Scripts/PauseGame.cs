using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public static bool isGamePaused = false;
    public GameObject pauseMenuUI;
    public GameObject player;
    AudioSource[] audios;
    private void Start() 
    {
        audios = player.GetComponents<AudioSource>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                Resume();
            }else
            {
            Pause();
            }
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        isGamePaused = false;
        player.GetComponent<PlayerMovement>().enabled = true;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        isGamePaused = true;
        player.GetComponent<PlayerMovement>().enabled = false;
        foreach(AudioSource a in audios)
        {
            a.Pause();
        }
    }
}
