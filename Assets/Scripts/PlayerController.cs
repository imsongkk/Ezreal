using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D prb;
    public GameManager.PlayerInfo info;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        prb = GetComponent<Rigidbody2D>();
        info = GameManager.instance.playerInfo;
    }


    void FixedUpdate()
    {
        prb.position = Vector2.MoveTowards(prb.position, playerInput.movePos, info.speed*Time.deltaTime);
    }
}
