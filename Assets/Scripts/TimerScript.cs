using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public float tiempoInicial = 60.0f; // Tiempo inicial en segundos
    private float tiempoRestante;

    public TMP_Text textoTiempo; // Referencia al texto donde se mostrará el tiempo

    void Start()
    {
        tiempoRestante = tiempoInicial;
    }

    void Update()
    {
        tiempoRestante -= Time.deltaTime;

        if (tiempoRestante <= 0.0f)
        {
            // Aquí puedes agregar acciones para cuando el tiempo se agote
            // Por ejemplo, reiniciar el nivel o mostrar un mensaje de "Has perdido"
            Debug.Log("Tiempo agotado. ¡Has perdido!");
            tiempoRestante = 0.0f; // Asegurarse de que el tiempo no sea negativo
        }

        ActualizarTextoTiempo();
    }

    void ActualizarTextoTiempo()
    {
        int segundos = Mathf.CeilToInt(tiempoRestante);
        textoTiempo.text = "Tiempo: " + segundos.ToString();
    }
}
