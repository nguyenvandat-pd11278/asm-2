using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int scoreValue = 10;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force = 10f;
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

    }
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Map")
        {
            Debug.Log("Cut");
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Debug.Log("Enemy destroyed ");
            Destroy(gameObject);
        }
    }

}

