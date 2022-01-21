using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animal : MonoBehaviour
{
    [SerializeField] int m_nowhp;
    [SerializeField] int m_maxhp;
    [SerializeField] int m_damage;
    [SerializeField] Slider HpBar;
    [SerializeField] List<Transform> obj;
    [SerializeField] List<GameObject> hp_bar;
    new Camera camera;
    private void HandleHp() 
    {
        HpBar.value = (float)m_nowhp / (float)m_maxhp;
    }
    private void SetEnemyStat(int maxhp, int damage)
    {
        m_nowhp = maxhp;
        m_maxhp = maxhp;
        m_damage = damage;
    }



    // Start is called before the first frame update
    void Start()
    {
        HpBar.value = (float)m_nowhp / (float)m_maxhp;
        if (name.Equals("¿Ã∏ß"))
        {
            SetEnemyStat(50, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        HandleHp();
        for (int i = 0; i < obj.Count; i++) 
        { 
            hp_bar[i].transform.position = camera.WorldToScreenPoint(obj[i].position + new Vector3(0, 0.5f, 0)); 
        }
        if (m_nowhp <= 0) // ¿˚ ªÁ∏¡
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
