using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public GameObject canvas;
    public GameObject backButton;

    public string sceneName;

    public static bool isPaused;

    void Start()
    {

        UnPaused();

    }

    void Update()
    {

        Time.timeScale = 0.0f;
        
        if (sceneName.Equals("TitleScreen"))
        {

            backButton.SetActive(false);

        }
        else
        {

            backButton.SetActive(true);
        
        }
        
       //prvents pause from coming out in beggining of game - start scene
        if (SceneChange.wait && sceneName.Equals("TitleScreen"))
        {

            canvas.SetActive(false);

        }

    }

    public void BackButton()
    { 
        
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

        if (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Return))
        {

            gameObject.SetActive(false);
            enabled = false;
            SceneChange.wait = false;

            Time.timeScale = 1.0f;
            isPaused = false;

        } 

        if (sceneName.Equals("TitleScreen"))
        {

            //start scene goes back to cover of game
            canvas.SetActive(true);

        }

    }

    public void BackToMenu()
    {

        UnPaused();
        SceneManager.LoadScene("TitleScreen");

    }

}
