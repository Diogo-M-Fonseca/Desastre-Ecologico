using UnityEngine;
using UnityEngine.UI;

public class uiScript : MonoBehaviour
{
    [SerializeField] private GameObject gameUI;
    [SerializeField] private GameObject endUI;
    [SerializeField] private Text[] pointUI;

    public void ShowGameUI()
    {
        gameUI.SetActive(true);
        endUI.SetActive(false);
    }

    public void ShowEndUI()
    {
        gameUI.SetActive(false);
        endUI.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

}
