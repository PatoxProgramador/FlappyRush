using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{

    public string SceneName;
    
    void Start()
    {
        
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

}
