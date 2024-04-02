using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using System;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using Random = System.Random;
using System.Threading;
using Microsoft.MixedReality.Toolkit;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject mrtkCubePrefab; // Assign the MRTK cube prefab in the Inspector.
    private GameObject instantiatedCube;
    private Boolean rula;
    private Boolean reba;
    public TextMeshPro TextReba;
    public TextMeshPro TextRula;

    private MqttClient client;

    public GameObject QuadReba;
    public GameObject QuadRula;
    private Vector3 location;
    public GameObject canvas;
    private int mode = 2;
    public RadialView view;
    public SolverHandler handler;
    private Vector3 scaler = new Vector3(1, 1.26f, 0.01f);
    public ColorManager colorm;

    public MQTTColor mqttt;

    void Start()
    {
        CoreServices.SpatialAwarenessSystem.Disable();
        if (mrtkCubePrefab == null)
        {
            Debug.LogError("MRTK Cube Prefab is not assigned.");
        }
        


        //setRULA();
        //setREBA();
    }


    // Update is called once per frame
    void Update()
    {
        if(TextRula.enabled)
        {
            TextRula.text = mqttt.rula.ToString();
        }
        if(TextReba.enabled)
        {
            TextReba.text = mqttt.reba.ToString();
        }
        


        switch (mode)
        {
            case 1:
                setAngle();
                break;
            case 2:
                if (handler.isActiveAndEnabled == false)
                {
                    handler.enabled = true;
                }
                break;
            case 3:

            default:
                mode = 2;
                if (handler.isActiveAndEnabled == false)
                {
                    handler.enabled = true;
                }
                break;

        }
        if (handler.isActiveAndEnabled && mode != 2)
        {
            handler.enabled = false;
        }

    }
    public void Spawn() {
        if (instantiatedCube != null)
        {
            Destroy(instantiatedCube);
        }

        // Instantiate a new MRTK cube prefab.
        instantiatedCube = Instantiate(mrtkCubePrefab, Vector3.zero, Quaternion.identity);

        // Add any additional components or logic for cube manipulation here.

        // Example: Make the cube movable.
        var manipulator = instantiatedCube.AddComponent<ObjectManipulator>();
        manipulator.HostTransform = instantiatedCube.transform;

    }
    public void setREBA(byte[] msg) {
        TextReba.enabled = !TextReba.enabled;
        QuadReba.SetActive(QuadReba.activeSelf);  

        
    }
    public void setRULA(byte[] msg) {
        TextRula.enabled = !TextRula.enabled;
        QuadRula.SetActive(QuadRula.activeSelf);  

    }
    private void setAngle()
    {
        location = Camera.main.transform.position + Camera.main.transform.forward;
        canvas.transform.position = location + Camera.main.transform.up.normalized * (float)-0.1 + Camera.main.transform.right.normalized * (float)0.2;
        canvas.transform.rotation = Camera.main.transform.rotation;
    }

    public void setMode1()
    {
        mode = 1;
        AttachmentScript.Singleton.mode1();
    }
    public void setMode2()
    {
        mode = 2;
        AttachmentScript.Singleton.mode2();
    }
    public void setMode3()
    {
        AttachmentScript.Singleton.mode3();
    }
    public void setMode4()
    {
        mode = 4;
    }
    public void setMode5()
    {
        mode = 5;
    }
    public void setScale(SliderEventData sliderEventData)
    {
        canvas.transform.localScale = sliderEventData.NewValue * scaler;
    }
    public void test()
    { }

    private bool isUpdatingColors = false;

    public void RandomsWOOOO()
    {
        if (!isUpdatingColors)
        {
            StartCoroutine(ContinuousColorUpdate());
        }
    }

    private IEnumerator ContinuousColorUpdate()
    {
        isUpdatingColors = true;

        while (isUpdatingColors)
        {
            UpdateColorsAtReasonableSpeed();
            yield return new WaitForSeconds(0.2f); // Adjust the delay as needed
        }

        isUpdatingColors = false;
    }

    private void UpdateColorsAtReasonableSpeed()
    {
        //Debug.Log("updating data");
        //while (true)
        //{

            // Define the array of tuples
            List<Tuple<string, string>> colorNumberTuples = new List<Tuple<string, string>>();

            Random rand = new Random();


            // Fill the array with tuples
            for (int i = 0; i < 21; i++)
            {

                int randomNumber = rand.Next(1, 101); // Random int between 1 and 100

                // Assign color based on random number range
                string color;
                if (randomNumber <= 70)
                {
                    color = "green";
                }
                else if (randomNumber <= 90)
                {
                    color = "orange";
                }
                else
                {
                    color = "red";
                }

                // Create tuple and add to the array
                colorNumberTuples.Add(Tuple.Create(color, randomNumber.ToString()));
                
            }
            colorm.data = colorNumberTuples;
        //colorm.UpdateColorsAtReasonableSpeed();

        //}
    }
}

