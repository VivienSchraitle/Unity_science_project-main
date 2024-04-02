using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using Microsoft.MixedReality.Toolkit;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using Color = UnityEngine.Color;
using Random = System.Random;

public class ColorManager : MonoBehaviour
{
    
    public GameObject headTilt;
    public GameObject headSideTilt;
    public GameObject neckTorsion;
    public GameObject neckTilt;
    public GameObject bodyTilt;
    public GameObject bodySideTilt;
    public GameObject backTilt;
    public GameObject backTorsion;
    public GameObject shoulderAdductionL;
    public GameObject shoulderAdductionR;
    public GameObject shoulderFlexionL;
    public GameObject shoulderFlexionR;
    public GameObject shoulderRotationL;
    public GameObject shoulderRotationR;
    public GameObject elbowFlexionL;
    public GameObject elbowFlexionR;
    public GameObject handflexionL;
    public GameObject handflexionR;
    public GameObject handRadicalL;
    public GameObject handRadicalR;
    public GameObject kneeStand;

    public TMP_Text textMeshPro; // Reference to the Text Mesh Pro object
    public RectTransform planeRectTransform; // Reference to the RectTransform component of the plane
    public int mode = 1;
    public List<Tuple<string, string>> data;
    private Color orange = new Color(1.0f, 0.5f, 0.0f, 1.0f);
    private bool isUpdatingColors = false;
    // Start is called before the first frame update

    public String[] RawDataArray;
    public String[] RawDataArray2;
    public MQTTColor MQTTColor;
    private string color;

    private static ColorManager _singleton;
    public static ColorManager Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"[{nameof(ColorManager)}] Instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    void Start()
    {
        if (!isUpdatingColors)
        {
            StartCoroutine(ContinuousColorUpdate());
        }
    }

    // Update is called once per frame
    private IEnumerator ContinuousColorUpdate()
    {
        isUpdatingColors = true;

        while (isUpdatingColors)
        {
           // Debug.Log("starting routine");
            UpdateColorsAtReasonableSpeed();
            yield return new WaitForSeconds(0.05f); // Adjust the delay as needed
        }

        isUpdatingColors = false;
    }

    public void UpdateColorsAtReasonableSpeed()
    {
        List<Tuple<string, string>> data = new List<Tuple<string, string>>();
        /*
        data = new List<Tuple<string, string>>(21);
        for (int i = 0; i < 21; i++)
        {
            data.Add(new Tuple<string, string>(null, null));
        }
        */
        char[] helper = new char[1];
        helper[0] = (char)',';
        if (MQTTColor.RawData != "")
        {
            RawDataArray = MQTTColor.RawData.Split(helper);
            //RawDataArray2 = MQTTColor.RawData2.Split(helper);
        }        

        //Faithfull implenetation was to slow therefore the kafka and microservices have been used for data logging and the mqtt has been used directly
       /* if (RawDataArray.Length> 1f)
        {
            Debug.Log(RawDataArray[0]);
//            Debug.Log("RawDataArray.Length> 1");
            //data formating
            
            if (float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[0] = Tuple.Create(color, RawDataArray[0].ToString());

            if (float.Parse(RawDataArray[1], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data[1] = Tuple.Create(color, RawDataArray[1].ToString());

            if (float.Parse(RawDataArray[2], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data[2] = Tuple.Create(color, RawDataArray[2].ToString());

            if (float.Parse(RawDataArray[3], CultureInfo.InvariantCulture.NumberFormat) ==  0f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data[3] = Tuple.Create(color, RawDataArray[3].ToString());
            if (float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[4] = Tuple.Create(color, RawDataArray[4].ToString());
            if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[5] = Tuple.Create(color, RawDataArray[5].ToString());
            if (float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) ==  0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[6] = Tuple.Create(color, RawDataArray[6].ToString());
            if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[7] = Tuple.Create(color, RawDataArray[7].ToString());
            if (float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[8] = Tuple.Create(color, RawDataArray[8].ToString());
            if (float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[9] = Tuple.Create(color, RawDataArray[9].ToString());

            if (float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[10] = Tuple.Create(color, RawDataArray[10].ToString());

        }
        if (RawDataArray2.Length> 1f)
        {
            if (float.Parse(RawDataArray2[0], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[0], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[11] = Tuple.Create(color, RawDataArray2[0].ToString());

            if (float.Parse(RawDataArray2[1], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[1], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[12] = Tuple.Create(color, RawDataArray2[1].ToString());
            if (float.Parse(RawDataArray2[2], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[2], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[13] = Tuple.Create(color, RawDataArray2[2].ToString());
            if (float.Parse(RawDataArray2[3], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data[14] = Tuple.Create(color, RawDataArray2[3].ToString());
            if (float.Parse(RawDataArray2[4], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[4], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[15] = Tuple.Create(color, RawDataArray2[4].ToString());
            if (float.Parse(RawDataArray2[5], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[5], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }
        

            // Create tuple and add to the array
            data[16] = Tuple.Create(color, RawDataArray2[5].ToString());
            if (float.Parse(RawDataArray2[6], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[6], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[17] = Tuple.Create(color, RawDataArray2[6].ToString());
            if (float.Parse(RawDataArray2[7], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[7], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }

        
            // Create tuple and add to the array
            data[18] = Tuple.Create(color, RawDataArray2[7].ToString());
            if (float.Parse(RawDataArray2[8], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[8], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[19] = Tuple.Create(color, RawDataArray2[8].ToString());
            if (float.Parse(RawDataArray2[9], CultureInfo.InvariantCulture.NumberFormat) == 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray2[9], CultureInfo.InvariantCulture.NumberFormat) == 1f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data[20] = Tuple.Create(color, RawDataArray2[9].ToString());
           // Debug.Log("exiting if");
        



            }
        // suspend execution for 0.1 seconds
        */


        if (RawDataArray.Length> 1)
            {
//            Debug.Log("RawDataArray.Length> 1");
            //data formating
            string color;
            if (float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) < 25f && float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) >= -5f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) < 85 && float.Parse(RawDataArray[0], CultureInfo.InvariantCulture.NumberFormat) >= 25f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[0].ToString()));

            if (float.Parse(RawDataArray[1], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[1], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[1].ToString()));

            if (float.Parse(RawDataArray[2], CultureInfo.InvariantCulture.NumberFormat) < 45f && float.Parse(RawDataArray[2], CultureInfo.InvariantCulture.NumberFormat) >= -45f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[2].ToString()));

            if (float.Parse(RawDataArray[3], CultureInfo.InvariantCulture.NumberFormat) < 25f && float.Parse(RawDataArray[3], CultureInfo.InvariantCulture.NumberFormat) >= -5f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[3].ToString()));
            if (float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) >= -5f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) < 60 && float.Parse(RawDataArray[4], CultureInfo.InvariantCulture.NumberFormat) >= 20f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[4].ToString()));
            if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) > -20f && float.Parse(RawDataArray[5], CultureInfo.InvariantCulture.NumberFormat) <= -10f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[5].ToString()));
            if (float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) >= 0f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) < 40f && float.Parse(RawDataArray[6], CultureInfo.InvariantCulture.NumberFormat) >= 20f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[6].ToString()));
            if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) < 20 && float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) > -20 && float.Parse(RawDataArray[7], CultureInfo.InvariantCulture.NumberFormat) <= -10f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[7].ToString()));
            if (float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) < 10 && float.Parse(RawDataArray[8], CultureInfo.InvariantCulture.NumberFormat) >= -60f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[8].ToString()));
            if (float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) < 10 && float.Parse(RawDataArray[9], CultureInfo.InvariantCulture.NumberFormat) >= -60f)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[9].ToString()));

            if (float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) >= -5)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[10], CultureInfo.InvariantCulture.NumberFormat) >= 20)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[10].ToString()));
            if (float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) >= -5)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[11], CultureInfo.InvariantCulture.NumberFormat) >= 20)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[11].ToString()));

            if (float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) < 30f && float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) >= -15)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) >= 30)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) < -15f && float.Parse(RawDataArray[12], CultureInfo.InvariantCulture.NumberFormat) >= -30)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[12].ToString()));
            if (float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) < 30f && float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) >= -15)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) >= 30)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) < -15f && float.Parse(RawDataArray[13], CultureInfo.InvariantCulture.NumberFormat) >= -30)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[13].ToString()));
            if (float.Parse(RawDataArray[14], CultureInfo.InvariantCulture.NumberFormat) < 100f && float.Parse(RawDataArray[14], CultureInfo.InvariantCulture.NumberFormat) >= 60)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[14].ToString()));
            if (float.Parse(RawDataArray[15], CultureInfo.InvariantCulture.NumberFormat) < 100f && float.Parse(RawDataArray[15], CultureInfo.InvariantCulture.NumberFormat) >= 60)
            {
                color = "green";
            }
            else
            {
                color = "orange";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[15].ToString()));
            if (float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) < -25f && float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) >= -50f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[16], CultureInfo.InvariantCulture.NumberFormat) >= 45f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[16].ToString()));
            if (float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) < -25f && float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) >= -50f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) < 20f && float.Parse(RawDataArray[17], CultureInfo.InvariantCulture.NumberFormat) >= 45f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[17].ToString()));
            if (float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) < 15f && float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) < -10f && float.Parse(RawDataArray[18], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[18].ToString()));
            if (float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) < 10f && float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) >= -10f)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) < 15f && float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) >= 10f)
            {
                color = "orange";
            }
            else if (float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) < -10f && float.Parse(RawDataArray[19], CultureInfo.InvariantCulture.NumberFormat) >= -25f)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[19].ToString()));
            if (float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) < 30f && float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) >= -10)
            {
                color = "green";
            }
            else if (float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) < 60f && float.Parse(RawDataArray[20], CultureInfo.InvariantCulture.NumberFormat) >= 30)
            {
                color = "orange";
            }
            else
            {
                color = "red";
            }


            // Create tuple and add to the array
            data.Add(Tuple.Create(color, RawDataArray[20].ToString()));
           // Debug.Log("exiting if");
        }





        
//        Debug.Log("I am here");
        if (data.Count > 1)
        {
            if (mode == 1)
            {
                if (data[0].Item1 == "red")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[0].Item1 == "orange")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[1].Item1 == "red")
                {
                    headSideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[1].Item1 == "orange")
                {
                    headSideTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    headSideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[2].Item1 == "red")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[2].Item1 == "orange")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[3].Item1 == "red")
                {
                    neckTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[3].Item1 == "orange")
                {
                    neckTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    neckTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[4].Item1 == "red")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[4].Item1 == "orange")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[5].Item1 == "red")
                {
                    bodySideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[5].Item1 == "orange")
                {
                    bodySideTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    bodySideTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[6].Item1 == "red")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[6].Item1 == "orange")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[7].Item1 == "red")
                {
                    backTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[7].Item1 == "orange")
                {
                    backTorsion.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    backTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[8].Item1 == "red")
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[8].Item1 == "orange")
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderAdductionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[9].Item1 == "red")
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[9].Item1 == "orange")
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderAdductionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[10].Item1 == "red")
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[10].Item1 == "orange")
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[11].Item1 == "red")
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[11].Item1 == "orange")
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[12].Item1 == "red")
                {
                    shoulderRotationL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[12].Item1 == "orange")
                {
                    shoulderRotationL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderRotationL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[13].Item1 == "red")
                {
                    shoulderRotationR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[13].Item1 == "orange")
                {
                    shoulderRotationR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderRotationR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[14].Item1 == "red")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[14].Item1 == "orange")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[15].Item1 == "red")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[15].Item1 == "orange")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[16].Item1 == "red")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[16].Item1 == "orange")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[17].Item1 == "red")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[17].Item1 == "orange")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[18].Item1 == "red")
                {
                    handRadicalL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[18].Item1 == "orange")
                {
                    handRadicalL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handRadicalL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[19].Item1 == "red")
                {
                    handRadicalR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[19].Item1 == "orange")
                {
                    handRadicalR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handRadicalR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[20].Item1 == "red")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[20].Item1 == "orange")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
            }
            else if (mode == 2)
            {
                if (data[0].Item1 == "red" || data[1].Item1 == "red")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[0].Item1 == "orange" || data[1].Item1 == "orange")
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    headTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[2].Item1 == "red" || data[3].Item1 == "red")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[2].Item1 == "orange" || data[3].Item1 == "orange")
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    neckTorsion.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[4].Item1 == "red" || data[5].Item1 == "red")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[4].Item1 == "orange" || data[5].Item1 == "orange")
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    bodyTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[6].Item1 == "red" || data[7].Item1 == "red")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[6].Item1 == "orange" || data[7].Item1 == "orange")
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    backTilt.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[8].Item1 == "red" || data[10].Item1 == "red" || data[12].Item1 == "red")
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[8].Item1 == "orange" || data[10].Item1 == "orange" || data[12].Item1 == "orange")
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[9].Item1 == "red" || data[11].Item1 == "red" || data[13].Item1 == "red")
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[9].Item1 == "orange" || data[11].Item1 == "orange" || data[13].Item1 == "orange")
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    shoulderFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[14].Item1 == "red")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[14].Item1 == "orange")
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[15].Item1 == "red")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[15].Item1 == "orange")
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    elbowFlexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[16].Item1 == "red" || data[18].Item1 == "red")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[16].Item1 == "orange" || data[18].Item1 == "orange")
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionL.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[17].Item1 == "red" || data[19].Item1 == "red")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[17].Item1 == "orange" || data[19].Item1 == "orange")
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    handflexionR.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
                if (data[20].Item1 == "red")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.red;
                }
                else if (data[20].Item1 == "orange")
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = orange;
                }
                else
                {
                    kneeStand.GetComponentInChildren<SpriteRenderer>().color = Color.green;
                }
            }
            else if (mode == 3)
            {
                String text = "";
                if (data[0].Item1 == "red" || data[1].Item1 == "red")
                {
                    text = text + "Head\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[2].Item1 == "red" || data[3].Item1 == "red")
                {
                    text = text + "Neck\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[4].Item1 == "red"||data[5].Item1 == "red"||data[6].Item1 == "red"||data[7].Item1 == "red")
                {
                    text = text + "Spine\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[10].Item1 == "red"||data[12].Item1 == "red"||data[14].Item1 == "red")
                {
                    text = text + "Left Arm\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[11].Item1 == "red"||data[13].Item1 == "red"||data[15].Item1 == "red")
                {
                    text = text + "Right Arm\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[16].Item1 == "red"||data[18].Item1 == "red")
                {
                    text = text + "Left Hand\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[17].Item1 == "red"||data[19].Item1 == "red")
                {
                    text = text + "Right Hand\n";
                }
                else
                {
                    text = text + "\n";
                }
                if (data[20].Item1 == "red")
                {
                    text = text + "Legs\n";
                }
                else
                {
                    text = text + "\n";
                }
                textMeshPro.text = text;
                Vector2 textSize = textMeshPro.GetRenderedValues(false);
                planeRectTransform.sizeDelta = new Vector2(textSize.x, textSize.y);
            }
        }
    }
}
