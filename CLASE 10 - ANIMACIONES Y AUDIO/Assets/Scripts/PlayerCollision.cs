using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log(name + " COLISION CON " + other.gameObject.name);
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            Debug.Log("GAME OVER");
        }

    }

    private void OnCollisionExit(Collision other)
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(name + " Tigger con" + other.gameObject.name);
        Destroy(other.gameObject);
    }
}
