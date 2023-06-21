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
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private Button muteButton;
    [SerializeField]
    private Sprite mutedSprite;
    [SerializeField]
    private Sprite unmutedSprite;

    private bool isMuted = false;
    private Image buttonImage;
    private void Start()
    {
        buttonImage = muteButton.GetComponent<Image>();
        muteButton.onClick.AddListener(ToggleMute);
        UpdateButtonImage();
        _backButton.onClick.AddListener(OnButtonBack);
    }
    void OnButtonBack()
    {
        GameManager.Instance.GameOver();
    }

    void ToggleMute()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        UpdateButtonImage();
    }

    void UpdateButtonImage()
    {
        if (isMuted)
        {
            buttonImage.sprite = mutedSprite;
        }
        else
        {
            buttonImage.sprite = unmutedSprite;
        }
    }
}


