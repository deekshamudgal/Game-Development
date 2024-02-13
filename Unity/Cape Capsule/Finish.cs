using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name=="Player")
        {
            //buildIndex refers to the build settings in the Unity we added our levels to in form of a checked list 
            //LoadScene is overloaded and thus can take different types of arguments and understands the difference between them
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
