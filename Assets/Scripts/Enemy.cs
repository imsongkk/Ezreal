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
        if (GameManager.instance.isGameOver)
            return;
        dir = (Vector2)GameObject.FindGameObjectWithTag("Player").transform.position;
        transform.position = Vector2.MoveTowards(transform.position, dir, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            GameManager.instance.EndGame();
        }
    }

    private void OnDestroy()
    {
        if(GameManager.instance != null)
            GameManager.instance.AddScore();
    }
}
