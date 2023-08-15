using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreacionAleatoria : MonoBehaviour
{
    public GameObject objetoACrear;         // Referencia al prefab que vamos a instanciar

    public Transform[] puntosDeAparicion;   // Puntos donde puede aparecer el prefab
    public Transform puntoCentralDeRangos;
    public float rangoDeAparicion_X, rangoDeAparicion_Z;    // Rango en X y Z que delimitan el area donde puede aparecer el objeto

    public void CrearObjetoEnRango()
    {
        // Se crea un objeto Vector3 con los componentes X, Y, Z
        // X es un valor aleatorio que va desde el valor negativo de la variable rangoDeAparicion_X hasta el valor positivo de la misma
        // Y se mantiene en cero para que los objetos que se generen siempre aparezcan a la misma altura
        // Z tambien se asigna como un numero aleatorio de la misma forma que X
        Vector3 puntoAleatorio = new Vector3(Random.Range(-rangoDeAparicion_X, rangoDeAparicion_X), 0, Random.Range(-rangoDeAparicion_Z, rangoDeAparicion_Z));

        // Por practicidad del ejemplo agregamos un punto central a partir del cual contaremos este rango
        puntoAleatorio = puntoAleatorio + puntoCentralDeRangos.position;

        // Teniendo ese Vector3 como el punto dentro del area instanciable, generamos el objeto en ese punto
        Instantiate(objetoACrear, puntoAleatorio, Quaternion.identity);
    }

    public void CrearObjetoEnPuntos()
    {
        // Seleccionamos alguno de los Transform al azar del arreglo de la variable puntosDeAparicion
        // e instanciamos el objeto en la posicion del Transform seleccionado
        Instantiate(objetoACrear, puntosDeAparicion[Random.Range(0, puntosDeAparicion.Length)].position, Quaternion.identity);
    }
}
