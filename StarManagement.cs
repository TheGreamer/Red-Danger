using UnityEngine;

public class StarManagement : MonoBehaviour
{
    private void Start()
    {
        if (Timer.IsDayTime)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}