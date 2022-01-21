using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_attack : MonoBehaviour
{
    
    Animator anim;
    float MaxDistance = 105f;
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("����");
           
        }
    }
    void Start()
    {

    }
    // Update is called once per frame

    void Update()
    {

        //if (Input.GetKey(KeyCode.Z))
        //{
        //    melee.SetActive(true);
        //    anim.SetTrigger("attack");
        //}
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        
    }
}
