using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    protected Vector2 direction;
    private Rigidbody2D myRigid2D;
    protected bool isAttacking = false;
    protected Coroutine attackRoutine;
    public SpriteRenderer spriteRenderer;
    [SerializeField]
    public State mana;
    [SerializeField]
    public State health;
    [SerializeField]
    protected float initHealth;
    [SerializeField]
    private float speed;

    public Panel_GameOver panel_GameOver; // ���ӿ��� �ǳ�
    public bool die;
    public bool isUnBeatTime;
    Animator animator;

    private float initMana = 50;
    public enum LayerName // ���,�̵�
    {
        IdleLayer = 0,
        WalkLayer = 1,
        AttackLayer = 2
    }

    // Start is called before the first frame update
    protected void Start()
    {
        die = false;
        Time.timeScale = 1f;
        direction = Vector2.zero;
        health.Intialize(initHealth, initHealth);
        mana.Intialize(initMana, initMana);
        myRigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    protected  void Update()
    {
        GetInput();
        
        HandleLayers();
        if (die == false)
        {
            if (health.MyCurrentValue == 0)
            {
                
            }
            Move();
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
            if (!die)
            {
                StartCoroutine(Die());
            }
        }

        if (health.MyCurrentValue > 1)
        {
            isUnBeatTime = true;
            StartCoroutine("UnBeatTime");
        }

    }
    public void HandleLayers()
    {
        if (IsMoving)
        {
            ActivateLayer(LayerName.WalkLayer);
        }
        else
        {
            ActivateLayer(LayerName.IdleLayer);
        }
    }// ���� �ִϸ��̼�

    public void ActivateLayer(LayerName layerName)
    {

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

    } //Ű�����Է�
    IEnumerator Die()
    {
        die = true;
        animator.SetTrigger("Die");
        yield return new WaitForSeconds(2f);
        Debug.Log("die");
        GameOver();
    }
    IEnumerator UnBeatTime() //�ǰ� �� �����ð�
    {
        int countTime = 0;

        while (countTime < 10){
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }
            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);
        isUnBeatTime = false;

        yield return null;
    }
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime * -1f);
    }
    public void GameOver()
    {
        Time.timeScale = 0f;
        panel_GameOver.Show();
    }
}


// Update is called once per frame


