using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSliderShoulderAbAd : MonoBehaviour
{
    public Image _barL;//Bar
    public Image _barR;//Bar
    public ValueArmRight   ScriptArmRight;
    public ValueArmLeft    ScriptArmLeft;

    private  float ShoulderAbAdValueRight;
    private float ShoulderAbAdValueLeft;

    // Update is called once per frame
    void Update()
    {   
        ShoulderAbAdValueRight = ScriptArmRight.ShAdAbAngle;
        ShoulderAbAdValueLeft = ScriptArmLeft.ShAdAbAngle;
        HealthChange(ShoulderAbAdValueRight, ShoulderAbAdValueLeft);
        
    }
    void HealthChange(float ShoulderAbAdValueLeft, float ShoulderAbAdValueRight ){
        float amountA = ((ShoulderAbAdValueLeft)/200.0f) * 250.0f/360;
        float amountB = ((ShoulderAbAdValueRight)/200.0f) * 250.0f/360;

        _barL.fillAmount = amountA;
        _barR.fillAmount = amountB;
      
    }
}
