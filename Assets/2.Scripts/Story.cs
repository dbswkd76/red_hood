using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Story : MonoBehaviour
{
    Camera camera;
    [SerializeField] List<Transform> obj;
    [SerializeField] List<GameObject> text;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        for (int i = 0; i < obj.Count; i++)
        {
            text[i].transform.position = obj[i].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < obj.Count; i++)
        {
            text[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 0.5f, 0));
        }
    }
}
