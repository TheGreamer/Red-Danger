using UnityEngine;

[ExecuteInEditMode]
public class BackgroundManagement : MonoBehaviour
{
    public Sprite dayTimeSprite;
    public Sprite nightTimeSprite;

    private void Start() => GetComponent<SpriteRenderer>().sprite = Timer.IsDayTime ? dayTimeSprite : nightTimeSprite;
}