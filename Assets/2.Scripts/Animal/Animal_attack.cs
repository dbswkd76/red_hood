using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_attack : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.right *2000);

        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        Animal_life EnemyLife = collision.gameObject.GetComponent<Animal_life>();
        if (collision.gameObject.tag == "Enenmy")
        {
            EnemyLife.Damage();
            Destroy(gameObject);
        }
    }
}
