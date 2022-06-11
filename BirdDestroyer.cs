using UnityEngine;

public class BirdDestroyer : MonoBehaviour
{
    private float birdLifeTime = 20.0f;

    private void Update()
    {
        birdLifeTime -= Time.deltaTime;

        if (birdLifeTime <= 0.0f)
        {
            Destroy(gameObject);
        }
    }
}