using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 cursorPos; // 스킬의 방향
    public Vector2 movePos; // 플레이어가 움직일 방향
    public Vector2 rotateDir; // 플레이어가 바라보고 있는 방향벡터
    public int userKeyCount;
    public bool[] buttonDown;
    public Quaternion rotateQ = Quaternion.identity;
    private Camera cam;
    private Animator animator;
    private PlayerController playerController;

    void Start()
    {
        cursorPos = transform.position;
        cam = GameObject.FindObjectOfType<Camera>();
        userKeyCount = ConstantManager.instance.userKeyCount;
        buttonDown = new bool[userKeyCount];
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
        rotateDir = new Vector2(0, -1);
    }

    void Update()
    {
        int clickCount = 0;
        //rotateQ = Quaternion.Euler(0, 0, Vector2.SignedAngle(rotateDir, cursorPos));

        // 게임오버 상태이면 입력을 받지 않는다.
        if (GameManager.instance != null && GameManager.instance.isGameOver)
        {
            print("GAMEOVER");
            movePos = transform.position;
            return;
        }
        // 현재 마우스 커서의 위치를 계속 갱신
        cursorPos = cam.ScreenToWorldPoint(Input.mousePosition); 

        // userKeyCount개의 버튼들이 각각 눌렸는지를 확인
        for (int i=0; i<userKeyCount; i++)
        {
            buttonDown[i] = Input.GetKeyDown(ConstantManager.instance.skillInfo[i].key);
            if (buttonDown[i])
                clickCount++;
        }
        // 우클릭
        if (Input.GetMouseButtonDown(1)) // 그냥 단번 클릭
        {
            movePos = cursorPos;
            animator.SetBool("Stopped", false);
            Vector2 dir = movePos - (Vector2)transform.position;
            //rotateQ = Quaternion.Euler(0, 0, Vector2.SignedAngle(rotateDir, dir));
            playerController.Rotate(dir);
            //rotateDir = dir;
            //animator.transform.rotation *= Quaternion.Euler(0, 0, Vector2.SignedAngle(rotateDir, dir));
            clickCount++;
        }
        if(Input.GetMouseButton(1)) // 드래그까지 포함
        {
            movePos = cursorPos;
            // ##########
            // TODO 1
            // 마법진 모양의 파티클 발생
        }

        // 스탑무빙
        if(Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Stopped", true);
            clickCount++;
            movePos = transform.position;
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.instance.isPaused)
                GameManager.instance.GetPauseUI();
            else
                GameManager.instance.ExitPauseUI();
        }

        GameManager.instance.clickCount += clickCount;
    }

    public void Rotate()
    {

    }
}
