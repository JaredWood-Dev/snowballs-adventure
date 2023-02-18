using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animate : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private const float scaleX = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (rb.velocity.x > 0.1)
        {
            anim.SetBool("isMoving", true);
            transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z);
        }
        else if (rb.velocity.x < -0.1)
        {
            anim.SetBool("isMoving", true);
            transform.localScale = new Vector3(-scaleX, transform.localScale.y, transform.localScale.z);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }
}
