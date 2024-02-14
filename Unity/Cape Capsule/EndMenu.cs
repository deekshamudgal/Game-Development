using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndMenu : MonoBehaviour
{
    public void QuitGame()
    {
        //in the play mode of a game Engine it will do nothing but for when played on a device it will close the said application 
        Application.Quit();
    }
}
