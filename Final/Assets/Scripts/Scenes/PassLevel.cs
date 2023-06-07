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
    private TMP_Text _levelText;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button menuButton;

    private void Start()
    {
        _scoreText = GetComponent<TMP_Text>();
        _levelText = GetComponent<TMP_Text>();
        GameEvents.LevelCompletedEvent += LevelCompleted;
        menuButton.onClick.AddListener(OnButtonBack);
        continueButton.onClick.AddListener(OnButtonContinue);
    }

    private void OnDestroy()
    {
        GameEvents.LevelCompletedEvent -= LevelCompleted;
    }
    private void LevelCompleted(int score, int level)
    {
        Debug.Log("AHHH");
        _scoreText.text = $"Score: {score}";
        _levelText.text = $"Level: {level}";
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