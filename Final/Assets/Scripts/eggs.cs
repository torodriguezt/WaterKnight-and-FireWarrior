using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eggs: MonoBehaviour
{
    [SerializeField] private Player player;

    private void OnTriggerEnter2D(Collider2D col)
    {
        player.increasePoints();
        gameObject.SetActive(false);
    }
}