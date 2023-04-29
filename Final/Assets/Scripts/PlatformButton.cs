using UnityEngine;

public class PlatformButton : MonoBehaviour
{
    public GameObject platform;
    public float activationTime = 1f;

    private float timeOnButton = 0f;
    private bool platformActivated = false;

    private void OnCollisionStay(Collision collision)
    {
        // si el jugador está encima del botón
        if (collision.gameObject.CompareTag("Player"))
        {
            timeOnButton += Time.deltaTime;

            // si el tiempo que el jugador está sobre el botón es mayor o igual al tiempo de activación, entonces activa la plataforma
            if (timeOnButton >= activationTime && !platformActivated)
            {
                platform.SetActive(true);
                platformActivated = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // si el jugador sale del botón
        if (collision.gameObject.CompareTag("Player"))
        {
            timeOnButton = 0f;

            // desactiva la plataforma
            if (platformActivated)
            {
                platform.SetActive(false);
                platformActivated = false;
            }
        }
    }
}
