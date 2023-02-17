using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCClass
{
    //all the data which the NPC needs to have
    public int hitPoints;
    public float movementSpeed;
    public bool playerAlly;
    public float attackDistance;
    public float followDistance;

    public GameObject npc;
    public GameObject player = GameObject.FindWithTag("Player");
    public Rigidbody2D rb;


    

    //Constructor for creating new NPCs
    public NPCClass(int hp, float ms, bool ally, float ad, float fd, GameObject npc) {
        hitPoints = hp;
        movementSpeed = ms;
        playerAlly = ally;
        attackDistance = ad;
        followDistance = fd;
        this.npc = npc;
        rb = npc.GetComponent<Rigidbody2D>();
    }


    public void Jump()
    {
        //Add upwards velocity
        rb.velocity = new Vector2(0, 10);
    }

    public void Follow(GameObject target)
    {
        //Basic movement code; to be improved in the future
        //If the npc is to the right of the target, move right
        //Likewise with left
        if (target.gameObject.transform.position.x > npc.transform.position.x)
        {
            rb.AddForce(new Vector2(movementSpeed, 0));
        }
        else if (target.gameObject.transform.position.x < npc.transform.position.x)
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

    //this method is where the NPC will decide what functions to use.
    public void Behavior()
    {
        //right now following only the player player, ideally will follow the nearest ally/enemy based on its ally boolean
        Follow(player);
        if (Vector2.Distance(npc.transform.position, player.transform.position) < attackDistance)
        {
            Attack();
        }
    }
    

}
