using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem.EnhancedTouch;

public class TouchTest : MonoBehaviour
{
    public Text debugText; // ���������� ���� UI Text ��� �������
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
