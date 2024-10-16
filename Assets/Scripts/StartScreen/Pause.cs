using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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
        if (SceneChange.wait)
        {

            canvas.SetActive(false);

        }
        

    }

    public void BackButton()
    {
        //start scene goes back to cover of game
        canvas.SetActive(true);
        gameObject.SetActive(false);
        enabled = false;
        SceneChange.wait = false;

        Time.timeScale = 1.0f;
        isPaused = false;

    }

}
