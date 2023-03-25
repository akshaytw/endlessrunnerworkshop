using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject menuItems;
    [SerializeField] private Image menuImage;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite resumeSprite;

    private bool isPaused;

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Menu()
    {
        isPaused = !isPaused;
        menuItems.SetActive(isPaused);
        menuImage.sprite = isPaused ? resumeSprite : pauseSprite;
        Time.timeScale = isPaused ? 0 : 1;
    }
}