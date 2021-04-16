using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D prb;

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
    }


    void FixedUpdate()
    {
        prb.position = Vector2.MoveTowards(prb.position, playerInput.movePos, speed*Time.deltaTime);
    }
}
