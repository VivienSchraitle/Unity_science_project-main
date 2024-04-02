using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueNeckHead : MonoBehaviour
{   
    public GameObject TopHead;
    public GameObject Head; // POsition Joint ForeArm (ELbow)
    public GameObject Neck	; // Position Joint Shoulder 
    public GameObject Torso;
    Vector3 rotation;

    public float NeckFlExAngle; // Shoulder Flexion / Exztension 
    public float headSideTilt;
    public float neckBend;
    public float neckTors;
    public Vector3 VectTstoNk;
    public Vector3 VectNktoHd; // Vector Neck to Head,
    public Vector3 VectNktoUnitA; // Vector Shoulder to Unit vector A, Plane for Flexion/Extension (Yellow-Blue)
    private Vector3 UnitVectorA; 
    

    // Update is called once per frame
    void Update()
    {
                VectNktoHd = Head.transform.position - Neck.transform.position;    // Vector Head to Neck
                UnitVectorA = Head.transform.forward; // Unit vector in axis Z blue
                NeckFlExAngle = Vector3.Angle(UnitVectorA,VectNktoHd)-70; // Angle calculation

                rotation = Head.transform.localRotation.eulerAngles;
                neckTors = rotation.y;
            
                VectTstoNk = Torso.transform.position - Neck.transform.position; 
                neckBend = Vector3.Angle(VectTstoNk,VectNktoHd);

                VectNktoHd[2]=0;
                UnitVectorA[2]=0;
                headSideTilt = Vector3.Angle(UnitVectorA,VectNktoHd);




    }
}
