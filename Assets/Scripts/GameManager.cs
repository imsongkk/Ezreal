using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager instance 
    { 
        get
        {
            if(m_instance == null)
            {
                m_instance = FindObjectOfType<GameManager>();
            }
            return m_instance;
        }
    }    

    public struct PlayerInfo
    {
        public string champName;
        public int index;
        public float radius;
        public float speed;
        public PlayerInfo(string name, int index, float radius, float speed)
        {
            this.champName = name;
            this.index = index;
            this.radius = radius;
            this.speed = speed;
        }
    }

    public PlayerInfo playerInfo;

    public bool isGameOver { get; private set; }
    public int clickCount = 0;
    public float startTime = 0f;
    public int APM = 0;
    public int round = 1; // 라운드
    public float frequencyEnemySpawn = 3f; // 적 생성 주기

    // 미니언 골드
    // 처음 플레이어 체력, 공격력

    public void Awake()
    {
        if(instance != this)
        {
            Destroy(gameObject);
        }
        SetPlayer("Ezreal");
    }

    void SetPlayer(string champName) // UI에서 champName을 받아옴
    {
        // 받아온 정보로 DB 조회 해서 정보 때려 박음
        // info = ~~~
        playerInfo = new PlayerInfo(champName, 0, 50, 300);
    }

    public void Start()
    {
        m_instance = this;
        isGameOver = false;
    }

    public void EndGame()
    {
        isGameOver = true;
        APM = GetAPM(Time.time - startTime);
        startTime = Time.time;
    }

    public int GetAPM(float duration)
    {
        return (int)(clickCount / duration) * 60;
    }
}
