using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Animal_sohwan : MonoBehaviour
{   
    public GameObject[] animalArr = new GameObject [8];
    public GameObject animal;
    [SerializeField] GameObject[] animal1 = new GameObject [8];
    [SerializeField] GameObject[] animal2 = new GameObject [8];
    [SerializeField] GameObject[] animal3 = new GameObject [8];
    public Slider slider;
    public deckInfo deckInfo;
    // Start is called before the first frame update
    void Start()
    {
        animal1[deckInfo.DeckArr[0]].SetActive(true);
        animal2[deckInfo.DeckArr[1]].SetActive(true);
        animal3[deckInfo.DeckArr[2]].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SoHwan()
    {
        string animalName = EventSystem.current.currentSelectedGameObject.name;
        Debug.Log(animalName);
        GameObject Instant;

        for(int i = 0; i<8;i++){
            if(animalName == animalArr[i].name){
                animal = animalArr[i];
            }
        }

        if (animal.name == "eagle")
        {
            Instant = Instantiate(animal, new Vector2(-5, -1f), Quaternion.identity);
        }
        else
        {
            Instant = Instantiate(animal, new Vector2(-5, -2f), Quaternion.identity);
        }
        Instant.name = animal.name;
        Instant.SetActive(true);
    }
}
