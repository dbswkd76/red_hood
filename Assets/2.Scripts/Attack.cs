using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    Animator animator;
    Rigidbody2D myrigidbody;
    private float curTime;
    public float coolTime = 0.5f;
    public Transform pos;
    public Vector2 boxSize;
    public Enemy enemy;
    [SerializeField] GameObject melee;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        myrigidbody = GetComponent<Rigidbody2D>();
    }
    

    // Update is called once per frame
    void Update()
    {
        if (curTime <= 0)
        {
            if (Input.GetKey(KeyCode.Z))
            {
                melee.SetActive(true);
                Invoke("meleeoff", 0.5f);
                Collider2D[] collider2Ds = Physics2D.OverlapBoxAll(pos.position, boxSize, 0);
                foreach (Collider2D collider in collider2Ds)
                {
                    Debug.Log(collider.tag);
                   
                        
                }
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 0);
                animator.SetFloat("NormalState", 0);
                animator.SetFloat("SkillState", 0);
                curTime = coolTime;

            }
        }
        else
        {
            curTime -= Time.deltaTime;
        }
       
    }
    void meleeoff()
    {
        melee.SetActive(false);
    }
     void OnDrawGizoms()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(pos.position, boxSize);
    }
}
