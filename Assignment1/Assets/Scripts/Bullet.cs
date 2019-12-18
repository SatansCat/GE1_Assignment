using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Awake()
    {
        Invoke("RemoveBullet", 5f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Damagable")
        {
            ObjectHealth objectScript = collision.collider.GetComponent<ObjectHealth>();
            objectScript.Health--;
        }
        Destroy(gameObject);
    }

    private void RemoveBullet()
    {
        Destroy(gameObject);
    }
}
