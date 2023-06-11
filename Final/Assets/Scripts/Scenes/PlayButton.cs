using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _instructionButton;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
        _instructionButton.onClick.AddListener(OnInstructionButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        _startButton.interactable = false;
        GameManager.Instance.StartGame();
    }

    public void OnExitButtonClicked()
    {
        _exitButton.interactable = false;
        Application.Quit();
    }

    public void OnInstructionButtonClicked()
    {
        _instructionButton.interactable = false;
        GameManager.Instance.Instruction();
    }
}
