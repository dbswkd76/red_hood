using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField]
    private float speed;
    protected Vector2 direction;
    protected Animator myAnimator;

    private Rigidbody2D myRigid2D;
    protected bool isAttacking = false;
    protected Coroutine attackRoutine;
   
    public enum LayerName // ���,�̵�
    {
        IdleLayer = 0,
        WalkLayer = 1,
        AttackLayer = 2
    }

    //�̵� ���� ����
    public bool IsMoving
    {
        get
        {
            return direction.x != 0 || direction.y != 0;
        }
    }
    // Start is called before the first frame update
     protected virtual void Start()
    {
        myRigid2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();

    }

    // Update is called once per frame
    protected virtual void Update()
    {

        HandleLayers();
        //AnimatorMovement();
        

       
    }
    private void FixedUpdate()
    {
        Move();
    }
    public void Move()
    {
        transform.Translate(direction * speed * Time.deltaTime * -1f);
        
       
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
    }

    public void ActivateLayer(LayerName layerName)
    {
       
    }
    
    /*public void AnimatorMovement()
    {
        animator.SetFloat("x", direction.x);
        animator.SetFloat("y", direction.y);
    }*/
    
    
}
