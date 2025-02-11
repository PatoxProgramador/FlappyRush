using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static bool revived = false;

    void Start()
    {

        GameObject[] manager = GameObject.FindGameObjectsWithTag("GameManager");

        if (manager.Length >1)
        {

            Destroy(this.gameObject);

        }

        DontDestroyOnLoad(this.gameObject);
        //counter scene is here
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
        //Scene keeps track of the scene its on, to player can know where to spawn in each scene
        private void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
        {

            //player destroys itself
            if (scene.name == "TitleScreen")
            {

                SceneManager.sceneLoaded -= OnSceneLoaded;
                GameObject.Destroy(this.gameObject);

            }

        }

   }
