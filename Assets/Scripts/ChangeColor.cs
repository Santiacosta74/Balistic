using UnityEngine;

public class ChangeColorOnImpact : MonoBehaviour
{
    public Material impactMaterial; // Material verde que se aplicará al impacto

    private Renderer objectRenderer;

    void Start()
    {
        // Obtener el Renderer del objeto
        objectRenderer = GetComponent<Renderer>();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Cambiar el material al material verde al recibir un impacto
        objectRenderer.material = impactMaterial;
    }
}
