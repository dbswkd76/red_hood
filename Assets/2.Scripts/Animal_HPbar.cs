using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal_HPbar : MonoBehaviour
{
    public Transform player;
    public Slider hpbar;
    public float max_Hp;
    public float now_Hp;

    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, 0);
        hpbar.value = now_Hp / max_Hp;
    }
}
