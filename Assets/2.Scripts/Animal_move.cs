using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_move : MonoBehaviour
{
    public Animator animator;
    public float speed;
    float speed_init;
    bool area; //영역안에 상대가 있는지
    public Transform pos;

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
        transform.Translate(Vector2.right * speed * Time.deltaTime * 0.1F);
    }
    public Vector2 boxsize; //공격 시작 범위
    private float waitingtime = 2;

    private void FixedUpdate()
    {
        if (area == true)
        {
            speed = 0F;
            animator.SetBool("run", false); // 일단 정지
            // 공격 or  적 체력 -= 데미지                 
            if (curtime <= 0)                
            {                    
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(pos.position, boxsize, 0);
                
                foreach (Collider2D collider in collider2D)
                {
                    Debug.LogError(collider.tag);
                    curtime = cooltime;
                    animator.SetTrigger("attack");
                    animator.SetBool("run", false);
                    Animal_life.attack = true; // 공격                    
                }
            }            
            else
            {                   
                curtime -= Time.deltaTime;
            }
        }
        if (area == false)
        {
            if (Animal_life.NowHP == 0) // 사망 애니메이션, 정지
            {
                speed = 0;
                animator.SetBool("die", true);
                Invoke("Destroy", 1.5f);
            }
            else // 다시 진행
            {
                speed = speed_init;
                animator.SetBool("run", true);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(pos.position, boxsize);
    }
    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    //적군 충돌 판정
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = true;
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
