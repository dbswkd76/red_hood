using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_attack : MonoBehaviour
{
    public int damage;
    Enemy EnemyLife;
    GameObject animal;

    private void Update()
    {
        transform.Translate(Vector2.right * Time.deltaTime);
    }
    //private void OnTriggerEnter2D(Collider2D collider2D)
    //{
    //    if (collider2D.gameObject.tag.CompareTo("Enemy") == 0)
    //    {
    //        EnemyLife.EnemyDamaged(damage);
    //        Destroy(gameObject);
    //    }
    //}
}
