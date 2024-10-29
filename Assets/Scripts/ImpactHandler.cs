using UnityEngine;

public class ImpactHandler : MonoBehaviour
{
    private GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("HingeTarget"))
        {
            // Registrar el disparo y el impacto
            gameManager.RegistrarDisparo();

            // Calcular la fuerza y el ángulo del impacto
            Vector3 fuerzaImpacto = collision.relativeVelocity;
            float anguloImpacto = Vector3.Angle(collision.contacts[0].normal, fuerzaImpacto);

            // Registrar el impacto con la fuerza y el ángulo
            gameManager.RegistrarImpacto(fuerzaImpacto, anguloImpacto);
        }
    }
}
