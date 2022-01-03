using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        
    }

   

    // Start is called before the first frame update
    //private void Awake()
    //{
    //    rigid = GetComponent<Rigidbody2D>();
    //}

    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if (col.CompareTag("Player"))
    //    {
    //        rigid.AddForce(new Vector2(5, 5), ForceMode2D.Impulse);
    //    }
    //}

    //void FixedUpdate()
    //{

    //    rigid.velocity = new Vector2(-1, rigid.velocity.y); //단순 왼쪽방향 이동       
    //}
}
