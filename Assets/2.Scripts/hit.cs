using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit : MonoBehaviour
{
    public GameObject Hp;
    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Hp = GameObject.Find("health");
           // Hp -= 10;
        }
    }
}
