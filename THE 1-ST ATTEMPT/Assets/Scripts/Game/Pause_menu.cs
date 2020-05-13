using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public Button pause, inMain, resume/*, settings*/;
    public GameObject bg_white, menuPause/*, countdown*/;
    private Animator bg_white_anim, readyToPlay_anim;

    private void Awake()
    {
        pause.onClick.AddListener(PauseMenu);
        inMain.onClick.AddListener(inMainMenu);
        resume.onClick.AddListener(Resume);
        //settings.onClick.AddListener(); меню стат
        bg_white_anim = bg_white.GetComponent<Animator>();
       // readyToPlay_anim = countdown.GetComponent<Animator>();
    }

    private void PauseMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 0f;
        menuPause.SetActive(true);
        //menu всплывает
        //
    }

    private void inMainMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        bg_white_anim.enabled = true;
        menuPause.SetActive(false);
        Time.timeScale = 1f;
        StartCoroutine(Scores.BgWhite());
    }

    private void Resume()
    {
        //уходит menu
        // readyToPlay_anim.enabled = true;
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }
}
