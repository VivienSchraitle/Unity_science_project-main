using UnityEngine;
using UnityEngine.UI;

public class OpacitySetter : MonoBehaviour
{
    public GazeTracking gazeTracking;
    public GameObject targetObject;
    public float maxDistance = 1.2f; // Maximum distance for full transparency
    public float minDistance = 0f; // Minimum distance for full opacity
    public bool affectChildren = true; // Whether to affect children GameObjects

    private Renderer[] renderers;

    private void Start()
    {
        renderers = targetObject.GetComponentsInChildren<Renderer>();
    }

    private void Update()
    {
        if (gazeTracking != null)
        {
            float distanceToTarget = gazeTracking.distanceToTarget;

            // Clamp the distance within the specified range
            float clampedDistance = Mathf.Clamp(distanceToTarget, minDistance, maxDistance);

            // Calculate opacity based on distance
            float opacity = 1f - (clampedDistance - minDistance) / (maxDistance - minDistance);
            //Debug.Log(opacity);
            if (opacity < 0.5f)
            {
                opacity = 0;
            }
            else
            {
                opacity = Mathf.Min(opacity*1.3f,1);
            }
            // Apply opacity to all renderers
            foreach (Renderer renderer in renderers)
            {
                Material[] materials = renderer.materials;
                foreach (Material material in materials)
                {
                    Color color = material.color;
                    color.a = opacity;
                    material.color = color;
                }
            }
        }
    }
}