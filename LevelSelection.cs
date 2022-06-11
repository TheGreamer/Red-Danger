using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[ExecuteInEditMode]
public class LevelSelection : TransitionManagement
{
    public Button[] levels;

    [Header("Sprites")]
    public Sprite greenSprite;
    public Sprite blueSprite;
    public Sprite redSprite;

    [Header("Colors")]
    public Color green;
    public Color blue;

    private Image loadingScreen;

    private void Start()
    {
        int saveIndex = PlayerPrefs.GetInt("SaveIndex");
        loadingScreen = GameObject.Find("Loading Screen").GetComponent<Image>();
        loadingScreen.enabled = true;
        StartCoroutine(FadeIn(0.25f, loadingScreen));

        for (int i = 0; i < levels.Length; i++)
        {
            if (i < saveIndex)
            {
                levels[i].interactable = true;
                levels[i].GetComponent<Image>().sprite = greenSprite;
                levels[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
                levels[i].GetComponentInChildren<Text>().color = green;
            }
            else if (i == saveIndex)
            {
                levels[i].interactable = true;
                levels[i].GetComponent<Image>().sprite = blueSprite;
                levels[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
                levels[i].GetComponentInChildren<Text>().color = blue;
            }
            else
            {
                levels[i].interactable = false;
                levels[i].GetComponent<Image>().sprite = redSprite;
                levels[i].GetComponentInChildren<Text>().text = string.Empty;
            }
        }
    }

    public void LevelSelect()
    {
        StartCoroutine(FadeOut(0.25f, loadingScreen, int.Parse(EventSystem.current.currentSelectedGameObject.GetComponentInChildren<Text>().text)));
    }
}