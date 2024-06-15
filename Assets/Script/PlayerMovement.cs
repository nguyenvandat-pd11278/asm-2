using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;
    private BoxCollider2D coll;
    [SerializeField] private LayerMask JumpableGround;
    private float dirX = 0f;
    public float MoveSpeed = 7f;
    public float JumpForce = 14f;
    public Transform SpawPlace;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5f;
    private Vector2 shootDirection;
    private enum MovementState { idel, running, jumping, falling }
    [SerializeField] private AudioSource JumpSoundEffect;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            shootDirection = Vector2.right;
        }else if(Input.GetKeyDown(KeyCode.A))
        {
            shootDirection = Vector2.left;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        dirX = Input.GetAxisRaw("Horizontal"); 
        rb.velocity = new Vector2(dirX * MoveSpeed, rb.velocity.y);
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            JumpSoundEffect.Play();
            rb.velocity = new Vector3(rb.velocity.x, JumpForce);
        }
        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f) 
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idel;
        }
        if(rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        anim.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, JumpableGround);
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bulletPrefab, transform.position,Quaternion.identity);
        Rigidbody2D bulletRb = newBullet.GetComponent<Rigidbody2D>();
        if(bulletRb != null)
        {
            bulletRb.velocity = shootDirection * bulletSpeed;
        }
    }
}
      