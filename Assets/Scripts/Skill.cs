using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Vector2 dir { get; set; }
    public int type { get; set; }
    private Vector2 originPos { get; set; }
    public float speed
    {
        get
        {
            return GameManager.instance.skill_speed[type];
        }
    }
    public float distance
    {
        get
        {
            return GameManager.instance.skill_distance[type];
        }
    }

    // Start is called before the first frame update
    
    void Start()
    {
        originPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 0)
        {
            if (Vector2.Distance(transform.position, originPos) <= distance)
                transform.position += (Vector3)(Time.deltaTime * dir) * speed;
            else
                Destroy(gameObject);
        }
        else if(type == 1)
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Enemy")
            return;
        Destroy(collision.gameObject);
        // TODO
        // 적에게 데미지 입히는것 구현
        Destroy(gameObject);
    }
}
