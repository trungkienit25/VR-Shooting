using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class SceneTransition : MonoBehaviour
{
    // Thời gian đếm
    public float delayTime = 5f;

    // Hàm bắt đầu, gọi khi scene được load
    void Start()
    {
        // Gọi coroutine để đếm 5 giây rồi chuyển cảnh
        StartCoroutine(WaitAndGoToMainMenu());
    }

    // Coroutine để đợi 5 giây
    private IEnumerator WaitAndGoToMainMenu()
    {
        // Đợi 5 giây
        yield return new WaitForSeconds(delayTime);

        // Quay về scene "MainMenu"
        SceneManager.LoadScene("MainMenu");
    }
}
