using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 cursorPos; // 스킬의 방향
    public Vector2 movePos; // 플레이어가 움직일 방향
    public int userKeyCount;
    public bool[] buttonDown;
    private Camera cam;

    void Start()
    {
        cursorPos = transform.position;
        cam = GameObject.FindObjectOfType<Camera>();
        userKeyCount = ConstantManager.instance.userKeyCount;
        buttonDown = new bool[userKeyCount];
    }

    void Update()
    {
        // 게임오버 상태이면 입력을 받지 않는다.
        if (GameManager.instance != null && GameManager.instance.isGameOver)
        {
            return;
        }
        // 현재 마우스 커서의 위치를 계속 갱신
        cursorPos = cam.ScreenToWorldPoint(Input.mousePosition); 

        // userKeyCount개의 버튼들이 각각 눌렸는지를 확인
        for (int i=0; i<userKeyCount; i++)
        {
            buttonDown[i] = Input.GetKeyDown(ConstantManager.instance.skillInfo[i].key); 
        }
        
        // 우클릭
        if(Input.GetMouseButton(1))
        {
            movePos = cursorPos;
            // ##########
            // TODO 1
            // 마법진 모양의 파티클 발생
        }

        // 스탑무빙
        if(Input.GetKeyDown(KeyCode.S))
        {
            movePos = transform.position;
        }
    }
}
