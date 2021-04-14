using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    const int userKeyCount = 6;
    public bool [] buttonDown = new bool[userKeyCount];
    public Vector2 cursorPos; // 스킬의 방향
    private string[] keyList = new string[userKeyCount] { "q","w","e","r","d","f" };

    // Start is called before the first frame update
    void Start()
    {
        cursorPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance != null && GameManager.instance.isGameOver) // 게임오버 상태이면 입력을 받지 않는다.
        {
            print("A");
            return;
        }
        cursorPos = Input.mousePosition;
        for(int i=0; i<userKeyCount; i++)
        {
            buttonDown[i] = Input.GetKeyDown(keyList[i]);
        }
        
        if(buttonDown[0])
        {

        }
        
    }
}
