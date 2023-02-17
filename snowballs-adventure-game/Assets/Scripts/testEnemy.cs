using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testEnemy : NPCClass
{
    private Rigidbody2D rb;
    public GameObject player;

    public float attackDistance;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Jump(rb);
    }

    // Update is called once per frame
    void Update()
    {
        Follow(player, rb);
        if (Vector2.Distance(transform.position, player.transform.position) < attackDistance)
        {
            Attack();
        }
    }
}
