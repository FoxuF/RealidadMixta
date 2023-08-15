using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody))]          // Obliga a que este componente dependa de un Rigidbody para evitar problemas de referencias
public class MovimientoConstante : MonoBehaviour
{
    public Rigidbody componenteRigidbody;       // Componente Rigidbody que se encarga de la deteccion de fisicas
    public float velocidadMovimiento = 3f;      // Velocidad a la cual el objeto se desplazar en cada frame

    // Asigna el componente Rigidbody
    private void Awake()
    {
        // Obliga a obtener el componente Rigidbody anexado a este objeto para que los FixedUpdate no manden error por referencia vacia
        if (componenteRigidbody == null)
            componenteRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // El script constantemente avanzara hacia el vector adelante (0,0,1) en su sistema de coordenadas
        // es decir, independiente de su rotacion, la siguiente funcion hace que el objeto avance en 
        // la direccion de su flecha azul que vemos en el editor

        // Descomentar la siguiente linea para un movimiento que no dependa de fisicas 
        //transform.Translate(Vector3.forward * Time.deltaTime * velocidadMovimiento);
    }

    private void FixedUpdate()
    {
        // Esta linea mueve el objeto haciendo uso de fisicas para su deteccion de colisiones
        // funciona de una forma diferente, lo que necesita la funcion move position es un punto al cual llegar
        // el punto al cual queremos que llegue es la posicion actual del transform + el vector hacia enfrente de este objeto
        // esto creara un nuevo vector unitario que nos da la direccion a la cual se movera y luego lo multiplicamos por un
        // escalar que nos dara la distancia a la que queremos se mueva

        // NOTA: Para que detecte colisiones es necesario que el objeto tenga un Rigidbody anexado a el
        componenteRigidbody.MovePosition(transform.position + transform.forward * Time.deltaTime * velocidadMovimiento);
    }
}
