using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager intance;
    public GameObject bye;

    private void Awake()
    {
        intance = this; 
    }
    public void Exit()
    {
        Application.Quit();
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
            SceneManager.LoadScene(1);
        }
    }
}
