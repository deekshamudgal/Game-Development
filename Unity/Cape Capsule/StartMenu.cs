using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        //the start and end menu will have no lighting settings in them, because we only have the canvas to work with
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
}
