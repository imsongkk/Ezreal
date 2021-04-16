using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private float[] lastShootTime;
    private PlayerInput playerInput;
    public Transform skillPivot; // 스킬 발사 위치
    public GameObject[] skillList = new GameObject[6];
    public GameObject curSkill;
    public Vector2 dir;
    public int curSkillIndex = 0;
    public bool isShootable = true;
    // ###
    // 6말고 변수로 바꾸고 싶은데 어떻게?

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        lastShootTime = new float[GameManager.instance.keyList.Length];
    }

    private void Update()
    {
        dir = (playerInput.cursorPos - (Vector2)transform.position).normalized;
        if (playerInput.buttonDown[0] && CanShoot(0))
        {
            lastShootTime[0] = Time.time;
            curSkill = Instantiate(skillList[0], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));
            curSkillIndex = 0;
        }
        if(playerInput.buttonDown[2] && CanShoot(2))
        {
            lastShootTime[2] = Time.time;
            curSkill = Instantiate(skillList[2], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));
            curSkillIndex = 2;
        }
    }

    private bool CanShoot(int type)
    {
        if (lastShootTime[type] == 0 || Time.time - lastShootTime[type] >= GameManager.instance.skill_cool[type])
            return true;
        return false;
    }
}
