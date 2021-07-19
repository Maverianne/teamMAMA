using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void Exit()
    {
        Application.Quit();
    }
    public void NPCOne()
    {
        SceneManager.LoadScene(1);
    }
}
