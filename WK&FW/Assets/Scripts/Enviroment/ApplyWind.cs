using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyWind : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    void Start()
    {
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D col)
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
