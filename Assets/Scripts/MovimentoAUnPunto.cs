using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoAUnPunto : MonoBehaviour
{
    public Transform puntoDestino;      // Punto al cual vamos a avanzar
    public float velocidad = 5f;             // velocidad que va a llevar al caminar hacia el punto destino
    
    // Update is called once per frame
    void Update()
    {
        // En cada frame, la posicion de este objeto sera igual a un vector que se compone de la siguiente manera:
        // MoveTowards crea un nuevo vector que consiste en utilizar la posicion inicial, el punto destino y
        // alcance maximo en la distancia entre ambos
        transform.position = Vector3.MoveTowards(transform.position, puntoDestino.position, velocidad * Time.deltaTime);

        // Opcionalmente podemos hacer que voltee a ver al punto donde se quiere dirigir
        transform.LookAt(puntoDestino.position);
    }
}
