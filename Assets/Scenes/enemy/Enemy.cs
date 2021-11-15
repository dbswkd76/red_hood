using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject prfHpBar;
    [SerializeField] Slider hpbar;
    List<Transform> m_enemyList = new List<Transform>();
    List<GameObject> m_hpBarList = new List<GameObject>();
    Camera m_cam = null;

    private float maxhp = 100;
    private float nowhp = 100;

    private GameObject m_goHpBar;
    private float m_fSpeed = 5.0f;
   

    private void HandleHp()
    { 
        hpbar.value = (float)nowhp / (float)maxhp;
    }
    void Start()
    {
        m_goHpBar = GameObject.Find("hpbar test/Slider");
    }
    void Update()
    {
        m_goHpBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
        
    }
}


      


