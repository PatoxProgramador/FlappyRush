using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public GameObject gameOverMenu;

    private void OnEnable() {
        PlayerHealth.onPlayerDeath += EnableGameOverMenu;
    }

    private void OnDisable() {
        PlayerHealth.onPlayerDeath -= EnableGameOverMenu;
    }

    public void EnableGameOverMenu()
    {
        gameOverMenu.SetActive(true);
    }
     public void RestartLevel()
     {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
     }

     public void BackToMainMenu()
     {
        SceneManager.LoadScene(0);
     }
}

