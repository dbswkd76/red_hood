using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    public GameObject DeckUi;
    bool activeDeck = false;

    private void Start()
    {
        DeckUi.SetActive(activeDeck);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            activeDeck = !activeDeck;
            DeckUi.SetActive(activeDeck);
        }
    } 
    // Start is called before the first frame update

}
