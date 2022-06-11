using UnityEngine;

public class CloudPlacer : MonoBehaviour
{
    private GameObject parentObject;
    private float cloudSpeed;
    public bool isFirst;
    private SpriteRenderer cloudSprite;

    private void Start()
    {
        if (!isFirst)
        {
            parentObject = GameObject.Find("Cloud Generator");

            if (transform.position != parentObject.transform.position)
            {
                transform.position = parentObject.transform.position;
            }
        }

        transform.localScale += new Vector3(Random.Range(1.0f, 1.5f), Random.Range(1.0f, 2.0f));
        transform.position = new Vector3(transform.position.x, Random.Range(transform.position.y - 1.0f, transform.position.y + 1.0f));
        cloudSpeed = Random.Range(0.3f, 0.5f);
        cloudSprite = GetComponent<SpriteRenderer>();
        cloudSprite.color = new Color(cloudSprite.color.r, cloudSprite.color.g, cloudSprite.color.b, Random.Range(0.5f, 1.0f));
        cloudSprite.sortingOrder = cloudSprite.color.a <= 0.75f ? 2 : 4;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * cloudSpeed * Time.deltaTime);
    }
}