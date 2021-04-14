using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 targetPos;
    public GameObject [] skill = new GameObject[4];
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = cam.WorldToScreenPoint(transform.position); // 현재 플레이어의 스크린 좌표
        targetPos = playerInput.cursorPos; // 마우스의 스크린 좌표
        temp = (targetPos - temp).normalized; // 차이 값
        if (playerInput.buttonDown[0]) // q발사
        {
            //print(Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg);
            GameObject curskill = Instantiate(skill[0], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(temp.y, temp.x) * Mathf.Rad2Deg - 90));
            Skill s = curskill.GetComponent<Skill>();
            s.dir = temp;
        }
    }
}
