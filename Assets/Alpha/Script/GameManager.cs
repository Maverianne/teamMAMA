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

    [SerializeField]private AudioSource click;

    public Slider musicSlider;
    public Slider SFXSlider;

    [SerializeField]private bool startScreen;

    //For Pause
    public bool pause;
    private void Awake()
    {
        intance = this; 
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !startScreen) 
        {
            GameMenu();
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
        Reload();
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
        settings.SetActive(false);
    }
    public void Click()
    {
        click.Play();
    }
    public void GameMenu()
    {
        Click();
        if (menu)
        {
            menu.SetActive(!menu.activeSelf);
        }
        pause = !pause;
    }
}
