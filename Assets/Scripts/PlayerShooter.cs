using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private PlayerInput playerInput;
    private PlayerController playerController;
    //public Transform skillPivot; // 스킬 발사 위치
    public GameObject[] skillList = new GameObject[6]; 
    // TODO
    // 6을 변수로 바꾸고싶은데 어떻게?
    // 1. 프리팹을 드래그로 불러오는게 아닌 스크립트에서 할당하면 일단 되긴 됨
    public GameObject curSkill;
    public Vector2 dir;
    private float[] lastShootTime;
    public int userKeyCount;
    public int curSkillIndex = 0;
    public bool isShootable = true;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        playerController = GetComponent<PlayerController>();
        userKeyCount = ConstantManager.instance.userKeyCount;
        lastShootTime = new float[userKeyCount];
    }

    private void Update()
    {
        dir = (playerInput.cursorPos - (Vector2)transform.position).normalized;
        if (playerInput.buttonDown[0] && CanShoot(0))
        {
            lastShootTime[0] = Time.time;
            curSkill = Instantiate(skillList[0], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));
            curSkillIndex = 0;
            playerController.Rotate(dir);
        }
        if(playerInput.buttonDown[2] && CanShoot(2))
        {
            lastShootTime[2] = Time.time;
            curSkill = Instantiate(skillList[2], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));
            curSkillIndex = 2;
            playerController.Rotate(dir);
        }
    }

    private bool CanShoot(int type)
    {
        if (lastShootTime[type] == 0 || Time.time - lastShootTime[type] >= ConstantManager.instance.skillInfo[type].cool)
            return true;
        return false;
    }
}
