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
    /*
    public int userSkillCount = 6;
    public string[] keyList = new string[] { "q", "w", "e", "r", "d", "f" };
    public float[] skill_speed = new float[] { 1500f, 1000f, 1000f, 1000f };
    public float[] skill_distance = new float[] { 600,600,400,600,600,600};
    public float[] skill_cool = new float[] { 3, 3, 3, 3};
    public float player_speed = 300f;
    public float player_radius = 50f;
    */

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

    void EndGame()
    {
        isGameOver = true;
    }
}
