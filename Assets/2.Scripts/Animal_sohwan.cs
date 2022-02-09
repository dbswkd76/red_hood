using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal_sohwan : MonoBehaviour
{
    public GameObject animal;
    public Slider slider;
    public Button button_1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SoHwan()
    {
        GameObject Instant;
        if (animal.name == "eagle")
        {
            Instant = Instantiate(animal, new Vector2(-5, 1), Quaternion.identity);
        }
        else
        {
            Instant = Instantiate(animal, new Vector2(-5, 0), Quaternion.identity);
        }
        Instant.name = animal.name;
        Instant.SetActive(true);
    }
}
