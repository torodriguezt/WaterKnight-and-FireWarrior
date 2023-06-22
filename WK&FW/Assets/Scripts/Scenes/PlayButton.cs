using UnityEngine;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button instructionButton;
    [SerializeField] private Button exitButton;
     
    private static string userName;
    private void Start()
    {
        startButton.onClick.AddListener(OnStartButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
        instructionButton.onClick.AddListener(OnInstructionButtonClicked);
    }

    public void OnStartButtonClicked()
    {
        GameManager.Instance.SetName(userName);
        startButton.interactable = false;
        GameManager.Instance.StartGame();
    }
    public void SetUserName(string inputText)
    {
        userName = inputText;
    }
    public void OnExitButtonClicked()
    {
        exitButton.interactable = false;
        Application.Quit();
    }

    public void OnInstructionButtonClicked()
    {
        instructionButton.interactable = false;
        GameManager.Instance.Instruction();
    }
    
}
