using UnityEngine;
using UnityEngine.UI;

public class QuitGame : MonoBehaviour
{
    public Button quitButton; 

    void Start()
    {
        // Lấy component Button
        quitButton = GetComponent<Button>();

        // Thêm sự kiện OnClick cho button
        quitButton.onClick.AddListener(QuitGameNow);
    }

    public void QuitGameNow()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
                Application.Quit();
        #endif
    }
}