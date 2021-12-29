using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class O_become : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject prefab;
    public Transform parent;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject inst = Instantiate(prefab, new Vector2(0,0), Quaternion.identity);
        }
    }
}
