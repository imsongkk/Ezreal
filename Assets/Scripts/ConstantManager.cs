using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantManager : MonoBehaviour
{
    public static ConstantManager instance
    {
        get
        {
            if (m_instance == null)
            {
                m_instance = FindObjectOfType<ConstantManager>();
            }
            return m_instance;
        }
    }
    private static ConstantManager m_instance;

    public struct SkillInfo
    {
        public string key;
        public float speed;
        public float distance;
        public float cool;
        public bool shootable;
        public SkillInfo(string key, float speed, float distance, float cool, bool shootable)
        {
            this.key = key;
            this.speed = speed;
            this.distance = distance;
            this.cool = cool;
            this.shootable = shootable;
        }
    }
    public int userKeyCount = 6; // DB에서 불러 오는 것
    public SkillInfo[] skillInfo;

    public void Awake()
    {
        // TODO
        // DB에서 불러와 초기화 하기
        if (instance != this)
        {
            Destroy(gameObject);
        }
        m_instance = this;
        skillInfo = new SkillInfo[userKeyCount];
        skillInfo[0] = new SkillInfo("q", 1500, 600, 0.5f, true);
        skillInfo[1] = new SkillInfo("w", 1500, 600, 3, true);
        skillInfo[2] = new SkillInfo("e", 0   , 400, 3, false);
        skillInfo[3] = new SkillInfo("r", 1500, 600, 3, true);
        skillInfo[4] = new SkillInfo("d", 1500, 600, 3, false);
        skillInfo[5] = new SkillInfo("f", 1500, 600, 3, false);
    }
}
