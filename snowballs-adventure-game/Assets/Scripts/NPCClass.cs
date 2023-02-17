using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass : MonoBehaviour
{
    public int hitPoints;
    public float movementSpeed;
    public bool playerAlly;

    public void Jump(Rigidbody2D rb)
    {
        //Add upwards velocity
        rb.velocity = new Vector2(0, 10);
    }

    public void Follow(GameObject target, Rigidbody2D rb)
    {
        //Basic movement code; to be improved in the future
        //If the npc is to the right of the target, move right
        //Likewise with left
        if (target.gameObject.transform.position.x > transform.position.x)
        {
            rb.AddForce(new Vector2(movementSpeed, 0));
        }
        else if (target.gameObject.transform.position.x < transform.position.x)
        {
            rb.AddForce(new Vector2(-movementSpeed, 0));
        }
    }

    public void Attack()
    {
        //Make an attack based on the ability system
        //-Basic Attack
        //-Ranged Attack
        Debug.Log("Attack");
    }
}
