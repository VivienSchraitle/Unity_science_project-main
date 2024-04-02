using UnityEngine;
using Microsoft.MixedReality.Toolkit.Input;
using System.IO;
using Microsoft.MixedReality.Toolkit;

public class GazeTracking : MonoBehaviour
{
    public GameObject targetObject; // Assign the target GameObject in the Inspector

    private IMixedRealityGazeProvider gazeProvider;
    private int gazeCounter;
    private float[] gazeDurations;
    private float totalGazeDuration;
    private float overallRuntimeDuration;
    private float averageDistance;
    private float smallestDistance;
    public float distanceToTarget;
    private bool isGazingAtTarget;

    private void Start()
    {
        gazeProvider = CoreServices.InputSystem?.GazeProvider;

        if (gazeProvider == null)
        {
            Debug.LogError("Gaze Provider not found!");
        }

        gazeDurations = new float[1000]; // Assuming a maximum of 1000 gaze durations to track
        gazeCounter = 0;
        totalGazeDuration = 0f;
        overallRuntimeDuration = 0f;
        averageDistance = 0f;
        smallestDistance = float.MaxValue;
    }

    private void Update()
    {
#if UNITY_EDITOR
        // Simulate gaze pointer in the Unity Editor
        Vector3 gazeOrigin = Camera.main.transform.position;
        Vector3 gazeDirection = Camera.main.transform.forward;
#else
        // Use the gaze provider to get the gaze origin and direction
        Vector3 gazeOrigin = gazeProvider.GazeOrigin;
        Vector3 gazeDirection = gazeProvider.GazeDirection;
#endif

        // Check if the target object is being gazed at
        isGazingAtTarget = IsGazingAtTarget(gazeOrigin, gazeDirection);

        // Update gaze duration
        if (isGazingAtTarget)
        {
            //Debug.Log("gazing at object");
            if (!isGazingAtTarget)
            {
                gazeCounter++;
                gazeDurations[gazeCounter] = 0f; // Start new gaze duration
            }
            gazeDurations[gazeCounter] += Time.deltaTime;
            totalGazeDuration += Time.deltaTime;
        }
        //else{Debug.Log("not gazing at object");}

        // Update overall runtime duration
        overallRuntimeDuration += Time.deltaTime;

        // Update gaze distance
        smallestDistance = Mathf.Min(smallestDistance, distanceToTarget);

        // Save gaze data to CSV file
        if (Application.isEditor)
        {
            SaveGazeDataToCSV();
        }
    }

private bool IsGazingAtTarget(Vector3 gazeOrigin, Vector3 gazeDirection)
{
    RaycastHit hit;
    if (Physics.Raycast(gazeOrigin, gazeDirection, out hit))
    {
        if (hit.collider.gameObject == targetObject)
        {
            distanceToTarget = 0f; // Distance is 0 if ray hits the collider
           // Debug.Log("Distance to target: " + distanceToTarget);
            return true;
        }
    }
    
    // If the ray doesn't hit the target object's collider, calculate the shortest distance
    if (targetObject != null)
    {
        Collider collider = targetObject.GetComponent<Collider>();
        if (collider != null)
        {
            // Calculate the point on the ray closest to the collider
            Vector3 closestPointOnRay = ClosestPointOnRay(gazeOrigin, gazeDirection, collider);

            // Calculate the distance between the closest point on the ray and the collider's surface
            distanceToTarget = Vector3.Distance(closestPointOnRay, collider.ClosestPoint(closestPointOnRay));
           // Debug.Log("Distance to target: " + distanceToTarget);

            return false;
        }
    }

    distanceToTarget = Mathf.Infinity; // Set distance to infinity if no collider attached to the object
    //Debug.Log("Distance to target: " + distanceToTarget);
    return false;
}

private Vector3 ClosestPointOnRay(Vector3 rayOrigin, Vector3 rayDirection, Collider collider)
{
    // Calculate the point on the ray closest to the collider's bounds
    Vector3 closestPointOnRay = rayOrigin + rayDirection * Vector3.Dot(collider.bounds.center - rayOrigin, rayDirection);
    return closestPointOnRay;
}

    private void SaveGazeDataToCSV()
    {
        // Create CSV file path
        string filePath = Application.persistentDataPath + "/gaze_data.csv";

        // Write gaze data to CSV file
        using (StreamWriter writer = new StreamWriter(filePath, true))
        {
            //writer.WriteLine("Gaze Counter,Gaze Duration,Average Distance,Overall Runtime Duration");
            //writer.WriteLine($"{gazeCounter},{totalGazeDuration},{averageDistance},{overallRuntimeDuration}");
        }
    }
}