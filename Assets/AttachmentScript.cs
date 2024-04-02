using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using Microsoft.MixedReality.Toolkit.UI;
using System;
using System.Linq;
using UnityEngine.Animations;
using UnityEngine.Events;
using Microsoft.MixedReality.Toolkit.Utilities;
using UnityEngine.EventSystems;

public class AttachmentScript : MonoBehaviour
{
    // Start is called before the first frame update

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
    public GameObject plane;
    public GameObject text;

    public GameObject mrtkCanvas;
    public ColorManager colorManager;
    private int mode = 1;


    private static AttachmentScript _singleton;
    public static AttachmentScript Singleton
    {
        get => _singleton;
        private set
        {
            if (_singleton == null)
                _singleton = value;
            else if (_singleton != value)
            {
                Debug.Log($"[{nameof(AttachmentScript)}] Instance already exists, destroying duplicate!");
                Destroy(value);
            }
        }
    }
    void Awake()
    {
        Singleton = this;
    }
    void Start()
    {
        colorManager = GameObject.FindObjectOfType<ColorManager>();
        mode1();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void mode1()
    {
        setMode(1);
        mrtkCanvas.GetComponent<MeshRenderer>().enabled = true;
        headTilt.SetActive(true);
        headTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        headTilt.transform.GetChild(0).localPosition = new Vector3(0.03f,0.4f,-0.01f);
        headTilt.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        headSideTilt.SetActive(true);
        headSideTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        headSideTilt.transform.GetChild(0).localPosition = new Vector3(-0.03f,0.4f,-0.01f);
        headSideTilt.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        neckTorsion.SetActive(true);
    	neckTorsion.transform.localPosition = new Vector3(0,0,-0.01f);
        neckTorsion.transform.GetChild(0).localPosition = new Vector3(-0.025f,0.336f,-0.01f);
        neckTorsion.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        neckTilt.SetActive(true);
        neckTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        neckTilt.transform.GetChild(0).localPosition = new Vector3(0.025f,0.336f,-0.01f);
        neckTilt.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        bodyTilt.SetActive(true);
        bodyTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        bodyTilt.transform.GetChild(0).localPosition = new Vector3(0,0.12f,-0.01f);
        bodyTilt.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);

        bodySideTilt.SetActive(true);
        bodySideTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        bodySideTilt.transform.GetChild(0).localPosition = new Vector3(0.075f,0.12f,-0.01f);
        bodySideTilt.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);
        
        backTilt.SetActive(true);
        backTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        backTilt.transform.GetChild(0).localPosition = new Vector3(-0.075f,0.12f,-0.01f);
        backTilt.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);

        backTorsion.SetActive(true);
        backTorsion.transform.localPosition = new Vector3(0,0,-0.01f);
        backTorsion.transform.GetChild(0).localPosition = new Vector3(0,0.26f,-0.01f);
        backTorsion.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);

        shoulderAdductionL.SetActive(true);
        shoulderAdductionL.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderAdductionL.transform.GetChild(0).localPosition = new Vector3(-0.26f,0.26f,-0.01f);
        shoulderAdductionL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);           
        
        shoulderAdductionR.SetActive(true);
        shoulderAdductionR.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderAdductionR.transform.GetChild(0).localPosition = new Vector3(0.26f,0.26f,-0.01f);
        shoulderAdductionR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderFlexionL.SetActive(true);
        shoulderFlexionL.transform.localPosition = new Vector3(0.105f, 0.262f, -0.1f);
        shoulderFlexionL.transform.GetChild(0).localPosition = new Vector3(-0,0,-0.01f);
        shoulderFlexionL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderFlexionR.SetActive(true);
        shoulderFlexionR.transform.localPosition = new Vector3(-0.105f, 0.262f, -0.1f);
        shoulderFlexionR.transform.GetChild(0).localPosition = new Vector3(0,0,-0.01f);
        shoulderFlexionR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderRotationL.SetActive(true);
        shoulderRotationL.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderRotationL.transform.GetChild(0).localPosition = new Vector3(-0.143f,0.358f,-0.01f);
        shoulderRotationL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderRotationR.SetActive(true);
        shoulderRotationR.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderRotationR.transform.GetChild(0).localPosition = new Vector3(0.143f,0.358f,-0.01f);
        shoulderRotationR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        elbowFlexionL.SetActive(true);
        elbowFlexionL.transform.localPosition = new Vector3(0,0,-0.01f);
        elbowFlexionL.transform.GetChild(0).localPosition = new Vector3(-0.139f,0.121f,-0.01f);
        elbowFlexionL.transform.GetChild(0).localScale = new Vector3(0.33f, 0.33f ,1);

        elbowFlexionR.SetActive(true);
        elbowFlexionR.transform.localPosition = new Vector3(0,0,-0.01f);
        elbowFlexionR.transform.GetChild(0).localPosition = new Vector3(0.139f,0.121f,-0.01f);
        elbowFlexionR.transform.GetChild(0).localScale = new Vector3(0.33f, 0.33f ,1);

        handflexionL.SetActive(true);
        handflexionL.transform.localPosition = new Vector3(0,0,-0.01f);
        handflexionL.transform.GetChild(0).localPosition = new Vector3(-0.19f,0,-0.01f);
        handflexionL.transform.GetChild(0).localScale = new Vector3(0.25f, 0.25f ,1);

        handflexionR.SetActive(true);
        handflexionR.transform.localPosition = new Vector3(0,0,-0.01f);
        handflexionR.transform.GetChild(0).localPosition = new Vector3(0.19f,0,-0.01f);
        handflexionR.transform.GetChild(0).localScale = new Vector3(0.25f, 0.25f ,1);

        handRadicalL.SetActive(true);
        handRadicalL.transform.localPosition = new Vector3(0,0,-0.01f);
        handRadicalL.transform.GetChild(0).localPosition = new Vector3(-0.3f,0,-0.01f);
        handRadicalL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        handRadicalR.SetActive(true);
        handRadicalR.transform.localPosition = new Vector3(0,0,-0.01f);
        handRadicalR.transform.GetChild(0).localPosition = new Vector3(0.3f,0,-0.01f);
        handRadicalR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        kneeStand.SetActive(true);
        kneeStand.transform.localPosition = new Vector3(0,0,-0.01f);
        kneeStand.transform.GetChild(0).localPosition = new Vector3(0,-0.222f,-0.01f);
        kneeStand.transform.GetChild(0).localScale = new Vector3(1f, 0.5f ,1);
        plane.SetActive(false);
        text.SetActive(false);
    }
    public void mode2()
    {
        setMode(2);
        mrtkCanvas.GetComponent<MeshRenderer>().enabled = true;
        headTilt.SetActive(true);
        headTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        headTilt.transform.GetChild(0).localPosition = new Vector3(0.0f,0.4f,-0.01f);
        headTilt.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        headSideTilt.SetActive(false);
        headSideTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        headSideTilt.transform.GetChild(0).localPosition = new Vector3(-0.03f,0.4f,-0.01f);
        headSideTilt.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        neckTorsion.SetActive(true);
    	neckTorsion.transform.localPosition = new Vector3(0,0,-0.01f);
        neckTorsion.transform.GetChild(0).localPosition = new Vector3(-0.0f,0.336f,-0.01f);
        neckTorsion.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        neckTilt.SetActive(false);
        neckTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        neckTilt.transform.GetChild(0).localPosition = new Vector3(0.025f,0.336f,-0.01f);
        neckTilt.transform.GetChild(0).localScale = new Vector3(0.3f, 0.3f ,1);

        bodyTilt.SetActive(true);
        bodyTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        bodyTilt.transform.GetChild(0).localPosition = new Vector3(0,0.12f,-0.01f);
        bodyTilt.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        bodySideTilt.SetActive(false);
        bodySideTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        bodySideTilt.transform.GetChild(0).localPosition = new Vector3(0.075f,0.12f,-0.01f);
        bodySideTilt.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);
        
        backTilt.SetActive(true);
        backTilt.transform.localPosition = new Vector3(0,0,-0.01f);
        backTilt.transform.GetChild(0).localPosition = new Vector3(0f,0.23f,-0.01f);
        backTilt.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);

        backTorsion.SetActive(false);
        backTorsion.transform.localPosition = new Vector3(0,0,-0.01f);
        backTorsion.transform.GetChild(0).localPosition = new Vector3(0,0.26f,-0.01f);
        backTorsion.transform.GetChild(0).localScale = new Vector3(0.4f, 0.4f ,1);

        shoulderAdductionL.SetActive(false);
        shoulderAdductionL.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderAdductionL.transform.GetChild(0).localPosition = new Vector3(0.1f,0.26f,-0.01f);
        shoulderAdductionL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);           
        
        shoulderAdductionR.SetActive(false);
        shoulderAdductionR.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderAdductionR.transform.GetChild(0).localPosition = new Vector3(-0.1f,0.26f,-0.01f);
        shoulderAdductionR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderFlexionL.SetActive(true);
        shoulderFlexionL.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderFlexionL.transform.GetChild(0).localPosition = new Vector3(0.1f,0.26f,-0.01f);
        shoulderFlexionL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);  

        shoulderFlexionR.SetActive(true);
        shoulderFlexionR.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderFlexionR.transform.GetChild(0).localPosition = new Vector3(-0.1f,0.26f,-0.01f);
        shoulderFlexionR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderRotationL.SetActive(false);
        shoulderRotationL.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderRotationL.transform.GetChild(0).localPosition = new Vector3(-0.143f,0.358f,-0.01f);
        shoulderRotationL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        shoulderRotationR.SetActive(false);
        shoulderRotationR.transform.localPosition = new Vector3(0,0,-0.01f);
        shoulderRotationR.transform.GetChild(0).localPosition = new Vector3(0.143f,0.358f,-0.01f);
        shoulderRotationR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        elbowFlexionL.SetActive(true);
        elbowFlexionL.transform.localPosition = new Vector3(0,0,-0.01f);
        elbowFlexionL.transform.GetChild(0).localPosition = new Vector3(-0.139f,0.121f,-0.01f);
        elbowFlexionL.transform.GetChild(0).localScale = new Vector3(0.33f, 0.33f ,1);

        elbowFlexionR.SetActive(true);
        elbowFlexionR.transform.localPosition = new Vector3(0,0,-0.01f);
        elbowFlexionR.transform.GetChild(0).localPosition = new Vector3(0.139f,0.121f,-0.01f);
        elbowFlexionR.transform.GetChild(0).localScale = new Vector3(0.33f, 0.33f ,1);

        handflexionL.SetActive(true);
        handflexionL.transform.localPosition = new Vector3(0,0,-0.01f);
        handflexionL.transform.GetChild(0).localPosition = new Vector3(-0.19f,0,-0.01f);
        handflexionL.transform.GetChild(0).localScale = new Vector3(0.25f, 0.25f ,1);

        handflexionR.SetActive(true);
        handflexionR.transform.localPosition = new Vector3(0,0,-0.01f);
        handflexionR.transform.GetChild(0).localPosition = new Vector3(0.19f,0,-0.01f);
        handflexionR.transform.GetChild(0).localScale = new Vector3(0.25f, 0.25f ,1);

        handRadicalL.SetActive(false);
        handRadicalL.transform.localPosition = new Vector3(0,0,-0.01f);
        handRadicalL.transform.GetChild(0).localPosition = new Vector3(-0.3f,0,-0.01f);
        handRadicalL.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        handRadicalR.SetActive(false);
        handRadicalR.transform.localPosition = new Vector3(0,0,-0.01f);
        handRadicalR.transform.GetChild(0).localPosition = new Vector3(0.3f,0,-0.01f);
        handRadicalR.transform.GetChild(0).localScale = new Vector3(0.5f, 0.5f ,1);

        kneeStand.SetActive(true);
        kneeStand.transform.localPosition = new Vector3(0,0,-0.01f);
        kneeStand.transform.GetChild(0).localPosition = new Vector3(0,-0.222f,-0.01f);
        kneeStand.transform.GetChild(0).localScale = new Vector3(1f, 0.5f ,1);
        plane.SetActive(false);
        text.SetActive(false);
    }
        public void mode3()
    {
    setMode(3);
    mrtkCanvas.GetComponent<MeshRenderer>().enabled = false;
    headTilt.SetActive(false);
    headSideTilt.SetActive(false);
    neckTorsion.SetActive(false);
    neckTilt.SetActive(false);
    bodyTilt.SetActive(false);
    bodySideTilt.SetActive(false);
    backTilt.SetActive(false);
    backTorsion.SetActive(false);
    shoulderAdductionL.SetActive(false);
    shoulderAdductionR.SetActive(false);
    shoulderFlexionL.SetActive(false);
    shoulderFlexionR.SetActive(false);
    shoulderRotationL.SetActive(false);
    shoulderRotationR.SetActive(false);
    elbowFlexionL.SetActive(false);
    elbowFlexionR.SetActive(false);
    handflexionL.SetActive(false);
    handflexionR.SetActive(false);
    handRadicalL.SetActive(false);
    handRadicalR.SetActive(false);
    kneeStand.SetActive(false);
    plane.SetActive(true);
    text.SetActive(true);
    }

    public int getMode()
    {
        return mode;
    }
    public void setMode(int modesetter)
    {
        mode = modesetter;
        colorManager.mode = modesetter;
    }
}
