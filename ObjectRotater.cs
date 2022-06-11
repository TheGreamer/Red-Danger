using UnityEngine;

public class ObjectRotater : MonoBehaviour
{
    private float rotation;
    private float rotationDegree = 360.0f;

    [Range(5.0f, 150.0f)] public float rotationSpeed = 30.0f;
    public RotationWay rotationWay;

    private void Update()
    {
        rotation = rotationSpeed * Time.deltaTime;

        if (rotationDegree > rotation)
        {
            rotationDegree -= rotation;
        }
        else
        {
            rotation = rotationDegree;
            rotationDegree = 360.0f;
        }

        switch (rotationWay)
        {
            case RotationWay.Left:
                transform.Rotate(0.0f, 0.0f, rotation);
                break;
            default:
                transform.Rotate(0.0f, 0.0f, -rotation);
                break;
        }
    }
}

public enum RotationWay { Left, Right }