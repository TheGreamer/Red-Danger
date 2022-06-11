using UnityEditor;
using UnityEngine;

public class ClosingManagement : MonoBehaviour
{
    private void OnApplicationQuit()
    {
        string[] keys = { "Paused", "SoundsPaused" };

        foreach (string key in keys)
        {
            PlayerPrefs.DeleteKey(key);
        }

        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
    }
}