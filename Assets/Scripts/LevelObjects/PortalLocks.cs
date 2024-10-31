using Unity.VisualScripting;
using UnityEngine;

public class PortalLocks : MonoBehaviour
{

    public GameObject[] padlock;//enemies

    public GameObject[] key;//Revealing next junk

    public LevelManager levelPuzzle;

    void Start()
    {

        foreach (GameObject keychain in key)
        {

            keychain.SetActive(false);

        }
            
    }

    void Update()
    {

        OpenSesame(padlock,key);    
        
    }

    public void OpenSesame(GameObject[] collectables, GameObject[] prize)
    {
        
        int j = 0;

        for (int i = 0; i < collectables.Length; i++)
        {
            // checks if everything is null
            if (collectables[i] == null)
            {

                j++;

            }
            if (j == collectables.Length)
            {
                //only if every element is null next step is revealed
                foreach (GameObject lottery in prize)
                {

                    lottery.SetActive(true);

                }

            }//else it restarts the loop again

        }

    }

}
