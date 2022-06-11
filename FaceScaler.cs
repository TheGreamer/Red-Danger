using UnityEngine;

public class FaceScaler : MonoBehaviour
{
    [Header("Scale Rate")]
    public int minValue;
    public int maxValue;

    private int toggle;
    private Vector3 scaleForce;
    private float x;
    private float y;
    private float z;

    private void Start()
    {
        toggle = 1;
        x = 0.001f;
        y = 0.001f;
        z = 0.0f;
        scaleForce = new Vector3(x, y, z);
    }

    private void FixedUpdate()
    {
        if (toggle >= minValue && toggle <= maxValue)
        {
            toggle++;
            transform.localScale += scaleForce;
        }
        else if (toggle < minValue)
        {
            toggle++;
            transform.localScale -= scaleForce;
        }
        else
        {
            toggle = -maxValue;
        }
    }
}