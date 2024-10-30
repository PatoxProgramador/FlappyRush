using Unity.VisualScripting;
using UnityEngine;

public class PortalLocks : MonoBehaviour
{

    public GameObject[] padlock;//enemies

    public GameObject key;

    void Start()
    {

        key.SetActive(false);
        
    }

    void Update()
    {

        OpenSesame(padlock,key);    
        
    }

    public void OpenSesame(GameObject[] collectables, GameObject prize)
    {

        int j = 0;

        for (int i = 0; i < collectables.Length; i++)
        {

            if (collectables[i] == null)
            {

                j++;

            }
            if (j == collectables.Length)
            {

                prize.SetActive(true);

            }

        }

    }

}
