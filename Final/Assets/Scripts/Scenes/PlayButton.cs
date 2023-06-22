using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PlayButton : MonoBehaviour
{

    [SerializeField] private Button _startButton;
    [SerializeField] private Button _instructionButton;
    [SerializeField] private Button _exitButton;
    //[SerializeField] private InputField inputField;
    private static string userName;
    private void Start()
    {
        _startButton.onClick.AddListener(OnStartButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);
        _instructionButton.onClick.AddListener(OnInstructionButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        GameManager.Instance.SetName(userName);
        _startButton.interactable = false;
        GameManager.Instance.StartGame();
    }
    public void SetUserName(string inputText)
    {
        userName = inputText;
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
