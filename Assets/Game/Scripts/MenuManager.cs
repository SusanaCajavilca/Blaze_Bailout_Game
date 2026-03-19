using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // based on lesson code
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // we have only 4 scenes, so no need to complicate this line
    }

    public void ShowTutorial()
    {
        
    }

    public void QuitGame()
    {
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
