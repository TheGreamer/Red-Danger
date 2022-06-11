using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ScrollViewColorManagement : MonoBehaviour
{
    [Header("Colors")]
    public Color dayTimeColor;
    public Color nightColor;

    private void Start() => GetComponent<Image>().color = Timer.IsDayTime ? dayTimeColor : nightColor;
}