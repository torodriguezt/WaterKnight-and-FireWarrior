using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class PassLevel : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private TMP_Text _timeText;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button menuButton;

    private string score;

    private void Start()
    {
        LevelCompleted(GameManager.Instance.getPoints(), GameManager.Instance.getTime());
        menuButton.onClick.AddListener(OnButtonBack);
        continueButton.onClick.AddListener(OnButtonContinue);
    }
    private void LevelCompleted(int points, float time)
    {
        points = points / 12;
        if (points < 0.5)
        {
            score = "C";
        }
        else if (points < 0.92)
        {
            score = "B";
        }
        else
        {
            score = "A";
        }

        _scoreText.text = $"{score}";
        _timeText.text = $"{time}";
    }

    void OnButtonBack()
    {
        GameManager.Instance.MainMenu();
    }
    void OnButtonContinue()
    {
        GameManager.Instance.continueLevel();
    }
}