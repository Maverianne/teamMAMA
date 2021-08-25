using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    public GameObject bye;
    public GameObject settings;
    public GameObject menu;

    [SerializeField] private AudioSource click;
    public Slider musicSlider;
    public Slider SFXSlider;

    [SerializeField] private bool startScreen;
    [SerializeField]private bool reloadWait = false;
    //For Pause
    public bool pause;
    private void Awake()
    {
        intance = this;
    }
    private void Start()
    {
        reloadWait = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !startScreen)
        {
            GameMenu();
        }
        if (reloadWait) {
            Reload();
        }
  

    }
    public void Exit()
    {
        click.Play();
        Application.Quit();
        Debug.Log("quitting");
    }
    public void NPCOne(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
    public void Credits()
    {
        bye.SetActive(true);
        StartCoroutine(ReloadTime());
    }
    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(0);
        }
    }


    public void SettingsMenu()
    {
        Click();
        settings.SetActive(true);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume", 1f);
    }
    public void CloseSetting()
    {
        Click();
        StartCoroutine(SettingsWait());

    }
    public void Click()
    {
        click.Play();
    }
    public void GameMenu()
    {
        Click();
        StartCoroutine(GameMenuWait());
    }

    public IEnumerator GameMenuWait()
    {
        yield return new WaitForSeconds(.2f);
        if (menu)
        {
            menu.SetActive(!menu.activeSelf);
        }
        pause = !pause;
        settings.SetActive(false);
    }
    public IEnumerator SettingsWait()
    {
        yield return new WaitForSeconds(.2f);
        settings.SetActive(false);
    }
    public IEnumerator ReloadTime()
    {
        yield return new WaitForSeconds(.5f);
        reloadWait = true;
    }
}
