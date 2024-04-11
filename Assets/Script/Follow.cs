using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform target; 
    public float moveSpeed = 3f; 
    public float stoppingDistance = 2f; 

    private Rigidbody2D rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }

        if (target != null)
        {
           
            Vector2 direction = (target.position - transform.position).normalized;

            
            if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
            {
                rb.velocity = direction * moveSpeed; 
            }
            else
            {
                rb.velocity = Vector2.zero; 
            }
        }
    }
} 