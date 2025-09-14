using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public static EndScreen Instance { get; private set; }

    [SerializeField] private Canvas canvas;


    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        canvas.enabled = false;
    }

    public void GameEnded()
    {

        canvas.enabled = true;

        Time.timeScale = 0f;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
