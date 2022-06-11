using UnityEngine;
using UnityEngine.UI;

public class SoundMenuColorManagement : MonoBehaviour
{
    [Header("Colors")]
    public Color brightColor;
    public Color darkColor;

    private void Update() => GetComponent<Image>().color = !SoundToggle.isToggled && !MusicToggle.isToggled ? darkColor : brightColor;
}