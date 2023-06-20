using UnityEngine;

public class Eggs: MonoBehaviour
{
    private Rigidbody2D _rb;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        gameObject.SetActive(false);
        GameManager.Instance.AddPoints();
    }
}