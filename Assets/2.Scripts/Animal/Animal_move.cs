using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_move : MonoBehaviour
{
    Animal_life life;
    public Animator animator;
    public float speed;
    float speed_init;
    bool area; //영역안에 상대가 있는지
    public Transform pos;
    public AudioSource attacksound;

    public float damage;    //공격력
    public GameObject balsa;    //공격 발사체

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
    public Vector2 boxsize; //공격 시작 범위
    private float waitingtime = 2;

    private void FixedUpdate()
    {
        GameObject balsacopy;
        if (area == true)
        {
            speed = 0F;
            animator.SetBool("run", false); // 일단 정지
            // 공격 or  적 체력 -= 데미지                 
            if (curtime <= 0)                
            {                    
                Collider2D[] collider2D = Physics2D.OverlapBoxAll(pos.position, boxsize, 0);
                balsacopy = Instantiate(balsa, gameObject.transform);
                
                foreach (Collider2D collider in collider2D)
                {
                    Debug.LogError(collider.tag);
                    curtime = cooltime;
                    animator.SetTrigger("attack");
                    animator.SetBool("run", false);
                    attacksound.Play();
                    life.attack = true; // 공격

                }
            }            
            else
            {
                life.attack = false;
                curtime -= Time.deltaTime;
            }
        }
        if (area == false)
        {
            if (life.NowHP == 0) // 사망 애니메이션, 정지
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
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            area = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            area = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            area = false;
        }
    }
}
