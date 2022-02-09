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
    public GameObject canvas;
    RectTransform HPbar;

    Camera camera;

    private void Start()
    {
        camera = Camera.main;
        HPbar = Instantiate(hpbar, canvas.transform).GetComponent<RectTransform>();
    }

    void Update()
    {
        hpbar.value = now_Hp / max_Hp;
        HPbar.transform.position = camera.WorldToScreenPoint(player.position + new Vector3(0, 1.5f, 0));
        if(player.name == "raven" || player.name == "eagle")
        {
            HPbar.transform.position = camera.WorldToScreenPoint(player.position + new Vector3(0, 2.5f, 0));
        }
    }
}
