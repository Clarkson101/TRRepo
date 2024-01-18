using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour
{
    private LevelScore scoreComponent;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text accuracyText;

    void Start()
    {
        scoreComponent = FindObjectOfType<LevelScore>();
    }

    void Update()
    {
        if (scoreComponent != null)
        {
            scoreText.text = "Score: " + scoreComponent.score;
            accuracyText.text = "Accuracy: " + scoreComponent.accuracyPercent + '%';

            scoreComponent.transform.parent = gameObject.transform;
        }

        else
        {
            scoreComponent = FindObjectOfType<LevelScore>();
        }
    }
}
