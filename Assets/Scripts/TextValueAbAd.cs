using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //you need this to be able to access the Text Component
using TMPro;
public class TextValueAbAd : MonoBehaviour
{
    public ValueArmLeft  ScriptLeftArmValues;
    public ValueArmRight ScriptRightArmValues;
    public TextMeshProUGUI TextAbAdLeft;
    public TextMeshProUGUI TextAbAdRight;

    // Update is called once per frame
    void Update()
    {
        TextAbAdLeft.text =  ScriptLeftArmValues.ShAdAbAngle.ToString("n2") + "°deg";
        TextAbAdRight.text = ScriptRightArmValues.ShAdAbAngle.ToString("n2") + "°deg";
    }
}
