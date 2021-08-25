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

    //for transition-------------------
    public Animator transitionAnimation;
    public float transitionTime = 1f;
    //---------------------------------

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
    

    //THIS IS WHERE WE TRIGGER THE TRANSITION-----------------------------

    //public void ChangeScene(int sceneNumber)
    //{
    //    SceneManager.LoadScene(sceneNumber);
    //}

    public void ChangeScene(int sceneNumber)
    {
        StartCoroutine(transition(sceneNumber));
    }

    IEnumerator transition (int sceneNumber)
    {
        //trigger anim
        transitionAnimation.SetTrigger("trans");

        //wait
        yield return new WaitForSeconds(transitionTime);

        //scene change
        SceneManager.LoadScene(sceneNumber);
    }

    //END OF VOID WE NEED TO USE FOR TRANSITION--------------------------


    public void Credits()
    {
        bye.SetActive(true);
        StartCoroutine(ReloadTime());
    }
    public void Reload()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ChangeScene(0);
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
