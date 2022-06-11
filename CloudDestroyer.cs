using UnityEngine;

public class CloudDestroyer : MonoBehaviour
{
    private float cloudLifeTime = 80.0f;

    private void Update()
    {
        cloudLifeTime -= Time.deltaTime;

        if (cloudLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}