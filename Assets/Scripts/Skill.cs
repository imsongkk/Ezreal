using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public Vector2 dir { get; set; }
    public int type { get; set; }
    public float speed
    {
        get
        {
            return GameManager.instance.skill_speed[type];
        }
    }

    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position += Time.deltaTime * gameObject.transform.rotation.eulerAngles;
        //print(dir);
        if (GameManager.instance == null)
            Debug.Log("A");
        transform.position += (Vector3)(Time.deltaTime * dir)*speed;
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        //rb.AddForce(dir);
    }
}
