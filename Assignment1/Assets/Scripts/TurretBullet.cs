using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{

    private void Awake()
    {
        Invoke("RemoveBullet", 5f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<StatTracker>().Health--; //Damage Player
        }
        Destroy(gameObject);
    }

    private void RemoveBullet()
    {
        Destroy(gameObject);
    }
}