using System.Collections;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject puerta;
    public float tiempoEspera = 1f;
    private bool estaPresionado = false;
    private Coroutine esperarCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaPresionado = true;
            puerta.SetActive(false);
            if (esperarCoroutine != null)
            {
                StopCoroutine(esperarCoroutine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            estaPresionado = false;
            esperarCoroutine = StartCoroutine(EsperarYActivar());
        }
    }

    private IEnumerator EsperarYActivar()
    {
        yield return new WaitForSeconds(tiempoEspera);
        if (!estaPresionado)
        {
            puerta.SetActive(true);
        }
    }
}
