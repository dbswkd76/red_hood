using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    public int m_nowhp;
    public int m_maxhp;
    public int m_speed;
    public int m_damage;
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
                m_nowhp -= 10;
                hit_sound.Play();
                Debug.Log(m_nowhp);
            }
            //if (m_nowhp <= 0) // Àû »ç¸Á
            //{
            //    anim.SetBool("dead", true);
            //    wolf_die.Play();
            //    Invoke("DieDestroyAfter", 0.5f);
            //    Destroy(HpBar.gameObject);
            //}          



        }
    }
    void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_nowhp -= 10;
        }
        HandleHp();
        //for (int i = 0; i < m_enemyList.Count; i++)
        //{
        //    m_hpBarList[i].transform.position = m_cam.WorldToScreenPoint(m_enemyList[i].position + new Vector3(0, 0.5f, 0));
        //}
        
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 0.5f, 0));
        }
        if (m_nowhp <= 0) // Àû »ç¸Á
        {
            anim.SetBool("dead", true);
            wolf_die.Play();
            Invoke("DieDestroyAfter", 1f);
            Destroy(HpBar.gameObject);
        }
    }
    void DieDestroyAfter()
    {
        Destroy(gameObject);
        
    }
   
}


      


