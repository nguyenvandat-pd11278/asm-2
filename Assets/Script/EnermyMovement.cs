using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] int health = 20;
    Rigidbody2D myRigidbody;
    Animator anim;
    

    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        FlipDriection();
    }

    void Update()
    {
        myRigidbody.velocity = new Vector2(moveSpeed, 0f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet"))
        {
            FlipDriection();
        }
    }

    void FlipDriection ()
    {
        moveSpeed = -moveSpeed;
        FlipEnemyFacing();
    }

    void FlipEnemyFacing()
    {
        transform.localScale = new Vector2((Mathf.Sign(myRigidbody.velocity.x)), 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health -= 1;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
}
