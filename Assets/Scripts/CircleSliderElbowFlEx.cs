using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSliderElbowFlEx : MonoBehaviour
{
    public Image _barL;//Bar
    public Image _barR;//Bar
    public ValueArmRight   ScriptArmRight;
    public ValueArmLeft    ScriptArmLeft;

    private  float ElbowFlExValueRight;
    private float ELbowFlExValueLeft;

    // Update is called once per frame
    void Update()
    {
        ElbowFlExValueRight = ScriptArmRight.ELbowAngle;
        ELbowFlExValueLeft = ScriptArmLeft.ELbowAngle;
        HealthChange(ElbowFlExValueRight, ELbowFlExValueLeft);
    }
    void HealthChange(float ELbowFlExValueLeft, float ElbowFlExValueRight ){
        float amountA = ((ELbowFlExValueLeft)/180.0f) * 180.0f/360;
        float amountB = ((ElbowFlExValueRight)/180.0f) * 180.0f/360;

        _barL.fillAmount = amountA;
        _barR.fillAmount = amountB;
        

    }
}   
