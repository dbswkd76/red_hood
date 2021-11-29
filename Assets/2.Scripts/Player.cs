using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
  
    [SerializeField]
    private State health;

    [SerializeField]
    private State mana;

    Animator animator;
    private float initHealth = 100;
    private float initMana = 50;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
        health.Intialize(initHealth, initHealth);
        mana.Intialize(initMana, initMana);

        
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected override void Update()
    {
        GetInput();
    
        base.Update();

        float horizontal  = Input.GetAxis("Horizontal")  ; //좌우 방향키 입력
        float offset = 0.5f + Input.GetAxis("Sprint")  ;
        float moveParameter = Mathf.Abs(horizontal * offset ); //파라미터 절대값 적용
        animator.SetFloat("RunState", moveParameter);


        if(Input.GetAxisRaw("Horizontal") < 0) //플레이어 이미지 좌우반전
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        
       // if(Input.ke)

    }
   
    private void GetInput()
    {
        Vector2 moveVector; //키보드 입력

        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");

        direction = moveVector;

        if (Input.GetKeyDown(KeyCode.I))
        {
            health.MyCurrentValue -= 10;
            mana.MyCurrentValue -= 10;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            health.MyCurrentValue += 10;
            mana.MyCurrentValue += 10;
        }

        if (Input.GetKeyDown(KeyCode.Z))  //기본공격
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("AttackState", 0);
            animator.SetFloat("NormalState", 0);
            animator.SetFloat("SkillState", 0);
        }
        if (Input.GetKeyDown(KeyCode.X))  //활공격
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("AttackState", 0);
            animator.SetFloat("NormalState", 0.5f);
            animator.SetFloat("SkillState", 0);
        }
        if (Input.GetKeyDown(KeyCode.C))  //마법공격
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("AttackState", 0);
            animator.SetFloat("NormalState", 1);
            animator.SetFloat("SkillState", 0);
        }
        if (Input.GetKeyDown(KeyCode.Q))  //기본스킬
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("AttackState", 1);
            animator.SetFloat("NormalState", 0);
            animator.SetFloat("SkillState", 0);
        }
        if (Input.GetKeyDown(KeyCode.W))  //활스킬
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("AttackState", 1);
            animator.SetFloat("NormalState", 0);
            animator.SetFloat("SkillState", 0.5f);
        }
        if (Input.GetKeyDown(KeyCode.E))  //마법스킬
        {
            animator.SetTrigger("Attack");
            animator.SetFloat("AttackState", 1);
            animator.SetFloat("NormalState", 0);
            animator.SetFloat("SkillState", 1);
        }
    }
    
    // Update is called once per frame
    
}
