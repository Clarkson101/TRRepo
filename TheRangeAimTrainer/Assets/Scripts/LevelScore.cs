using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScore : MonoBehaviour
{
    public int score;
    public int amountOfShots;
    public float accuracyPercent;

    [SerializeField] private Text scoreText;
    private bool updateScoreText = true;

    private void Start()
    {
        transform.parent = FindObjectOfType<DontDestroy>().transform;

        SceneManager.activeSceneChanged += StopOnSceneChange;
    }

    void Update()
    {
        if (updateScoreText)
            scoreText.text = "Score: " + score;
    }

    public void IncrementShotCount()
    {
        amountOfShots++;
    }

    public void IncrementScore()
    {
        score++;
    }

    public void StopOnSceneChange(Scene current, Scene next)
    {
        updateScoreText = false;
        accuracyPercent = (float)score / (float)amountOfShots * 100;
        accuracyPercent = (int)accuracyPercent;
    }
}
