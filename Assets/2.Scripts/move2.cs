using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float myspeed;
    float myspeedinit;
    GameObject enemy;
    bool area;
    Vector3 e_position;
    Vector3 my_position;
    void Start()
    {
        myspeedinit = myspeed;
        area = false;
        enemy = GameObject.FindGameObjectWithTag("enemy");
        e_position = enemy.gameObject.transform.position;
        my_position = this.gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (area == false)
        {
            transform.Translate(Vector2.right * myspeed * Time.deltaTime * 0.1F);
        }
         
    }

    private void FixedUpdate()
    {
        float e_pos_x = e_position.x;
        float my_pos_x = my_position.x;
        if (e_pos_x - my_pos_x <= 0.5F)
        {
            area = true;
        }
        else area = false;
    }
}
