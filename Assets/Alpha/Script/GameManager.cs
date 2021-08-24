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

    [SerializeField]private AudioSource click;

    public Slider musicSlider;
    public Slider SFXSlider;

    private void Awake()
    {
        intance = this; 
    }
    private void Update()
    {
        if (bye)
        {
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
        CharacterController2D.instance.speed = 0;
        CharacterController2D.instance.anim.SetBool("isMoving", false);
        bye.SetActive(true);
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
}
