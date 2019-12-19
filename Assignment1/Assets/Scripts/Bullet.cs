using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string Target;

    private void Awake()
    {
        Invoke("RemoveBullet", 5f);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == Target)
        {
            if(Target == "Damagable")
            {
                ObjectHealth objectScript = collision.collider.GetComponent<ObjectHealth>();
                objectScript.Health--;
            }
            else if (Target == "Player")
            {
                //Damage player
            }
            
        }
        Destroy(gameObject);
    }

    private void RemoveBullet()
    {
        Destroy(gameObject);
    }
}
