using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_move : MonoBehaviour
{   
    Animal_life life;
    public Animator animator;
    public float speed;
    float speed_init;
    bool area; //�����ȿ� ��밡 �ִ���
    public Transform pos;
    AudioSource attacksound;

    private float curtime;
    public float cooltime = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Animal_life>();
        area = false;
        speed_init = speed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * 0.1F);
    }
    public Vector2 boxsize; //���� ���� ����
    private float waitingtime = 2;

    private void FixedUpdate()
    {
        if (area == true)
        {
            speed = 0F;
            animator.SetBool("run", false); // �ϴ� ����
            // ���� or  �� ü�� -= ������                 
            if (curtime <= 0)                
            {                    
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(pos.position, boxsize, 0);
                
                foreach (Collider2D collider in collider2D)
                {
                    Debug.LogError(collider.tag);
                    curtime = cooltime;
                    animator.SetTrigger("attack");
                    animator.SetBool("run", false);
                    attacksound.Play();
                    Animal_life.attack = true; // ����                    
                }
            }            
            else
            {                   
                curtime -= Time.deltaTime;
            }
        }
        if (area == false)
        {
            if (life.NowHP == 0) // ��� �ִϸ��̼�, ����
            {
                speed = 0;
                animator.SetBool("die", true);
                Invoke("Destroy", 1.5f);
            }
            else // �ٽ� ����
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
    //���� �浹 ����
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
