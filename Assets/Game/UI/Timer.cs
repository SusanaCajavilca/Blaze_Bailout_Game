using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 45f;
    public TextMeshProUGUI timerText;

    private bool timerRunning = true;

    void Update()
    {
        if (!timerRunning) return;

        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
        else
        {
            timeRemaining = 0;
            timerRunning = false;

            // time over -> player loses
            SceneManager.LoadScene("LoseScene");
        }
    }

    void UpdateTimerUI()
    {
        timerText.text =  Mathf.Ceil(timeRemaining).ToString();
    }

    public void AddTime(float extraTime)
    {
        timeRemaining += extraTime;
    }
}
