using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //you need this to be able to access the Text Component
using TMPro;
public class TextValueNeck : MonoBehaviour
{
    public ValueNeckHead   ScriptNeckHead;
    public TextMeshProUGUI TextNeckFlExValue;

    // Update is called once per frame
    void Update()
    {
    
    TextNeckFlExValue.text = ScriptNeckHead.NeckFlExAngle.ToString("n2") + "°deg";

    }
}
