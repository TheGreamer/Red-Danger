using UnityEngine;

public class StartingController : MonoBehaviour
{
    private void Start()
    {
        Application.targetFrameRate = 300;
        Time.timeScale = 1f;
        GameObject.Find("Music Management").GetComponent<AudioSource>().volume = 1.0f;
    }
}