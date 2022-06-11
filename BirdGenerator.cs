using UnityEngine;

public class BirdGenerator : MonoBehaviour
{
    [Header("Birds")]
    public GameObject dayTimeBird;
    public GameObject nightBird;

    [Header("Random Generation Values")]
    [Range(1, 3)] public int minValue;
    [Range(4, 8)] public int maxValue;
    private int randomNumber;

    [Header("Repeating Value")]
    public float period;
    private float nextActionTime = 0.0f;
    private float time = 0.0f;

    private void Update()
    {
        time += Time.deltaTime;

        if (time > nextActionTime)
        {
            randomNumber = Random.Range(minValue, maxValue);

            if (Timer.IsDayTime)
            {
                for (int i = 1; i <= randomNumber; i++)
                {
                    Instantiate(dayTimeBird);
                }
            }
            else
            {
                for (int i = 1; i <= randomNumber; i++)
                {
                    Instantiate(nightBird);
                }
            }

            nextActionTime += period;
        }
    }
}