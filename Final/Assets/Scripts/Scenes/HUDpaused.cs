using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class HUDpaused : MonoBehaviour
{
    [SerializeField]
    private Button _backButton;
    private void Start()
    {
        _backButton.onClick.AddListener(OnButtonBack);
    }
    void OnButtonBack()
    {
        GameManager.Instance.GameOver();
    }
}