using UnityEngine;

public class MusicManagement : MonoBehaviour
{
    private static MusicManagement instance = null;

    public static MusicManagement Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            instance = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}