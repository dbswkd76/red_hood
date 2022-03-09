using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_life : MonoBehaviour
{
    // Start is called before the first frame update
    public float MaxHP;
    public float NowHP;
    public Animator animator;
    public bool attack = false;
    public float range;
    public float damage;

    void Start()
    {
        NowHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //피격 판정
        // nowhp = maxhp - 공격량
        //maxhp = nowhp
        
        if (NowHP == 0)
        {
            animator.SetBool("die", true);
        }
    }
    public void Damage()
    {
        //RaycastHit2D animal_attack = Physics2D.Raycast(transform.position, new Vector2(-1 * range, 2));
        //if (animal_attack.collider != null)
        //{
        //    Debug.Log(animal_attack.collider.name);
        //}
        NowHP = NowHP - damage;

        // 생명 받고, 남은 생명 = 생명 - 적 공격력 
        // 적 공격력 -> 충돌한 발사체 스프라이트에서 받아오기 
        // 애니멀도 발사체로 공격하는 걸로 해야 하나? 
        // 
    }
}
