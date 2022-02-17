using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal_become : MonoBehaviour
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
            GameObject Instant;
            if (animal_1.name == "eagle")
            {
                Instant = Instantiate(animal_1, new Vector2(-5, 1), Quaternion.identity);
            }
            else
            {
                Instant = Instantiate(animal_1, new Vector2(-5, 0), Quaternion.identity);
            }
            Instant.name = animal_1.name;
            Instant.SetActive(true);
            
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameObject Instant;
            if (animal_2.name == "eagle")
            {
                Instant = Instantiate(animal_1, new Vector2(-5, 1), Quaternion.identity);
            }
            else
            {
                Instant = Instantiate(animal_2, new Vector2(-5, 0), Quaternion.identity);
            }
            Instant.name = animal_2.name;
            Instant.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject Instant;
            if (animal_3.name == "eagle")
            {
                Instant = Instantiate(animal_1, new Vector2(-5, 1), Quaternion.identity);
            }
            else
            {
                Instant = Instantiate(animal_3, new Vector2(-5, 0), Quaternion.identity);
            }
            Instant.name = animal_3.name;
            Instant.SetActive(true);
            
        }
    }
}
