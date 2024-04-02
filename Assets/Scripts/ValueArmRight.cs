using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueArmRight : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 VectAElbow; // Vector between ForeArm and Shoulder (Arm for unity)
    private Vector3 VectBElbow; // Vector between ForeArm and Wrist (Hand for Unity)
    private Vector3 VectShtoEL; // Vector Shoulder to Elbow 
    private Vector3 UnitVectorA; // Vector Shoulder to Unit  (1,x,z), Plane for abduction/adduction 
    private Vector3 UnitVectorB; // Vector Shoulder to Unit (x,y,1) , Plane for Flexion/Extension
    private Vector3 HandFlexationHelper;


    public GameObject ForeArm; // POsition Joint ForeArm (ELbow)
    public GameObject Arm	; // Position Joint Shoulder 
    public GameObject Hand; // Position Joint Wrist
    public GameObject Shoulder; // Position Joint Clavicula
    public GameObject Finger;

    public float ELbowAngle; // Elbow Flexion/ Extension
    public float ShAdAbAngle; // Shoulder Adduction/ Abduction
    public float ShFlExAngle; // Shoulder Flexion / Exztension 
    public float lowArmPronateR;
    public float upArmRotateR;
    public float handFlexR;
    public float handRadDuctR;
    
            // Update is called once per frame
    void Update()
    {
        //Calculate the Elbow Angle  Flexion/Extension 
        VectAElbow = Arm.transform.position - ForeArm.transform.position;    // Vector Shoulder to Elbow
        VectBElbow = Hand.transform.position - ForeArm.transform.position;  // Vector Elbow to Wrist

        ELbowAngle = Vector3.Angle(VectAElbow, VectBElbow); // Angle calculation

        //Calculate the Adduction /abduction Angle of the shoulder
        //adduction and abduction angle ,axis +x (red) ref. Unity vectors
        VectShtoEL = Arm.transform.position - ForeArm.transform.position; // Vector from Arm (shoulder point) to Forearm (elbow point)
        UnitVectorA = ForeArm.transform.right; //+x (red) ref. Unity vectors
        
        ShAdAbAngle = Vector3.Angle(VectShtoEL, UnitVectorA); 
        
        //Flexion and Extension angle ,axis +z (blue) regun Unity vectors
       //UnitVectorB = new Vector3(Arm.transform.position.x,Arm.transform.position.y, 1);
       //VectShtoUnitB = Arm.transform.position - UnitVectorB;
       UnitVectorB = ForeArm.transform.forward;       //axis +z (blue) ref. Unity vectors
       ShFlExAngle = Vector3.Angle(VectShtoEL, UnitVectorB);

       lowArmPronateR = Hand.transform.localRotation.x;

       upArmRotateR = ForeArm.transform.localRotation.y;


       HandFlexationHelper = Finger.transform.position-Hand.transform.position;
       HandFlexationHelper.x = 0;
       handFlexR = Vector3.Angle(HandFlexationHelper, Hand.transform.localPosition);

       HandFlexationHelper = Finger.transform.position-Hand.transform.position;
       HandFlexationHelper.y = 0;
       handRadDuctR = Vector3.Angle(HandFlexationHelper, Hand.transform.localPosition);
    }
}
