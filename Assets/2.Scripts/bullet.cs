using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject shoot;
    public Transform pos;
    public float cooltime;
    private float curtime;
    public float cost;
    public Player die;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (curtime <= 0)
        {
            if (!die)
            {
                if (Input.GetKey(KeyCode.X))
                {
                    Instantiate(shoot, pos.position, transform.rotation);
                }
            }
            curtime = cooltime;
        }
        curtime -= Time.deltaTime;
    }
   
}
