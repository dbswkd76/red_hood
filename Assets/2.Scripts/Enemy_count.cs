using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_count : MonoBehaviour
{
    public static int died_wolf;
    [SerializeField] int wolves;
    [SerializeField] Text left_wolf;
    [SerializeField] GameObject Clearpanel;
    // Start is called before the first frame update
    void Start()
    {
        died_wolf = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int a = wolves - died_wolf;
        left_wolf.text ="남은 늑대 : "+ a.ToString()+"마리";
        if (died_wolf == wolves)
        {
            Clearpanel.SetActive(true);
            left_wolf.gameObject.SetActive(false);
        }
    }
}
