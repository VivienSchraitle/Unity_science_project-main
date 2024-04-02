using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //you need this to be able to access the Text Component
using TMPro;

public class TextValueFlEx : MonoBehaviour
{
    public ValueArmLeft  ScriptLeftArmValues;
    public ValueArmRight ScriptRightArmValues;
    public TextMeshProUGUI TextFlExLeft;
    public TextMeshProUGUI TextFlExRight;

    


    // Update is called once per frame
    void Update()
    {
        TextFlExLeft.text =  ScriptLeftArmValues.ShFlExAngle.ToString("n2") + "°deg";
        TextFlExRight.text = ScriptRightArmValues.ShFlExAngle.ToString("n2") + "°deg";
    }
}
