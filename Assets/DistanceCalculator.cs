using UnityEngine;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Input;

public class DistanceCalculator : MonoBehaviour
{
    // Singleton instance
    private static DistanceCalculator instance;

    // Public property to access the singleton instance
    public static DistanceCalculator Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DistanceCalculator>();

                if (instance == null)
                {
                    GameObject singleton = new GameObject("DistanceCalculatorSingleton");
                    instance = singleton.AddComponent<DistanceCalculator>();
                }
            }

            return instance;
        }
    }

    [Tooltip("Reference to the MRTK canvas")]
    public GameObject canvasToMeasure;

    private void Awake()
    {
        // Ensure there is only one instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Update()
    {
        // Check if the canvas is set
        if (canvasToMeasure == null)
        {
            Debug.LogError("Canvas reference not set. Please assign the MRTK canvas in the inspector.");
            return;
        }

        // Calculate the distance
        float distance = CalculateDistanceToCanvas(canvasToMeasure);

        // Use the distance as needed
        Debug.Log("Distance to Canvas: " + distance);
    }

    public float CalculateDistanceToCanvas(GameObject canvas)
    {
        // Get the user's gaze position
        Vector3 gazePosition = CoreServices.InputSystem.GazeProvider.GazePointer.Position;

        // Find the closest point on the canvas to the gaze position
        Vector3 closestPoint = canvas.GetComponent<Collider>().ClosestPoint(gazePosition);

        // Calculate the distance between the gaze position and the closest point on the canvas
        float distance = Vector3.Distance(gazePosition, closestPoint);

        return distance;
    }
}