using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
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

        GameManager.revived = true;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

     public void BackToMainMenu()
     {
        SceneManager.LoadScene(0);
     }
}

