using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.XR.ARCore;

public class RestartScene : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    void Start()
    {
        restartButton.onClick.AddListener(RestartCurrentScene);
    }

    private void RestartCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
