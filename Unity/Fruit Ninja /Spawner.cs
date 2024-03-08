using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//the base class derives itself from MonoBehavior, so that it can attach itself to a said game object
public class Spawner : MonoBehaviour
{
    private Collider spawnArea;

    public GameObject[] fruitPrefabs;

    //between what time duration range the fruits will start spawning
    public float minSpawnDelay = 0.25f;
    public float maxSpawnDelay = 1f;

    public float minAngle = -15f;
    public float maxAngle = 15f;

    public float minForce = 18f;
    public float maxForce = 22f;

    //the amount of time duration a fruit will remain on the screen before falling off
    //after falling off, we destroy the fruit once it's out of the user's game area
    public float maxLifeTime = 5f;

    private void Awake()
    {
        //GetComponent gives reference to the box collider below our scene 
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        //StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    //what is an IEnumerator and why have I not heard of it before??! 
     //private IEnumerator Spawn()
   
