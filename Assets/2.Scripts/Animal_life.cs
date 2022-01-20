using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_life : MonoBehaviour
{
    // Start is called before the first frame update
    public int life;
    static public float health;
    public Animator animator;
    

    void Start()
    {
        health = life;
    }

    // Update is called once per frame
    void Update()
    {
        //피격 판정
        // health = life - 공격량
        if (health == 0)
        {
            animator.SetBool("die", true);
        }
    }

    // 생명 받고, 남은 생명 = 생명 - 적 공격력 
    // 적 공격력 -> 충돌한 발사체 스프라이트에서 받아오기 
    // 애니멀도 발사체로 공격하는 걸로 해야 하나? 
    // 
}
