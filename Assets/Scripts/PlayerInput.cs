using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public const int userKeyCount = 6;
    public bool [] buttonDown = new bool[userKeyCount];
    public Vector2 cursorPos; // 스킬의 방향
    public Vector2 movePos; // 플레이어가 움직일 방향
    private string[] keyList = new string[userKeyCount] { "q","w","e","r","d","f" };
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cursorPos = transform.position;
        cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance != null && GameManager.instance.isGameOver) // 게임오버 상태이면 입력을 받지 않는다.
        {
            print("A");
            return;
        }

        cursorPos = cam.ScreenToWorldPoint(Input.mousePosition); // 현재 마우스 커서의 위치를 계속 갱신

        for(int i=0; i<userKeyCount; i++)
        {
            buttonDown[i] = Input.GetKeyDown(keyList[i]); // userKeyCount개의 버튼들이 각각 눌렸는지를 확인
        }
        
        if(Input.GetMouseButton(1))
        {
            /*
            Vector2 dir = (cursorPos - (Vector2)transform.position).normalized; // 스킬 쏴야 하는 방향 벡터 , 크기가 1
            RaycastHit2D[] ray = Physics2D.RaycastAll((Vector2)transform.position,dir,Vector2.Distance(cursorPos, (Vector2)transform.position));
            Debug.DrawRay((Vector2)transform.position, (cursorPos - (Vector2)transform.position), Color.red, 200);
            movePos = cursorPos;
            for (int i=0; i<ray.Length; i++)
            {
                if(ray[i].collider.tag == "Terrain")
                {
                    movePos = ray[i].point - dir * GameManager.instance.player_radius;
                    break;
                }
            }
            */
            movePos = cursorPos;
            // TODO 1
            // 마법진 모양의 파티클 발생
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            movePos = transform.position;
        }
    }
}
