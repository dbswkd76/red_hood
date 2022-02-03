using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject DeckUi;
    public static bool activeDeck = false;
    [SerializeField]
    public GameObject deckon;

    public void Start()
    {
        DeckUi.SetActive(activeDeck);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activeDeck = !activeDeck;
            DeckUi.SetActive(activeDeck);
        }
        
    } 
    // Start is called before the first frame update

}
