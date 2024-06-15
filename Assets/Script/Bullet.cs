using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Map"))
        {
            Debug.Log("CUT");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Trap"))
        {
            Debug.Log("Cut");
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Enemy"))
        {
            Debug.Log("CHET ME MAY DI");
            EnermyMovement enemy = collision.GetComponent<EnermyMovement>();
            if(enemy != null)
            {
                enemy.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}
   
     