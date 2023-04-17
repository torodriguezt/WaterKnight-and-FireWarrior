using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement1 : MonoBehaviour
{
    public float speed = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        // Derecha
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x + speed * Time.deltaTime;
            transform.position = newPosition;
        }

        // Izquierda
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 newPosition = transform.position;
            newPosition.x = newPosition.x - speed * Time.deltaTime;
            transform.position = newPosition;
        }

        // Arriba
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = newPosition.y + speed * Time.deltaTime;
            transform.position = newPosition;
        }

        // Abajo
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Vector3 newPosition = transform.position;
            newPosition.y = newPosition.y - speed * Time.deltaTime;
            transform.position = newPosition;
        }

    }
}

