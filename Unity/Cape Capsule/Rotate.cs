using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float speedX;
    [SerializeField] float speedY;
    [SerializeField] float speedZ;

    void Update()
    {
    //rotate the selected item a total 360 degree multiplied with the desired speed in all dimensions irrespective of frame rate 
        transform.Rotate(360*speedX*Time.deltaTime, 360*speedY*Time.deltaTime, 360*speedZ*Time.deltaTime);
    }
}
