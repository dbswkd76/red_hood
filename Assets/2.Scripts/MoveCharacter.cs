using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCharacter: MonoBehaviour
{
    public float speed;
    Rigidbody2D rigid;
    public float maxSpeed;
    private Vector3 vector;
    SpriteRenderer spriteRenderer;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }
        float horizontal = Input.GetAxis("Horizontal");
        float offset = 0.5f + Input.GetAxis("Sprint") * 0.5f;
        float moveParameter = Mathf.Abs(horizontal * offset);

        animator.SetFloat("RunState", moveParameter);

        //방향전환
        //if (Input.GetButtonDown("Horizontal"))
        //  spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            animator.SetTrigger("Attack");
        }
    }
    void FixedUpdate()
    {
        //이동속도
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //최대 속도
        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);
    }

}
