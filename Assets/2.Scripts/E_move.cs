using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_move : MonoBehaviour
{
    public float speed;
    float speed_in;
    bool area = false;

    // Start is called before the first frame update
    void Start()
    {
        speed_in = speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime * 0.1F);
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
        if (collision.gameObject.tag.CompareTo("our") == 0)
        {
            area = true;
            Debug.LogError("Ãæµ¹");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag.CompareTo("our") == 0)
        {
            area = false;
        }
    }
}
