using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
//Adding a namespace so we can access the SceneManager and reload the game

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] AudioSource deathSound;
    Boolean Dead=false;
    private void Update()
    {
        if(transform.position.y<-1f && !Dead)
        {
            Die();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy Body"))
        {
            GetComponent<MeshRenderer>().enabled = false; //WOOSH, will disappear like magix~~
            GetComponent<Rigidbody>().isKinematic = true; //by enabling isKinematic in the rigid body component we disable the player to affected by the physics
            GetComponent<PlayerMovement>().enabled = false;
            Die();
        }
    }

        void Die()
        {
            //why is it that when I reload my level, it's lighting doesn't change but other people's does....?
            Invoke(nameof(ReloadLevel), 1.3f); //the time delay is 1.3 seconds because I liked the value...Because why not~
            Dead = true;
            deathSound.Play();
            //we could have also used Destroy() inbuilt function but it will also remove the Player life script. 

        }
    
    //why is it that when this function was in the if statement block it did not work it's reference in Invoke but...
    //when I got it out, it magically started working with the Invoke. What sorcery is this??
    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
