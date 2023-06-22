using System.Collections;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    public GameObject door;
    public float timeForWait = 1f;
    private bool isPressed;
    private Coroutine waitCoroutine;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressed = true;
            door.SetActive(false);
            if (waitCoroutine != null)
            {
                StopCoroutine(waitCoroutine);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPressed = false;
            waitCoroutine = StartCoroutine(WaitAndActive());
        }
    }

    private IEnumerator WaitAndActive()
    {
        yield return new WaitForSeconds(timeForWait);
        if (!isPressed)
        {
            door.SetActive(true);
        }
    }
}
