using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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

    private static GameManager m_instance;

    public bool isGameOver { get; private set; }
    public int userSkillCount = 6;
    public string[] keyList = new string[] { "q", "w", "e", "r", "d", "f" };
    public float[] skill_speed = new float[] { 1500f, 1000f, 1000f, 1000f };
    public float[] skill_distance = new float[] { 600,600,400,600,600,600};
    public float[] skill_cool = new float[] { 3, 3, 3, 3};
    public float player_speed = 300f;
    public float player_radius = 50f;
    //public Dictionary<int, bool> skillDict;

    // 미니언 골드
    // 처음 플레이어 체력, 공격력
    // 쿨타임

    public void Awake()
    {
        if(this != instance)
        {
            Destroy(gameObject);
        }
        
    }

    void Start()
    {
        m_instance = this;
        isGameOver = false;
    }

    void EndGame()
    {
        isGameOver = true;
    }
}
