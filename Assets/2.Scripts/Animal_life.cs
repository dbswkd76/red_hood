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
        //�ǰ� ����
        // health = life - ���ݷ�
        if (health == 0)
        {
            animator.SetBool("die", true);
        }
    }

    // ���� �ް�, ���� ���� = ���� - �� ���ݷ� 
    // �� ���ݷ� -> �浹�� �߻�ü ��������Ʈ���� �޾ƿ��� 
    // �ִϸֵ� �߻�ü�� �����ϴ� �ɷ� �ؾ� �ϳ�? 
    // 
}
