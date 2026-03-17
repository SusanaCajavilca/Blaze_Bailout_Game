using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    [Header("Counters")]
    public int winRescuedTarget = 5;
    public int totalSurvivors = 6;
    public int rescuedCount = 0;
    public int lostCount = 0;
    public int maxLostAllowed = 2; // Game over if lostCount >= 2

    [Header("UI Elements")]
    public TextMeshProUGUI rescuedText; // top-right counter

    void Start()
    {
        UpdateRescuedUI();
    }

    // Call this when a survivor reaches SafeZone
    public void IncrementRescued()
    {
        rescuedCount++;
        UpdateRescuedUI();
        CheckGameEnd();
    }

    // Call this when a survivor falls into FireZone
    public void IncrementLost()
    {
        lostCount++;

        if (lostCount > maxLostAllowed)
        {
            // Go to LoseScene
            SceneManager.LoadScene("LoseScene");
        }

        CheckGameEnd();
    }

    void UpdateRescuedUI()
    {
        if (rescuedText != null)
        {
            rescuedText.text = "Rescued: " + rescuedCount + " / " + winRescuedTarget;
        }
    }

    void CheckGameEnd()
    {
        if (rescuedCount >= winRescuedTarget)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}