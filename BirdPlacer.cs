using UnityEngine;

public class BirdPlacer : MonoBehaviour
{
    private GameObject parentObject;
    private float birdSpeed;

    private void Start()
    {
        parentObject = GameObject.Find("Bird Generator");
        if (transform.position != parentObject.transform.position)
        {
            transform.position = parentObject.transform.position;
        }
        transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y - 1.5f, transform.position.y + 3.0f));
        birdSpeed = Random.Range(2.0f, 4.0f);
    }

    private void Update()
    {
        transform.Translate(Vector2.right * birdSpeed * Time.deltaTime);
    }
}