using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_become : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject animal_1;
    public GameObject animal_2;
    public GameObject animal_3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject Instant =  Instantiate(animal_1, new Vector2(-5,0), Quaternion.identity);
            Instant.name = "animal_1";
            Instant.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject Instant = Instantiate(animal_2, new Vector2(-5, 0), Quaternion.identity);
            Instant.name = "animal_2";
            Instant.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject Instant = Instantiate(animal_3, new Vector2(-5, 0), Quaternion.identity);
            Instant.name = "animal_3";
            Instant.SetActive(true);
        }
    }
}