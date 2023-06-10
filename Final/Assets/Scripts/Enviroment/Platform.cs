using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Players;

    private Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        // Verifica si el objeto que ha entrado en contacto es un jugador
        for (int i = 0; i < Players.Length; i++)
        {
            if (Players[i] == col.gameObject)
            {
                Debug.Log("Hit with " + col.name);
                // Si el objeto colisionado coincide con un jugador en el arreglo, desactívalo
                Players[i].SetActive(false);
                Player.check++;
            }
            if (Player.check == 2)
            {
                Player.check = 0;
                GameManager.Instance.GameOver();
            }
        }

    }

}
