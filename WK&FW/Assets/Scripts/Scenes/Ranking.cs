using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;

public class Ranking : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private TMP_Text[] scores;
    [SerializeField] private TMP_Text[] names;

    private void Start()
    {
        menuButton.onClick.AddListener(OnMenuButtonClicked);
        Debug.Log(GameManager.Instance.GetFinalPoints());
        GameManager.Instance.LoadRank(GameManager.Instance.GetFinalPoints(), GameManager.Instance.GetUserName());
        Rank rank = GameManager.Instance.GetRank();
        rank.users = rank.users.OrderByDescending(u => u.score).Take(5).ToList();
        //Rank rank = GameManager.Instance.LoadRank(GameManager.Instance.GetFinalPoints(), "Carolina");
        Posicion(rank.users);
    }

    public void OnMenuButtonClicked()
    {
        menuButton.interactable = false;
        GameManager.Instance.MainMenu();
    }

    public void Posicion(List<RankUser> users)
    {
        int score;
        Debug.Log("imprimiendo");
        
        for(int i = 0; i < users.Count; i++)
        {
            score = Mathf.RoundToInt(users[i].score);
            scores[i].text = $"{score}";
            names[i].text = $"{users[i].name}";
        }
    }
}
