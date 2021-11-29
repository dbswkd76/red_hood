using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class State : MonoBehaviour
{
    private Image content;

    [SerializeField]
    private Text statText;
    
    [SerializeField]
    private float lerpSpeed;

    private float currentFill;
    public float MyMaxValue { get; set; }

    public float MyCurrentValue // 현재 체력 마나
    {
        get
        {
            return currentValue;
        }

        set
        {
            if (value > MyMaxValue) currentValue = MyMaxValue;
            else if (value < 0) currentValue = 0;
            else currentValue = value;

            currentFill = currentValue / MyMaxValue;
            statText.text = currentValue + " / " + MyMaxValue;
        }
    }

    private float currentValue;

    // Start is called before the first frame update
    void Start()
    {
        content = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentFill != content.fillAmount) // 체력,마나 값이 변경될 경우
        {
            content.fillAmount = Mathf.Lerp(content.fillAmount, currentFill, Time.deltaTime * lerpSpeed);
        }
    }

    public void Intialize(float currentValue, float maxValue)
    {
        MyMaxValue = maxValue;
        MyCurrentValue = currentValue;
    }
}
