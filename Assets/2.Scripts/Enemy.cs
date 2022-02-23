using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] int m_nowhp;
    [SerializeField] int m_maxhp;
    //[SerializeField] int m_speed;
    [SerializeField] int m_damage;
    [SerializeField] Slider HpBar;
    //List<Transform> m_enemyList = new List<Transform>();
    //List<Slider> m_hpBarList = new List<Slider>();
    //Camera m_cam = null;
    //GameObject[] t_objects;
    Animator anim;
    [SerializeField] AudioSource wolf_die;
    [SerializeField] AudioSource hit_sound;
    //[SerializeField] AudioSource claw_sound;
    //public AudioSource howling;
    [SerializeField] List<Transform> obj;
    [SerializeField] List<GameObject> hp_bar;
    Camera camera;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    [SerializeField] bool isHit = false;
    [SerializeField] bool attacking = false;
    [SerializeField] bool attacked = false;
    [SerializeField] bool isidle = false;
    [SerializeField] bool playerdetect = false;
    [SerializeField] GameObject melee;
    private bool touch=false;
    bool isAlive;
    private void SetEnemyStat(int maxhp, int damage)
    {
        m_nowhp = maxhp;
        m_maxhp = maxhp;
        m_damage = damage;
    }

    private void HandleHp()
    {
        
        HpBar.value = (float)m_nowhp / (float)m_maxhp;

    }
    //private void OnTriggerEnter2D(Collider2D col)
    //{
    //    if ((col.CompareTag("Player")||col.CompareTag("PlayerAttack")) && gameObject.CompareTag("Enemy"))
    //    {
    //        if (m_nowhp > 0)
    //        {
    //            //anim.SetTrigger("attack");
    //            //rigid.velocity = new Vector2(1, rigid.velocity.y);
    //            EnemyDamaged(10);
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0|| collision.gameObject.tag.CompareTo("PlayerAttack")==0)
        {
            touch = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0 || collision.gameObject.tag.CompareTo("PlayerAttack") == 0)
        {
            touch = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("Player") == 0 || collision.gameObject.tag.CompareTo("PlayerAttack") == 0)
        {
            touch = false;
        }
    }

    public void EnemyDamaged(int damage)     //매개변수 추가 , public으로 바꾸기
    {
        attacking = false;
        isHit = true;
        m_nowhp -= damage; //damage_bear  //임의로 설정 추후 변경 필요
        hit_sound.Play();
        Debug.Log(gameObject.name+" 맞았음");
        anim.SetBool("isHit",true);
        rigid.AddForce(new Vector2(3, 3), ForceMode2D.Impulse);
        spriteRenderer.color = new Color(1, 1, 1, 0.6f);
        gameObject.layer = LayerMask.NameToLayer("EnemyHit");  //무적으로 변경
        Invoke("isHitchange", 0.5f);
        Invoke("OffDamaged", 1.5f);
    }
    void isHitchange() //맞은 상태해제(달려감)
    {
        Debug.Log("맞은 상태해제");
        //isHit = false;
        anim.SetBool("isHit", false);
    }
    void OffDamaged()   //무적해제
    {
        isHit = false;
        gameObject.layer = LayerMask.NameToLayer("Enemy");
        spriteRenderer.color = new Color(1, 1, 1, 1);
        //rigid.velocity = new Vector2(-1, rigid.velocity.y); //단순 왼쪽방향 이동
    }
   
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    

    void Start()
    {
        isAlive = true;
        isHit = false;
        attacking = false;
        attacked = false;
        isidle = false;
        playerdetect = false;
        if (name.Equals("white"))
        {
            SetEnemyStat(50, 5);
        }
        if (name.Equals("black"))
        {
            SetEnemyStat(50, 5);
        }
        camera = Camera.main;
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = obj[i].position;
        }
        HpBar.value = (float)m_nowhp / (float)m_maxhp;
        //m_cam = Camera.main;
        //t_objects = GameObject.FindGameObjectsWithTag("Enemy");

        //for (int i = 0; i < t_objects.Length; i++)
        //{
        //    m_enemyList.Add(t_objects[i].transform);
        //    Slider t_hpbar = Instantiate(prfHpBar, t_objects[i].transform.position, Quaternion.identity, transform);
        //    m_hpBarList.Add(t_hpbar);
        //    m_hpBarList[i].value = (float)nowhp[i] / (float)maxhp[i];
        //}
    }
    
    void Update()
    {
        HandleHp();
        //for (int i = 0; i < m_enemyList.Count; i++)
        //{
        //    m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_enemyList[i].position + new Vector3(0, 0.5f, 0));
        //}
        
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 0.5f, 0));
        }
        if (m_nowhp <= 0) // 적 사망
        {
            Enemy_count.died_wolf++;
            isAlive = false;
            anim.SetBool("dead", true);
            wolf_die.Play();
            Invoke("DieDestroyAfter", 1f);
            Destroy(HpBar.gameObject);
            anim.SetBool("attack", false);
            anim.SetBool("idle", false);
            isHit = false;
            attacking = false;
        }
        
    }
    void FixedUpdate()
    {
        if(touch==true)
        {
            if (m_nowhp > 0)
            {
                //anim.SetTrigger("attack");
                //rigid.velocity = new Vector2(1, rigid.velocity.y);
                EnemyDamaged(10);
            }
        }
        Debug.DrawRay(transform.position, new Vector3(-2, 0, 0), new Color(0, 1, 0));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, new Vector3(-2, 0, 0), 2f, LayerMask.GetMask("Player"));
        if (isAlive == true)
        {
            if (hit.collider != null && isHit == false)
            {
                if (hit.collider.CompareTag("Player"))
                {
                    Debug.Log("Player감지");
                    playerdetect = true;
                    attack_ready();
                }
            }
            if (hit.collider == null)   //앞에 아무것도 없을때
            {
                playerdetect = false;
                anim.SetBool("attack", false);
                anim.SetBool("idle", false);
                attacking = false;
                isHit = false;
                isidle = false;
                melee.SetActive(false);
            }

            if (isHit == false && attacking == false && playerdetect == false) 
            {
                rigid.velocity = new Vector2(-1, rigid.velocity.y); //단순 왼쪽방향 이동  

            }
        }
    }
    void attack_ready()
    {
        anim.SetBool("idle", true);
        isidle = true;
        attacking = true;
        if(attacked==false)
            Invoke("attack", 0.5f);
    }
    void attack()
    {
        isidle = false;
        if (isHit == false)
        {   
            //claw_sound.Play();
            melee.SetActive(true);
            anim.SetBool("attack", true);
        }
        Invoke("OffAttack", 1.2f);
    }
    void OffAttack()
    {
        Debug.Log("offattack 동작");
        anim.SetBool("attack", false);
        isidle = false;
        attacking = false;
        attacked = true;
        melee.SetActive(false);
        Invoke("OffAttacked", 2f); //공격 쿨타임 2초
    }
    void OffAttacked() //공격 쿨타임
    {
        attacked = false;
    }
    void DieDestroyAfter()
    {
        Destroy(gameObject);
    }
   
}


      


