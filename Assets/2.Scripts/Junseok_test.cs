using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Junseok_test : MonoBehaviour
{
    Rigidbody2D rigid;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            Debug.Log("Player : ´Á´ë¶û ºÎµúÈû");
            rigid.AddForce(new Vector2(-2, 3), ForceMode2D.Impulse);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
}
