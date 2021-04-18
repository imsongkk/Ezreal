using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // has rigidbody, collider without trigger
    Vector2 dir;
    float speed = 200f; // 임의 설정

    private void Update()
    {
        dir = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "Player")
        {
            GameManager.instance.EndGame();
        }
    }
}
