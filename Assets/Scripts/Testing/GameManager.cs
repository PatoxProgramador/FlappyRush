using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    void Start()
    {

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
