using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float rotationDuration = 5f; // Duración de rotación en segundos
    public AnimationCurve rotationCurve; // Curva de animación para la rotación gradual

    private float rotationTime; // Tiempo de rotación actual
    private Quaternion startRotation; // Rotación inicial de la plataforma
    private Quaternion targetRotation; // Rotación objetivo de la plataforma
    private bool rotating; // Indica si la plataforma está rotando

    private void Start()
    {
        startRotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        if (rotating)
        {
            // Calcular la rotación actual usando la curva de animación
            float t = rotationTime / rotationDuration;
            Quaternion currentRotation = Quaternion.Lerp(startRotation, targetRotation, rotationCurve.Evaluate(t));

            // Rotar gradualmente la plataforma
            transform.rotation = currentRotation;

            // Actualizar el tiempo de rotación
            rotationTime += Time.fixedDeltaTime;

            // Si se ha alcanzado la duración de rotación, detener la rotación
            if (rotationTime >= rotationDuration)
            {
                rotating = false;
            }
        }
    }

    // Método para iniciar la rotación de la plataforma
    public void StartRotation()
    {
        rotationTime = 0f;
        rotating = true;
        targetRotation = startRotation * Quaternion.Euler(0, 0, 90); // Rotación objetivo de 90 grados
    }

    // Método para detener la rotación de la plataforma
    public void StopRotation()
    {
        rotating = false;
        rotationTime = 0f;
        transform.rotation = startRotation; // Restaurar la rotación inicial
    }
}