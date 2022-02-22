using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal_HPbar : MonoBehaviour
{
    public Transform player;
    public Slider hpbar;
    float max_Hp;
    float now_Hp;
    public GameObject canvas;
    RectTransform HPbar;

    new Camera camera;


    private void Start()
    {
        Animal_life life = GetComponent<Animal_life>();
        life.MaxHP = max_Hp;
        life.NowHP = now_Hp;
        camera = Camera.main;
        HPbar = Instantiate(hpbar, canvas.transform).GetComponent<RectTransform>();
    }

    void Update()
    {
        Animal_life life = GetComponent<Animal_life>();
        now_Hp = life.NowHP;

        hpbar.value = now_Hp / max_Hp;
        HPbar.transform.position = camera.WorldToScreenPoint(player.position + new Vector3(0, 1.5f, 0));
        if(player.name == "raven" || player.name == "eagle")
        {
            HPbar.transform.position = camera.WorldToScreenPoint(player.position + new Vector3(0, 2.5f, 0));
        }
        if(hpbar.value == 0)
        {
            hpbar.IsDestroyed();
        }
    }
}
