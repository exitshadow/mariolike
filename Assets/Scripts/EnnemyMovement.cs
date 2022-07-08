using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyMovement : MonoBehaviour
{
    public Vector2 speed;
    public bool avoidCliffs = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 origin = transform.position;
        BoxCollider2D thisCollider = GetComponent<BoxCollider2D>();

        origin.y -= thisCollider.size.y / 2;
        transform.position += (Vector3)speed * Time.deltaTime;

        if (speed.x > 0)    origin.x += thisCollider.size.x / 2;
        else                origin.x -= thisCollider.size.x / 2;
        
        if (Physics2D.Raycast(origin, Vector2.down, .5f).collider == null && avoidCliffs) {
            speed.x *= -1;
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("PinkMonster")) {
            speed.x *= -1;
        } else if (collision.collider.CompareTag("Player")) {
            Debug.Log("blah");
        }

    }
}
