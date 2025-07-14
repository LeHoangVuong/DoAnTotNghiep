using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    public static Gamemanager game;
    void Awake()
    {
        if (game != null && game != this)
        {
            Destroy(this);
        }
        else
        {
            game = this;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Gameover()
    {
        UIplayer.ui.gameoverpanel.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Game");
        Time.timeScale = 1f;
    }
    public void Pause()
    {
        if (UIplayer.ui.pausepanel.activeSelf == false)
        {
            UIplayer.ui.pausepanel.SetActive(true) ;
            Time.timeScale = 0f;
        }
        else
        {
            UIplayer.ui.pausepanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void gotomenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
