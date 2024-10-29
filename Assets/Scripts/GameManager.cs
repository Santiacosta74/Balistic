using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public GameObject fuerzaResultados; 
    public GameObject anguloResultados; 
    public TextMeshProUGUI disparosText;
    public TextMeshProUGUI tiempoText;
    public GameObject resultadosPanel; 

    private int disparos = 0;
    private float tiempoInicio;
    private List<float> fuerzasImpacto = new List<float>();
    private List<float> angulosImpacto = new List<float>();
    private int puntosAcertados = 0;

    void Start()
    {
        tiempoInicio = Time.time;
        resultadosPanel.SetActive(false);
    }

    public void RegistrarDisparo()
    {
        disparos++;
    }

    public void RegistrarImpacto(Vector3 fuerza, float angulo, GameObject target)
    {
        // Solo registrar si el objetivo no ha sido activado antes
        if (!target.CompareTag("Activated"))
        {
            // Cambiar la etiqueta del objetivo a "Activated"
            target.tag = "Activated";

            fuerzasImpacto.Add(fuerza.magnitude);
            angulosImpacto.Add(angulo);

            puntosAcertados++;

            if (puntosAcertados >= 5) // Si se aciertan los 5 puntos
            {
                MostrarResultados();
            }
        }
    }

    void MostrarResultados()
    {
        // Calcular el tiempo total
        float tiempoTotal = Time.time - tiempoInicio;

        // Actualizar el texto de disparos y tiempo
        disparosText.text = "Disparos: " + disparos;
        tiempoText.text = "Tiempo: " + tiempoTotal.ToString("F2") + "s";

        // Mostrar fuerzas y ángulos en los contenedores
        foreach (float fuerza in fuerzasImpacto)
        {
            TextMeshProUGUI newText = Instantiate(new GameObject(), fuerzaResultados.transform).AddComponent<TextMeshProUGUI>();
            newText.text = fuerza.ToString("F2");
        }

        foreach (float angulo in angulosImpacto)
        {
            TextMeshProUGUI newText = Instantiate(new GameObject(), anguloResultados.transform).AddComponent<TextMeshProUGUI>();
            newText.text = angulo.ToString("F2");
        }

        // Mostrar el panel de resultados
        resultadosPanel.SetActive(true);
    }
}
