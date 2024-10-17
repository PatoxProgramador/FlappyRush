using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject canvas;
    public GameObject resumeButton; 

    public string sceneName;

    public static bool isPaused;

    void Start()
    {

    }

    void Update()
    {

        Time.timeScale = 0.0f;

        if (sceneName.Equals("TitleScreen"))
        {

            resumeButton.SetActive(false);

        }
        else
        {

            resumeButton.SetActive(true);

        }
       //prvents pause from coming out in beggining of game - start scene
        if (SceneChange.wait && sceneName.Equals("TitleScreen"))
        {

            canvas.SetActive(false);

        }

    }

    public void BackButton()
    {

        if (sceneName.Equals("TitleScreen"))
        {

            //start scene goes back to cover of game
            canvas.SetActive(true);

        }  
        
        UnPaused();

    }

    public void Paused()
    {

        gameObject.SetActive(true);
        enabled = true;

        isPaused = true;
        SceneChange.wait = true;
        Time.timeScale = 0.0f;

    }
    public void UnPaused()
    {

        gameObject.SetActive(false);
        enabled = false;
        SceneChange.wait = false;

        Time.timeScale = 1.0f;
        isPaused = false;

    }

    public void BackToMenu()
    {

        UnPaused();
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("TitleScreen");

    }

}
