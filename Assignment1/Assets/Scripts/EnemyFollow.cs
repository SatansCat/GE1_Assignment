using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public GameObject Player;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 lookDir = gameObject.transform.position - Player.transform.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg-180;
        gameObject.GetComponent<Rigidbody2D>().rotation = angle;
        transform.Translate(1 * Time.deltaTime * speed, 0, 0);
        //position = Vector3.Lerp(gameObject.transform.position, Player.transform.position, Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.GetComponent<StatTracker>().Health--;
        }
    }
}
