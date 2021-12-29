using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_move1 : MonoBehaviour
{
    public float speed;
    public float damage;
    public float hp;
    public float cooltime;
    float speed_init;
    bool area; //�����ȿ� ��밡 �ִ���
    // Start is called before the first frame update
    void Start()
    {
        area = false;
        speed_init = speed;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime * 0.1F);
    }
    private void FixedUpdate()
    {
        if (area == true)
        {
            speed = 0F;
            if (Time.deltaTime == cooltime)
            {
                // ���� or  �� ü�� -= ������      
            }
        }
        if (area == false)
        {
            speed = speed_init;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = true;
            //Debug.LogError("�浹");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = false;
        }
    }
}
