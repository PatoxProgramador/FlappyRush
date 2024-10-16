using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string SceneName;

    public GameObject pause;
    public Pause script;

    public static bool wait;
    
    void Start()
    {
        //pause script and prefab in titlescreen
        wait = false;
        script.enabled = false;
        pause.SetActive(false);

    }

    void Update()
    {
        
    }

    public void StartButton()
    {

        SceneManager.LoadScene(SceneName);

    }

    public void QuitButton()
    {

        #if UNITY_EDITOR

            UnityEditor.EditorApplication.isPlaying = false;

        #endif

            Application.Quit();

    }

    public void OptionsButton()
    {

        pause.SetActive(true);
        script.enabled = true;
        wait = true;
        Pause.isPaused = true;

    }

}
