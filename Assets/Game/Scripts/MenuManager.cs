using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // based on lesson code
    public GameObject tutorialMenu;
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // we have only 4 scenes, so no need to complicate this line
    }

    public void ToggleTutorial()
    {
        if (tutorialMenu != null)
        {
            tutorialMenu.SetActive(!tutorialMenu.activeSelf);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
