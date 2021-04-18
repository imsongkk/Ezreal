using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private PlayerInput playerInput;
    private Rigidbody2D prb;
    public GameManager.PlayerInfo info;
    private Animator animator;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        prb = GetComponent<Rigidbody2D>();
        info = GameManager.instance.playerInfo;
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (playerInput.movePos == prb.position)
            animator.SetBool("Stopped", true);
        //Vector2 dir = playerInput.movePos - prb.position;
        //print(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        //animator.transform.rotation *= Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg);
        prb.position = Vector2.MoveTowards(prb.position, playerInput.movePos, info.speed*Time.deltaTime);
    }

    public void Rotate(Vector2 dir)
    {
        Quaternion q = Quaternion.Euler(0, 0, Vector2.SignedAngle(playerInput.rotateDir, dir));
        animator.transform.rotation *= q;
        playerInput.rotateDir = dir;
    }
}
