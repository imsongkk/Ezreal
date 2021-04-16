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

    public float[] skill_speed = new float[] { 1000f, 1000f, 1000f, 1000f };
    public float[] skill_distance = new float[] { 600,600,600,600};
    public float[] skill_cool = new float[] { 3, 3, 3, 3};
    public float player_speed = 300f;
    public float player_radius = 24f;

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

    // Start is called before the first frame update
    void Start()
    {
        m_instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
