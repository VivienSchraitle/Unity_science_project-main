using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValuesLeg : MonoBehaviour
{
    public GameObject Hip;
    public GameObject KneeR;
    public GameObject FootR;
    public GameObject KneeL;
    public GameObject FootL;

    public float kneeLAngle;
    public float kneeRAngle;

    // Update is called once per frame
    void Start()
    {
        kneeLAngle = Vector3.Angle(Hip.transform.position-KneeL.transform.position,FootL.transform.position-KneeL.transform.position);
        kneeRAngle = Vector3.Angle(Hip.transform.position-KneeR.transform.position,FootR.transform.position-KneeR.transform.position);

    }
    void Update()
    {
        kneeLAngle = Vector3.Angle(Hip.transform.position-KneeL.transform.position,FootL.transform.position-KneeL.transform.position);
        kneeRAngle = Vector3.Angle(Hip.transform.position-KneeR.transform.position,FootR.transform.position-KneeR.transform.position);
    }
}
