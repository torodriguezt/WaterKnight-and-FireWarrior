using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    public GameObject objectToActivate; // Objeto que se activará al entrar en contacto con el botón

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            objectToActivate.SetActive(false);
        }
    }
}
