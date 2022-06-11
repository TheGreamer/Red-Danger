using UnityEngine;
using UnityEngine.SceneManagement;

public class CompletionParticlesManagement : MonoBehaviour
{
    private bool state;
    public GameObject fireworks;
    public GameObject confettis;

    private void Start()
    {
        state = true;
    }

    private void Update()
    {
        if (ShapeNumbers.levelCompleted && state)
        {
            if (SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 2)
            {
                Instantiate(fireworks, new Vector3(0.0f, -10.0f, 20.0f), Quaternion.Euler(-90.0f, 0.0f, 90.0f));
            }
            else
            {
                Instantiate(confettis, Vector3.zero, Quaternion.Euler(0.0f, 0.0f, 0.0f));
            }

            state = false;
        }
    }
}