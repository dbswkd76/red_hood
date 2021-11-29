using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2 : MonoBehaviour
{
    // Start is called before the first frame update
    public float myspeed;
    float myspeedinit;
    GameObject Enemy;
    GameObject Our;
    bool area;
    Vector3 e_position;
    Vector3 o_position;
    E_move e_move = GameObject.Find("enemy").GetComponent<E_move>();
    void Start()
    {
        myspeedinit = myspeed;
        area = false;
        Enemy = GameObject.FindGameObjectWithTag("enemy");
        Our = GameObject.FindGameObjectWithTag("our");
        e_position = Enemy.gameObject.transform.position;
        o_position = this.gameObject.transform.position;
        }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * myspeed * Time.deltaTime * 0.1F);
    }

    private void FixedUpdate()
    {
        double e_pos_x = 5.0F - e_move.speed * Time.deltaTime * 0.1F;
        double o_pos_x = myspeed * Time.deltaTime * 0.1F;
        if (e_pos_x - o_pos_x <= 0.5 )
        {
            myspeed = 0;
            area = true;
            Debug.LogWarning("¸¸³²");
        }
        else area = false;
    }
}
