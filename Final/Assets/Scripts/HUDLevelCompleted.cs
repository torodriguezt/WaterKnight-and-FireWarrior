using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDLevelCompleted : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _levelText;
    [SerializeField]
    private Button continueButton;
    [SerializeField]
    private Button menuButton;


    private CanvasGroup _canvasGroup;

    private void Start()
    {
        GameEvents.LevelCompletedEvent += LevelCompleted;

        _canvasGroup = GetComponent<CanvasGroup>();
        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.blocksRaycasts = false;
            _canvasGroup.interactable = false;
        }
        menuButton.onClick.AddListener(OnButtonBack);
        continueButton.onClick.AddListener(OnButtonContinue);
    }

    private void LevelCompleted(int score, int level)
    {
        SetResults(score, level);
        if (_canvasGroup != null)
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.blocksRaycasts = true;
            _canvasGroup.interactable = true;
        }
    }

    void SetResults(int score, int level)
    {
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