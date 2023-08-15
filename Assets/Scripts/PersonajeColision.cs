using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;           /// Biblioteca que hace referencia al uso de objetos UI

public class PersonajeColision : MonoBehaviour
{
    public float vidaTotal = 100f;  // Vida total asociada a este personaje
    public Image imagenBarraVida;   // Referencia a la barra de vida que ira disminuyendo conforme reciba colisiones

    private void OnCollisionEnter(Collision collision)
    {
        // Cada que algo colisione con este objeto, disminuira en 10 la cantidad de vida de este personaje
        vidaTotal -= 10f;
        // La imagen que represent la barra de vida tiene una propiedad que se llama fillAmount, para hacer uso de ella
        // primero debe asignarse un sprite en la propiedad SourceImage en el editor. Luego en ImageType se debe
        // cambiar a Filled, apareceran varias opciones de como puede llenarse esa imagen, horizontal, vertical, etc
        // y por ultimo se normaliza el valor que queremos que este lleno ya que:
        // 0 - totalmente vacio
        // 1 - totalmente lleno
        imagenBarraVida.fillAmount = vidaTotal / 100f;

        // Puede desactivar el OTRO objeto con el que colisiono
        collision.gameObject.SetActive(false);

        // Si la vida de este personaje es menor o igual a cero, puede desactivar este objeto
        if (vidaTotal <= 0)
            gameObject.SetActive(false);
    }
}
