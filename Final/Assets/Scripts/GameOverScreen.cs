using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private Button retryButton;

    private void Start()
    {
        backButton.onClick.AddListener(OnBackButtonClicked);
        retryButton.onClick.AddListener(OnRetryButtonClicked);
    }

    public void OnBackButtonClicked()
    {
        backButton.interactable = false;
        GameManager.Instance.MainMenu();
    }

    public void OnRetryButtonClicked()
    {
        retryButton.interactable = false;
        GameManager.Instance.retryLevel();
    }
}
