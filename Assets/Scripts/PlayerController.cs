using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D prb;
    private Vector2 dir;
    private float speed
    {
        get
        {
            return GameManager.instance.player_speed;
        }
    }

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        prb = GetComponent<Rigidbody2D>();
        dir = (playerInput.movePos - prb.position).normalized;
    }


    void FixedUpdate()
    {
        /*
        if (Vector2.Distance(playerInput.movePos, prb.position) <= GameManager.instance.apxDistance)
            dir = Vector2.zero;
        else
            dir = (playerInput.movePos - prb.position).normalized;
        */
        //transform.position = Vector2.MoveTowards(transform.position, playerInput.movePos, Time.deltaTime * speed);
        //prb.MovePosition(playerInput.movePos);
        //print(dir);
        //prb.velocity = dir * speed * Time.deltaTime;
        prb.position = Vector2.MoveTowards(prb.position, playerInput.movePos, speed*Time.deltaTime);
        //prb.MovePosition(prb.position + dir*Time.deltaTime*speed);
    }
}
