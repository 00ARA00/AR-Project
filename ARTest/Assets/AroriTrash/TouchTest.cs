using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchTest : MonoBehaviour
{
    public Text debugText; // Перетащите сюда UI Text для отладки
    public Button button;


    private void Update()
    {
        button.onClick.AddListener(ChangeText);
    }

    public void ChangeText()
    {
        debugText.text = "Button clicked!";
    }
}
