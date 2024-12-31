using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Hàm gọi khi nhấn nút "Play"
    public void PlayGame()
    {
        Debug.Log("Loading Game...");
        SceneManager.LoadScene("SampleScene");
    }

    // Hàm gọi khi nhấn nút "Quit"
    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit(); // Thoát game
    }
}
