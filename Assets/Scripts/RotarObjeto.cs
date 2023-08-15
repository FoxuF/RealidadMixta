using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotarObjeto : MonoBehaviour
{
    public Transform objetoARutar;              // Transform en la escena al que vamos a girar
    public float velocidadRotacion = 50f;       // Velocidad de giro

    private Vector3 posicionAnterior;           // Para el caso de que estemos en PC, tenemos que guardar la posicion anterior del mouse en cada frame

    void Update()
    {
#if UNITY_EDITOR            // ESTE IF LIMITA QUE SE EJECUTE EL SIGUIENTE CODIGO SOLO SI ESTA CORRIENDO EN EL EDITOR DE UNITY
        // Al presionar por primera vez el boton principal del mouse...
        if (Input.GetMouseButtonDown(0))
        {
            // ... guardamos la posicion del mouse para manejar la diferencia de desplazamiento
            posicionAnterior = Input.mousePosition;
        }

        // Mientras estemos presionando el boton del mouse...
        if (Input.GetMouseButton(0))
        {
            // Obtenemos un vector de desplazamiento respecto a la posicion anterior
            Vector3 deltaPosicion = posicionAnterior - Input.mousePosition;
            // Creamos el vector de rotcion que se conforma por la diferencia de posiciones del mouse
            // en el componente X ponemos la diferencia en Y, que es cuando el mouse se desplaza de un lado a otro,
            // Esto provocara que se gire de arriba hacia abajo sobre el vector X
            // La diferencia de posicion en las coordenadas X de la pantalla rotaran sobre el eje Y el objeto
            Vector3 vectorDeRotacion = new Vector3(deltaPosicion.y, deltaPosicion.x, 0);
            // Finalmente vamos a rotar el objeto segun el vector creado anteriormente y lo multiplicamos por la velocidad
            objetoARutar.Rotate(vectorDeRotacion * Time.deltaTime * velocidadRotacion);

            // Por ultimo para el calculo de deltaPosicion del siguiente frame, actualizamos la posicionAnterior  como la posicion de este frame
            posicionAnterior = Input.mousePosition;

        }

#else   // EN CUALQUIER OTRO CASO QUE LA APLICACION SE ESTE EJECUTANDO EN OTRA PLATAFORMA QUE NO SEA EL EDITOR ENTRARA A EJECUTAR ESTE CODIGO E IGNORARA EL CODIGO DE ARRIBA
        // Si la cantidad de touch que hay actualmente en la pantalla es mayor a cero (es decir al menos un dedo se presiono sobre la pantalla)...
        if (Input.touchCount>0)
        {
            // ... guardamos la informacion del primer touch detectado en la pantalla
            Touch primerTouch = Input.GetTouch(0);
            // Generamos la informacion del vector de rotacion utilizando la propiedad deltaPosition del touch que ya nos da
            // la diferencia de movimiento en pantalla tal como lo hicimos con el calculo con el mouse
            Vector3 vectorDeRotacionTouch = new Vector3(primerTouch.deltaPosition.y, primerTouch.deltaPosition.x, 0);
            // Finalmente aplicamos la rotacion, en este caso no es necesario guardar la informacion de la posicion
            // actual ya que el touch ya tiene el calculo de la diferencia de posicion touch
            objetoARutar.Rotate(vectorDeRotacionTouch * Time.deltaTime * velocidadRotacion);
        }
#endif

    }
}
