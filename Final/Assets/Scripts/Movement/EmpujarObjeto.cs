using UnityEngine;

public class EmpujarObjeto : MonoBehaviour
{
    // Fuerza del empuje
    public float fuerzaEmpuje = 10f;
    
    // Verifica si el personaje está en contacto con el objeto a empujar
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Empujable"))
        {
            // Obtiene la dirección del empuje
            Vector2 direccionEmpuje = collision.transform.position - transform.position;
            direccionEmpuje.Normalize();

            // Aplica la fuerza del empuje al objeto
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(direccionEmpuje * fuerzaEmpuje, ForceMode2D.Impulse);
        }
    }
}