using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillSurfaceController : MonoBehaviour
{
    private int counter = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            counter++;
            if(counter > 1)
            {
                SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
            }
        }
    }
}
