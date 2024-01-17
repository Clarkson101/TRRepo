using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timerDuration = 45f;
    private float timer;
    public Text timerText;

    void Start()
    {
        timer = timerDuration;

        // Start the countdown coroutine
        StartCoroutine(StartCountdown());
    }

    void Update()
    {
        UpdateTimerDisplay();
    }

    private IEnumerator StartCountdown()
    {
        while (timer > 0)
        {
            yield return new WaitForSeconds(1f);
            timer -= 1f;
            UpdateTimerDisplay();
        }

        // Timer reached zero, load the next scene
        LoadNextScene();
    }

    void UpdateTimerDisplay()
    {
        // Update your timer UI (Assuming you have a Text component for displaying the timer)
        timerText.text = "Time: " + Mathf.Floor(timer / 60).ToString("00") + ":" + (timer % 60).ToString("00");
    }

    void LoadNextScene()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("ScoreScreen");
    }
}
