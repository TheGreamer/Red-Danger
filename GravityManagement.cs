using UnityEngine;

public class GravityManagement : MonoBehaviour
{
    private string objectTag;
    private new ConstantForce2D constantForce;
    private float zeroForce = 0.0f;
    private float force = 6.81f;

    private void Start()
    {
        objectTag = gameObject.tag;
        constantForce = gameObject.GetComponent<ConstantForce2D>();
    }

    private void Update()
    {
        if (objectTag.Contains("Left"))
        {
            constantForce.force = new Vector2(-force, zeroForce);
        }
        else if (objectTag.Contains("Right"))
        {
            constantForce.force = new Vector2(force, zeroForce);
        }
        else if (objectTag.Contains("Up"))
        {
            constantForce.force = new Vector2(zeroForce, force);
        }
        else
        {
            constantForce.force = new Vector2(zeroForce, -force);
        }
    }
}