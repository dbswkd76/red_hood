using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_attack : MonoBehaviour
{
    public float damage = 5;
    imsi EnemyLife;
    GameObject animal;

    private void Start()
    {
       // attack_balsa = animal.Animal_move.damage;
    }
    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyLife = collision.gameObject.GetComponent<imsi>();

        if (collision.gameObject.tag.CompareTo("Enemy") == 0)
        {
            EnemyLife.Damage(damage);
            Destroy(gameObject);
        }
    }
}
