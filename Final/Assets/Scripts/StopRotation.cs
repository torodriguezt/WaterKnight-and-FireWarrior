using UnityEngine;

public class StopRotation : MonoBehaviour
{
    public float tiempoDetenerRotacion = 5f; // tiempo en segundos

    private float tiempoInicio = 0f;
    private bool detenerRotacion = false;

    private void Update()
    {
        if (Time.time >= tiempoInicio + tiempoDetenerRotacion && detenerRotacion)
        {
            var rigidbody = GetComponent<Rigidbody>();
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.freezeRotation = true;
            detenerRotacion = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (detenerRotacion)
        {
            return;
        }

        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.freezeRotation = false;
        tiempoInicio = Time.time;
        detenerRotacion = true;
    }
}
