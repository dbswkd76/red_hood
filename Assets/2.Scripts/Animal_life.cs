using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_life : MonoBehaviour
{
    // Start is called before the first frame update
    public int MaxHP;
    static public float NowHP = 10;
    public Animator animator;
    static public bool attack = false;
    public float range;

    void Start()
    {
        NowHP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        //�ǰ� ����
        // nowhp = maxhp - ���ݷ�
        //maxhp = nowhp
        if (NowHP == 0)
        {
            animator.SetBool("die", true);
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D animal_attack = Physics2D.Raycast(transform.position, new Vector2(-1 * range, 2
            ));
        if (animal_attack.collider != null)
        {

            Debug.Log(animal_attack.collider.name);
        }

        // ���� �ް�, ���� ���� = ���� - �� ���ݷ� 
        // �� ���ݷ� -> �浹�� �߻�ü ��������Ʈ���� �޾ƿ��� 
        // �ִϸֵ� �߻�ü�� �����ϴ� �ɷ� �ؾ� �ϳ�? 
        // 
    }
}