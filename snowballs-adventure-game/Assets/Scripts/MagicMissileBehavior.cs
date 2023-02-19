using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicMissileBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    Transform tr;

    GameObject[] enemies;
    GameObject closest;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();

        

        rb.AddForce(Vector2.up * 150);
    }

    // Update is called once per frame
    void Update()
    {
        closest = FindClosestEnemy();
        float hforce = 400 * Time.deltaTime;
        float vforce = 300 * Time.deltaTime;
        if (closest.transform.position.x > tr.position.x)
        {
            rb.AddForce(Vector2.right * hforce);
            if (rb.velocity.x > 300)
            {
                rb.velocity = new Vector2(300, rb.velocity.y);
            }
        }
        else
        {
            rb.AddForce(Vector2.left * hforce);
            if (rb.velocity.x < -300)
            {
                rb.velocity = new Vector2(-300, rb.velocity.y);
            }
        }
        if (closest.transform.position.y > tr.position.y)
        {
            rb.AddForce(Vector2.up * vforce);
            if (rb.velocity.y > 300)
            {
                rb.velocity = new Vector2(rb.velocity.x, 300);
            }
        }
        else
        {
            rb.AddForce(Vector2.down * vforce);
            if (rb.velocity.y < -300)
            {
                rb.velocity = new Vector2(rb.velocity.x, -300);
            }
        }

    }


    public GameObject FindClosestEnemy()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        
        float distance = Mathf.Infinity;
        Vector3 position = tr.position;
        foreach (GameObject enemy in enemies)
        {
            Vector3 diff = enemy.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = enemy;
                distance = curDistance;
            }
        }
        return closest;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
        if (col.collider.tag == "Ground")
        {
            //maybe add particles here
            Destroy(gameObject);
        }
        else if (col.collider.tag == "Enemy")
        {
            Debug.Log("DamageEnemy");
            Destroy(gameObject);
        }
        
    }

}
