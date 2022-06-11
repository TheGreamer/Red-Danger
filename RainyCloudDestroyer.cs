using UnityEngine;

public class RainyCloudDestroyer : MonoBehaviour
{
    private float rainyCloudLifeTime = 150.0f;

    private void Update()
    {
        rainyCloudLifeTime -= Time.deltaTime;

        if (rainyCloudLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}