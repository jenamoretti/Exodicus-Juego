using UnityEngine;
using UnityEngine.EventSystems;

public class MostrarYMoverFlechas : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject flecha;
    public RectTransform rectTransformFlecha;
    public Vector2 posicionInicialLocal;
    public Vector2 posicionFinalLocal;
    public float duracionMovimiento = 2f;

    private bool moverFlechas = false;
    private float tiempoTranscurrido = 0f;

    void Start()
    {   

        if (flecha != null)
        {
            flecha.SetActive(false);  // Asegura que las flechas estén ocultas al inicio.
        }
        if (rectTransformFlecha != null)
        {
            // Inicia las flechas en la posición local inicial
            rectTransformFlecha.anchoredPosition = posicionInicialLocal;
        }
    }

    void Update()
    {
        if (moverFlechas && rectTransformFlecha != null)
        {
            // Incrementa el tiempo transcurrido
            tiempoTranscurrido += Time.deltaTime;

            // Calcula el tiempo relativo dentro de la duración del movimiento (ping-pong)
            float tiempoRelativo = Mathf.PingPong(tiempoTranscurrido, duracionMovimiento) / duracionMovimiento;

            // Interpola entre la posición local inicial y final basándose en el tiempo relativo
            rectTransformFlecha.anchoredPosition = Vector2.Lerp(posicionInicialLocal, posicionFinalLocal, tiempoRelativo);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (rectTransformFlecha != null)
        {
            flecha.SetActive(true);
            moverFlechas = true;
            tiempoTranscurrido = 0f;  // Reinicia el tiempo cuando el mouse entra
            Debug.Log("OnPointerEnter: flecha activada y movimiento iniciado.");
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (rectTransformFlecha != null)
        {
            flecha.SetActive(false);
            moverFlechas = false;
            Debug.Log("OnPointerExit: flecha desactivada y movimiento detenido.");
        }
    }
}
