using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameCompleted : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _scoreText;
    [SerializeField]
    private Button menuButton;

    private string score;

    private void Start()
    {
        menuButton.onClick.AddListener(OnButtonBack);
    }

    void OnButtonBack()
    {
        GameManager.Instance.MainMenu();
    }
}
