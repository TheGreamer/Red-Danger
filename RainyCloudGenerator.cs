using UnityEngine;

public class RainyCloudGenerator : MonoBehaviour
{
    public GameObject cloud;

    [Header("Repeating Value")]
    public float period;
    private float nextActionTime = 0.0f;
    private float time = 0.0f;

    private void Update()
    {
        if (!Timer.IsDayTime)
        {
            time += Time.deltaTime;

            if (time > nextActionTime)
            {
                Instantiate(cloud);
                nextActionTime += period;
            }
        }
    }
}