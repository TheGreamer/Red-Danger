using UnityEngine;

public class RainyCloudPlacer : MonoBehaviour
{
    public float rainyCloudSpeed;

    private void Start()
    {
        GameObject parentObject = GameObject.Find("Rainy Cloud Generator");

        if (transform.position != parentObject.transform.position)
        {
            transform.position = parentObject.transform.position;
        }

        transform.position = new Vector3(transform.position.x, transform.position.y, 1.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * rainyCloudSpeed * Time.deltaTime);
    }
}