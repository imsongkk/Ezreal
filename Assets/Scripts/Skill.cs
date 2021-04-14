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
        //transform.position += Time.deltaTime * gameObject.transform.rotation.eulerAngles;
        //print(dir);
        //print(GameManager.instance.skill_speed[0]);
        //print(speed);
        if (Vector2.Distance(transform.position, originPos) <= distance)
            transform.position += (Vector3)(Time.deltaTime * dir) * speed;
        else
            Destroy(gameObject);
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(dir);
    }
}
