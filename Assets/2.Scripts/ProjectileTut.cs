using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileTut : MonoBehaviour
{
    // Start is called before the first frame update
    private bool collided;
    public GameObject impactVFX;
    void OnCollisionEnter(Collision co)
    {
        if(co.gameObject.tag!="Bullet"&&co.gameObject.tag != "Player" &&!collided)
        {
            collided = true;

            var impact = Instantiate(impactVFX, co.contacts[0].point, Quaternion.identity) as GameObject;

            Destroy(impact, 2);
            Destroy(gameObject);
        }
    }
}
