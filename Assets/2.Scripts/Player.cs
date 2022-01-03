using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
  
    
    [SerializeField]
    public State mana;
    [SerializeField]
    public State health;
    [SerializeField]
    protected float initHealth;
    public Panel_GameOver panel_GameOver; // ���ӿ��� �ǳ�
    public bool die;

    Animator animator;
    
    private float initMana = 50;

    // Start is called before the first frame update
    protected override void Start()
    {
        die = false;
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
        if (die == false)
        {
            float horizontal = Input.GetAxis("Horizontal"); //�¿� ����Ű �Է�
            float offset = 0.5f + Input.GetAxis("Sprint");
            float moveParameter = Mathf.Abs(horizontal * offset); //�Ķ���� ���밪 ����
            animator.SetFloat("RunState", moveParameter);


            if (Input.GetAxisRaw("Horizontal") < 0) //�÷��̾� �̹��� �¿����
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (Input.GetAxisRaw("Horizontal") > 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
        if (health.MyCurrentValue <= 0)
        {
            StartCoroutine(Die());

        }

        }

    private void GetInput()
    {
        if (die == false)
        {
            Vector2 moveVector; //Ű���� �Է�

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

            if (Input.GetKeyDown(KeyCode.Z))  //�⺻����
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 0);
                animator.SetFloat("NormalState", 0);
                animator.SetFloat("SkillState", 0);
            }
            if (Input.GetKeyDown(KeyCode.X))  //Ȱ����
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 0);
                animator.SetFloat("NormalState", 0.5f);
                animator.SetFloat("SkillState", 0);
            }
            if (Input.GetKeyDown(KeyCode.C))  //��������
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 0);
                animator.SetFloat("NormalState", 1);
                animator.SetFloat("SkillState", 0);
            }
            if (Input.GetKeyDown(KeyCode.Q))  //�⺻��ų
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 1);
                animator.SetFloat("NormalState", 0);
                animator.SetFloat("SkillState", 0);
            }
            if (Input.GetKeyDown(KeyCode.W))  //Ȱ��ų
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 1);
                animator.SetFloat("NormalState", 0);
                animator.SetFloat("SkillState", 0.5f);
            }
            if (Input.GetKeyDown(KeyCode.E))  //������ų
            {
                animator.SetTrigger("Attack");
                animator.SetFloat("AttackState", 1);
                animator.SetFloat("NormalState", 0);
                animator.SetFloat("SkillState", 1);
            }
        }
            
        }
    IEnumerator Die()
    {
        die = true;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        GameOver();
    }
    


    public void GameOver()
    {
        panel_GameOver.Show();
    }
}
    
    
    // Update is called once per frame
    

