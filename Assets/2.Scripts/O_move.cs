using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_move : MonoBehaviour
{
    public float speed;
    float speed_init;
    bool area; //영역안에 상대가 있는지
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
            //Debug.LogError("충돌");
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
