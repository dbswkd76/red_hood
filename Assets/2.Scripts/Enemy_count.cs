using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_count : MonoBehaviour
{
    public static int died_wolf;
    [SerializeField] int wolves;
    [SerializeField] GameObject Clearpanel;
    // Start is called before the first frame update
    void Start()
    {
        died_wolf = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (died_wolf == wolves)
            Clearpanel.SetActive(true);
    }
}
