using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Adding a namespace so we can access the SceneManager and reload the game

public class NewBehaviourScript : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Body"))
        {
            Die();
        }

        void Die()
        {
            GetComponent<MeshRenderer> ().enabled = false; //WOOSH, will disappear like magix~~
            GetComponent<Rigidbody>().isKinematic = true; //by enabling isKinematic in the rigid body component we disable the player to affected by the physics
            GetComponent<PlayerMovement> ().enabled = false;
            Invoke(nameof(ReloadLevel), 0.9f); //the time delay is 1.3 seconds because I liked the value...Because why not~

            //we could have also used Destroy() inbuilt function but it will also remove the Player life script. 

        }

        void ReloadLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
