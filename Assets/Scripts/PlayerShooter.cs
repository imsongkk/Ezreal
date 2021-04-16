using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    private PlayerInput playerInput;
    private Vector2 targetPos;
    public GameObject [] skill = new GameObject[4];
    private Camera cam;
    private float[] lastShotTime = new float[4] { -100, -100, -100, -100 };

    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam = GameObject.FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        targetPos = playerInput.cursorPos;
        Vector2 dir = (targetPos - (Vector2)transform.position).normalized; // 스킬 방향
        if (playerInput.buttonDown[0] && Time.time - lastShotTime[0] >= GameManager.instance.skill_cool[0]) // q발사
        {
            GameObject curskill = Instantiate(skill[0], transform.position, Quaternion.Euler(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90));
            Skill s = curskill.GetComponent<Skill>();
            s.dir = dir;
            lastShotTime[0] = Time.time;
        }
        if (playerInput.buttonDown[2] && Time.time - lastShotTime[2] >= GameManager.instance.skill_cool[2]) // e를 발사하지 않고 그냥 움직인다.
        {
            // 현재 벽넘는 기능은 구현이 안되어 있음
            Rigidbody2D prb = GetComponent<Rigidbody2D>();
            float distance = ((Vector2)transform.position - targetPos).magnitude > GameManager.instance.skill_distance[2] ? GameManager.instance.skill_distance[2] : ((Vector2)transform.position - targetPos).magnitude;
            RaycastHit2D[] ray = Physics2D.RaycastAll(transform.position, dir, distance);
            bool thereIsTerrain = false;
            Vector2 terrainPos = Vector2.zero;
            print(terrainPos + " " + transform.position);
            for(int i=0; i<ray.Length; i++)
            {
                if(ray[i].collider.gameObject.tag == "Terrain")
                {
                    terrainPos = ray[i].point;
                    thereIsTerrain = true;
                    break;
                }
            }
            if (thereIsTerrain)
            {
                transform.position = terrainPos;
            }
            else
                transform.position = targetPos;
            prb.velocity = Vector2.zero;
            /*
            Rigidbody2D prb = GetComponent<Rigidbody2D>();
            Vector2 targetWorldPos = cam.ScreenToWorldPoint(playerInput.cursorPos);
            Vector2 shootPos = (targetWorldPos - prb.position).normalized * GameManager.instance.player_radius;
            RaycastHit2D[] ray = Physics2D.RaycastAll(shootPos, (Vector2)cam.ScreenToWorldPoint(targetPos) - prb.position, 7000);
            //print(prb.position + " " + (Vector2)cam.ScreenToWorldPoint(targetPos));
            Debug.DrawRay(shootPos, cam.ScreenToWorldPoint(targetPos) - (Vector3)prb.position, Color.green, 20);
            //print(ray.Length);
            print(prb.position + " " + targetWorldPos + " " + shootPos);
            if(ray.Length == 0) // 이동하려는 곳까지 가는 경로에 아무것도 없으면
            {
                prb.position = (Vector2)cam.ScreenToWorldPoint(targetPos);
            }
            else
            {
                for(int i=0; i<ray.Length; i++)
                {
                    if (ray[i].collider.tag == "Background")
                    {
                        prb.position = ray[i].point;
                        break;
                    }
                }
            }
            playerInput.movePos = prb.position;
            lastShotTime[1] = Time.time;
            */
        }
        
    }
}
