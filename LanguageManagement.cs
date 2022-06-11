using UnityEngine;
using UnityEngine.UI;

public class LanguageManagement : MonoBehaviour
{
    [Header("Languages")]
    public string turkish;
    public string spanish;
    public string french;
    public string german;
    public string other;

    [Header("Text")]
    public Text message;

    private void Start()
    {
        switch (Application.systemLanguage)
        {
            case SystemLanguage.Turkish:
                message.text = turkish;
                break;
            case SystemLanguage.Spanish:
                message.text = spanish;
                break;
            case SystemLanguage.French:
                message.text = french;
                break;
            case SystemLanguage.German:
                message.text = german;
                break;
            default:
                message.text = other;
                break;
        }
    }
}