using System.Collections.Generic;
using UnityEngine;

public class CloudGenerator : MonoBehaviour
{
    public List<GameObject> clouds;
    private GameObject cloud;
    private int randomCloud;

    [Header("Repeating Value")]
    public float period;
    private float nextActionTime = 0.0f;
    private float time = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > nextActionTime)
        {
            randomCloud = Random.Range(1, clouds.Count);
            cloud = clouds[randomCloud];
            Instantiate(cloud);
            nextActionTime += period;
        }
    }
}