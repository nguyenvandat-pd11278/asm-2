using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameObject bulletPrefrab;
    public float fireRate = 1f;
    private float fireTimer;
    void Start()
    {

    }

    void Update()
    {
        fireTimer += Time.deltaTime;

        if (fireTimer >= 1f / fireRate)
        {
            Instantiate(bulletPrefrab, gameObject.transform.position, Quaternion.identity);
            fireTimer = 0f;
        }
    }
}
