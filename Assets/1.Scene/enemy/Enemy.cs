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
    private bool isAlive;
    [SerializeField] Slider HpBar;
    //List<Transform> m_enemyList = new List<Transform>();
    //List<Slider> m_hpBarList = new List<Slider>();
    //Camera m_cam = null;
    //GameObject[] t_objects;
    Animator anim;
    public AudioSource wolf_die;
    public AudioSource hit_sound;
    //public AudioSource howling;
    public List<Transform> obj;
    public List<GameObject> hp_bar;
    Camera camera;
    SpriteRenderer spriteRenderer;
    Rigidbody2D rigid;
    bool isHit = false;

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
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (m_nowhp > 0)
            {
                //anim.SetTrigger("attack");
                rigid.velocity = new Vector2(1, rigid.velocity.y);
                EnemyDamaged();               
            }
        }
    }
    void EnemyDamaged()
    {
        isHit = true;
        m_nowhp -= 10;
        hit_sound.Play();
        Debug.Log("�¾���");
        anim.SetBool("isHit",true);
        rigid.AddForce(new Vector2(2, 3), ForceMode2D.Impulse);
        spriteRenderer.color = new Color(1, 1, 1, 0.6f);
        gameObject.layer = 7;
        Invoke("isHitchange", 1f);
        Invoke("OffDamaged", 1.5f);
    }
    void isHitchange()
    {
        isHit = false;
        anim.SetBool("isHit", false);
    }
    void OffDamaged()
    {
        isHit = false;
        gameObject.layer = 6;
        spriteRenderer.color = new Color(1, 1, 1, 1);
        rigid.velocity = new Vector2(-1, rigid.velocity.y); //�ܼ� ���ʹ��� �̵�   
        
    }
   
    void Awake()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
    

    void Start()
    {
        if (name.Equals("white"))
        {
            SetEnemyStat(20, 5);
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
        isAlive = true;
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
        if (m_nowhp <= 0)
            isAlive = false;
        
        HandleHp();
        //for (int i = 0; i < m_enemyList.Count; i++)
        //{
        //    m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_enemyList[i].position + new Vector3(0, 0.5f, 0));
        //}
        
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 0.5f, 0));
        }
        if (m_nowhp <= 0) // �� ���
        {
            anim.SetBool("dead", true);
            wolf_die.Play();
            Invoke("DieDestroyAfter", 1f);
            Destroy(HpBar.gameObject);
        }
        
    }
    void FixedUpdate()
    {
        if (m_nowhp > 0 && isHit == false)
            rigid.velocity = new Vector2(-1, rigid.velocity.y); //�ܼ� ���ʹ��� �̵�  
    }
    void DieDestroyAfter()
    {
        Destroy(gameObject);
    }
   
}


      


