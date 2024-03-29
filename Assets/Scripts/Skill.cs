﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Vector2 dir { get; set; }
    public int sindex { get; set; } // 스킬의 순서
    public Vector2 originPos { get; set; }
    private enum SkillType
    {
        Q = 0,
        W,E,R,D,F
    }
    public PlayerShooter ps;
    public ConstantManager.SkillInfo []skillInfo;

    private void Start()
    {
        originPos = transform.position;
        ps = GameObject.Find("Player").GetComponent<PlayerShooter>();
        this.dir = ps.dir;
        this.sindex = ps.curSkillIndex;
        skillInfo = ConstantManager.instance.skillInfo;
    }

    private void Update()
    {
        if (!skillInfo[sindex].shootable)
            FireNothing(sindex);
        else
            FireSomething(sindex);
    }

    private void FireNothing(int index)
    {
        if(index == (int)SkillType.E || index == (int)SkillType.D)
        {
            GameObject player = GameObject.Find("Player");
            PlayerInput playerInput = player.GetComponent<PlayerInput>();
            Vector2 skillPos = getNearPos(player.transform.position, (playerInput.cursorPos - (Vector2)player.transform.position).normalized, (playerInput.cursorPos - (Vector2)player.transform.position).magnitude >=
                skillInfo[index].distance ? skillInfo[index].distance : (playerInput.cursorPos - (Vector2)player.transform.position).magnitude, GameManager.instance.playerInfo.radius);
            if (playerInput.movePos == (Vector2)player.transform.position) // 정지 상태
                playerInput.movePos = skillPos;
            player.transform.position = skillPos;
            Destroy(gameObject);
        }
    }

    private void FireSomething(int index)
    {
        if (index == (int)SkillType.Q)
        {
            if (Vector2.Distance(transform.position, originPos) <= skillInfo[index].distance)
                transform.position += (Vector3)(Time.deltaTime * dir) * skillInfo[index].speed;
            else
                Destroy(gameObject);
        }
    }

    // 오브젝트의 반지름이 rad, 위치가 pos이고, 스킬을 쓰는 방향이 dir, 스킬의 사거리가 distance일 때, 사거리 안에서 이동할 수 있는 가장 먼 곳의 좌표를 반환한다.
    private Vector2 getNearPos(Vector2 originPos, Vector2 dir, float distance, float objectRad)
    {
        Vector2 ret = originPos + dir * distance;
        RaycastHit2D[] ray = Physics2D.RaycastAll(originPos, dir, distance);
        for(int i=0; i<ray.Length; i++)
        {
            if (ray[i].collider.tag == "Terrain")
            {
                if(i == ray.Length - 1 || ray[i+1].collider.tag != "Terrain")
                    ret = ray[i].point - dir * objectRad;
            }
        }
        return ret;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
            return;
        // ###
        // TODO
        // 적에게 데미지 입히는것 구현
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
