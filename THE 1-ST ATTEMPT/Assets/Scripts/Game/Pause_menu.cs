using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_menu : MonoBehaviour
{
    public Button pause, inMain, resume;
    public GameObject bg_white, menuPause;
    private Animator bg_white_anim;

    private void Awake()
    {
        pause.onClick.AddListener(PauseMenu);
        inMain.onClick.AddListener(inMainMenu);
        resume.onClick.AddListener(Resume);
        bg_white_anim = bg_white.GetComponent<Animator>();
    }

    private void PauseMenu()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 0f;
        menuPause.SetActive(true);
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
        FindObjectOfType<AudioManager>().Play("Click");
        Time.timeScale = 1f;
        menuPause.SetActive(false);
    }

}
