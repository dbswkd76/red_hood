using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_move : MonoBehaviour
{
    public float speed;
    float speed_in;
    bool area = false;
    Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        speed_in = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime * 0.1F);
    }

    private void FixedUpdate()
    {
        if (area == true)
        {
            speed = 0F;
        }
        if (area == false)
        {
            speed = speed_in;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = true;
            Debug.LogError("Ãæµ¹");
        }
        if (collision.gameObject.tag.CompareTo("our") == 0)
        {
            if (speed != 0F)
            {
                collision.collider.isTrigger = true;
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            area = false;
        }
        if (collision.gameObject.tag.CompareTo("our") == 0)
        {
            collision.collider.isTrigger = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.CompareTo("enemy") == 0)
        {
            collider.isTrigger = false;
        }
    }
}
