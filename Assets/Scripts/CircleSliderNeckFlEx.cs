using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSliderNeckFlEx : MonoBehaviour
{
    public Image _barNeck;//Bar
    public ValueNeckHead   ScriptNeckHead;
    private  float NeckFlExValue;

    void Start() {
        _barNeck.fillAmount = 90;
    }

    // Update is called once per frame
    void Update()
    {
        NeckFlExValue = ScriptNeckHead.NeckFlExAngle;

        HealthChange(NeckFlExValue);
    }

    void HealthChange(float NeckFlExValue){
        float amount = ((NeckFlExValue)/90.0f) * 90.0f/360;
        _barNeck.fillAmount = amount; 
    }
}
