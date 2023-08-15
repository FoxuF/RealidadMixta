using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearObjetos : MonoBehaviour
{
    public GameObject objetoAInstanciar;    // Este es el objeto que queremos crear cuando presionemos sobre una superficie
    public Camera camaraEnLaEscena;         // Necesitamos la camara de la escena para determinar a partir de que punto vamos a crear el Rayo

    private void Update()
    {
        // Cuando se presione el boton principal del mouse (o el primer touch en un movil)...
        if (Input.GetMouseButtonDown(0))
        {
            // ... generar un rayo con origen en el punto donde se toco la pantalla con direccion hacia adelante de la camara
            Ray rashoLaser = camaraEnLaEscena.ScreenPointToRay(Input.mousePosition);
            // La variable infoDelChoque guardara la informacion de la colision entre el rayo y la superficie
            RaycastHit infoDelChoque;
            // La funcion Raycast evalua si ocurrio un choque entre el rayo que generamos y una superficie
            if (Physics.Raycast(rashoLaser, out infoDelChoque))
            {
                // Si ocurrio una colision se va a generar el objeto objetoAInstanciar en el punto de choque con una rotacion por defecto (Quaternion.identity)
                Instantiate(objetoAInstanciar, infoDelChoque.point, Quaternion.identity);

            }
            // Si no hubo colision entre el rayo y una superficie... no pasa nada =(
                
        }
    }
}
