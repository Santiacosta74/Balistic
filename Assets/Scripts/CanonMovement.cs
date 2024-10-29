using UnityEngine;

public class CannonController : MonoBehaviour
{
    [Header("Rotación")]
    public float rotationSpeedX = 100f;
    public float rotationSpeedZ = 100f; 
    public float minRotationX = -80f;   
    public float maxRotationX = -45f;   
    public float minRotationZ = -35f;   
    public float maxRotationZ = 35f;   

    private float currentRotationX = 0f;
    private float currentRotationZ = 0f;

    void Update()
    {
        // Rotación alrededor del eje X con W/S
        float rotationInputX = -Input.GetAxis("Vertical") * rotationSpeedX * Time.deltaTime;
        currentRotationX += rotationInputX;
        currentRotationX = Mathf.Clamp(currentRotationX, minRotationX, maxRotationX);

        // Rotación alrededor del eje Z con A/D
        float rotationInputZ = Input.GetAxis("Horizontal") * rotationSpeedZ * Time.deltaTime;
        currentRotationZ += rotationInputZ;
        currentRotationZ = Mathf.Clamp(currentRotationZ, minRotationZ, maxRotationZ);

        // Aplicar las rotaciones limitadas
        Vector3 currentRotation = transform.localEulerAngles;
        currentRotation.x = currentRotationX;
        currentRotation.z = currentRotationZ;
        transform.localEulerAngles = currentRotation;
    }
}

