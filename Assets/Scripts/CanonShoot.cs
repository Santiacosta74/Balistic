using UnityEngine;
using UnityEngine.UI; // Asegúrate de importar el namespace para UI

public class CannonShoot : MonoBehaviour
{
    public GameObject ballPrefab; // Prefab de la bola
    public Transform firePoint;   // Punto desde donde se dispara la bola
    public Slider forceSlider;    // Slider para controlar la fuerza

    void Start()
    {
        if (forceSlider != null)
        {
            forceSlider.onValueChanged.AddListener(OnSliderValueChanged);
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Disparar con click izquierdo
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ballPrefab == null || firePoint == null || forceSlider == null) return;

        // Instanciar la bola en la posición del firePoint
        GameObject ball = Instantiate(ballPrefab, firePoint.position, firePoint.rotation);

        // Obtener la fuerza del Slider
        float ballForce = forceSlider.value;

        // Agregar fuerza a la bola para que se dispare
        Rigidbody rb = ball.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * ballForce);
    }

    void OnSliderValueChanged(float value)
    {
        // Aquí puedes realizar alguna acción cuando cambie el valor del slider, si es necesario
    }
}
