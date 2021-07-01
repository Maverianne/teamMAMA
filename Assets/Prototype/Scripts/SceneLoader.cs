using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadAndy()
    {
    	SceneManager.LoadScene("Andy");
    }

    public void LoadMegan()
    {
    	SceneManager.LoadScene("Megan");
    }

    public void LoadMenu()
    {
    	SceneManager.LoadScene("MainMenu");
    }
}
