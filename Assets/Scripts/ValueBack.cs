using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueBack : MonoBehaviour
{

    public GameObject Hip;
    public GameObject Low;
    public GameObject Mid;
    public GameObject High;

    public Vector3 HipSpineAngle;
    public float torsoTilt;
    public float torsoSideTilt;
    public float backTors;
    public float backCurve;

    // Update is called once per frame
    void Update()
    {
        HipSpineAngle = Hip.transform.position - High.transform.position;
        HipSpineAngle.x = 0;
        torsoTilt = Vector3.Angle(HipSpineAngle, new Vector3(0,1,0));

        HipSpineAngle = Hip.transform.position - High.transform.position;
        HipSpineAngle.z = 0;
        torsoSideTilt = Vector3.Angle(HipSpineAngle, new Vector3(0,1,0));

        backCurve = Vector3.Angle(Low.transform.position-Mid.transform.position,Mid.transform.position-High.transform.position);

        backTors = Mid.transform.localRotation.y;
    }
}
