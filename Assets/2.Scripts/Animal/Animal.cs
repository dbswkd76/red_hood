using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] int A_nowhp;
    [SerializeField] int A_maxhp;
    [SerializeField] int A_damage;
    [SerializeField] Slider HpBar;
    [SerializeField] List<Transform> obj;
    [SerializeField] List<GameObject> hp_bar;
    new Camera camera;
    private void HandleHp() 
    {
        HpBar.value = (float)A_nowhp / (float)A_maxhp;
    }
    private void SetEnemyStat(int maxhp, int damage)
    {
        A_nowhp = maxhp;
        A_maxhp = maxhp;
        A_damage = damage;
    }



    // Start is called before the first frame update
    void Start()
    {
        //camera = Camera.main;
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = obj[i].position;
        }
        HpBar.value = (float)A_nowhp / (float)A_maxhp;
        if (name.Equals("bear"))
        {
            SetEnemyStat(50 , 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleHp();
        for (int i = 0; i < obj.Count; i++)
        {
            hp_bar[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 1f, 0));
        }
        if (A_nowhp <= 0) // Àû »ç¸Á
        {
            Invoke("DieDestroyAfter", 1f);
            Destroy(HpBar.gameObject);
        }
    }
    void DieDestroyAfter()
    {
        Destroy(gameObject);
    }
}
