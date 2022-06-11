using UnityEngine;
using UnityEngine.UI;

public class ScrollbarManagement : MonoBehaviour
{
    public Scrollbar scrollbar;

    private void Start()
    {
        int savedLevel = PlayerPrefs.GetInt("SaveIndex");

        if (savedLevel >= 0 && savedLevel <= 6)
        {
            scrollbar.value = 1.0f;
        }
        else if (savedLevel > 6 && savedLevel <= 12)
        {
            scrollbar.value = 0.93f;
        }
        else if (savedLevel > 12 && savedLevel <= 18)
        {
            scrollbar.value = 0.86f;
        }
        else if (savedLevel > 18 && savedLevel <= 24)
        {
            scrollbar.value = 0.788f;
        }
        else if (savedLevel > 24 && savedLevel <= 30)
        {
            scrollbar.value = 0.715f;
        }
        else if (savedLevel > 30 && savedLevel <= 36)
        {
            scrollbar.value = 0.643f;
        }
        else if (savedLevel > 36 && savedLevel <= 42)
        {
            scrollbar.value = 0.571f;
        }
        else if (savedLevel > 42 && savedLevel <= 48)
        {
            scrollbar.value = 0.5f;
        }
        else if (savedLevel > 48 && savedLevel <= 54)
        {
            scrollbar.value = 0.427f;
        }
        else if (savedLevel > 54 && savedLevel <= 60)
        {
            scrollbar.value = 0.355f;
        }
        else if (savedLevel > 60 && savedLevel <= 66)
        {
            scrollbar.value = 0.283f;
        }
        else if (savedLevel > 66 && savedLevel <= 72)
        {
            scrollbar.value = 0.21f;
        }
        else if (savedLevel > 72 && savedLevel <= 78)
        {
            scrollbar.value = 0.139f;
        }
        else if (savedLevel > 78 && savedLevel <= 84)
        {
            scrollbar.value = 0.066f;
        }
        else
        {
            scrollbar.value = 0.0f;
        }
    }
}