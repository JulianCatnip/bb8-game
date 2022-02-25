using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour, IReceiveMessage
{
    private Text uiText;

    // Start is called before the first frame update
    void Start()
    {
        uiText = GetComponent<Text>();
        uiText.text = "";
    }

    public void OnRecieve(string showText)
    {
        uiText.text = showText;
    }
}
