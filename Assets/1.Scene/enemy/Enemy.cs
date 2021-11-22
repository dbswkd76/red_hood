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


    void Start()
    {
        isAlive = true;
    }
    void Update()
    {
        if (m_nowhp <= 0)
            isAlive = false;
        
    }
}


      


