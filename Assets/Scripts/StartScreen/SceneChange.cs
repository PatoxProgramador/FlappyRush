using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    [SerializeField] string SceneName;

    public GameObject pause;

    public Pause scripty;

    public static bool wait;

    void Start()
    {

        //pause script and prefab in titlescreen
        wait = false;
        scripty.enabled = false;
        pause.SetActive(false);

    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {

            scripty.Paused();

        }

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

        scripty.Paused();

    }

}
