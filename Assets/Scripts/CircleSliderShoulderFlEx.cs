using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CircleSliderShoulderFlEx : MonoBehaviour
{
    public Image _barL;//Bar
    public Image _barR;//Bar
    public ValueArmRight   ScriptArmRight;
    public ValueArmLeft    ScriptArmLeft;

    private  float ShoulderFlExValueRight;
    private float ShoulderFlExValueLeft;

    // Update is called once per frame
    void Update()
    {
         ShoulderFlExValueRight = ScriptArmRight.ShFlExAngle;
        ShoulderFlExValueLeft = ScriptArmLeft.ShFlExAngle;

        HealthChange(ShoulderFlExValueLeft, ShoulderFlExValueRight);
    }
    void HealthChange(float ShoulderFlExValueLeft, float ShoulderFlExValueRight ){
        float amountA = ((ShoulderFlExValueLeft)/200.0f) * 250.0f/360;
        float amountB = ((ShoulderFlExValueRight)/200.0f) * 250.0f/360;

        _barL.fillAmount = amountA;
        _barR.fillAmount = amountB;
        

    }
}
