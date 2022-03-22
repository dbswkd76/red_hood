using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bull : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float distance;
    public LayerMask isLayer;
    public Enemy enemy;


    void Start()
    {
        Invoke("DestroyBullet", 2);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, transform.right, distance, isLayer);
        if (ray.collider != null)
        {
                if(ray.collider.tag =="Enemy")
            {
                enemy.EnemyDamaged(10);
                Debug.Log("hit");
            }
            DestroyBullet();
        }
        if (transform.rotation.y!= 0)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(transform.right * -1 * speed * Time.deltaTime);

        }
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
