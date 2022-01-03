using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_move : MonoBehaviour
{
    public float speed;
    float speed_init;
    bool area; //영역안에 상대가 있는지
    public Animator animator;
    public Transform pos;
    public Vector2 boxsize;
    private float curtime;
    public float cooltime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        area = false;
        speed_init = speed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * 0.1F);
    }
    private void FixedUpdate()
    {
        if (area == true)
        {
            speed = 0F; 
                // 공격 or  적 체력 -= 데미지                 
            if (curtime <= 0)                
            {                    
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(pos.position, boxsize, 0);                
                foreach (Collider2D collider in collider2D)                
                {                
                    Debug.LogError(collider.tag);                    
                }                
                curtime = cooltime;                
                animator.SetTrigger("attack");
                animator.SetBool("run", false);
            }            
            else
            {                   
                curtime -= Time.deltaTime;
                animator.ResetTrigger("attack");
            }
        }
        if (area == false)
        {
            speed = speed_init;
            animator.SetBool("run", true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = true;
            //Debug.LogError("충돌");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = false;
        }
    }
}
