using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Awake()
    {

        GameObject[] immortalManager = GameObject.FindGameObjectsWithTag("GameManager");

        if (immortalManager.Length > 1)
        {

            Destroy(this.gameObject);

        }

        DontDestroyOnLoad(this.gameObject);

    }

    void Update()
    {
        
    }

}
