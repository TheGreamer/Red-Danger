using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ImageManagement : MonoBehaviour
{
    public Sprite dayTimeImage;
    public Sprite nightTimeImage;

    private void Start() => GetComponent<Image>().sprite = Timer.IsDayTime ? dayTimeImage : nightTimeImage;
}