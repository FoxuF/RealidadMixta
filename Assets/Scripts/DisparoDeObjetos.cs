using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoDeObjetos : MonoBehaviour
{
    
    public GameObject objetoADisparar;                      // Objeto que se va a instanciar cada que demos click
    public Transform puntoDestinoDeDisparo;                 // Destino al cual los objetos voltearan a ver al ser creados
    public Transform puntoAPartirDelCualSeCrearaElObjeto;   // Punto a partir del que se instanciaran los objetos


    void Update()
    {
        // Al presionar el click principal del mouse o el primer touch en el dispositivo...
        if (Input.GetMouseButtonDown(0))
        {
            // ... Se guarda una instancia temporal del nuevo objeto creado y se genera con una rotacion por defecto en la posicion asignada en el editor
            GameObject instanciaEnTiempoReal = Instantiate(objetoADisparar, puntoAPartirDelCualSeCrearaElObjeto.position,Quaternion.identity );
            // Luego la instancia temporal se gira mirando hacia el punto al que queremos disparar
            instanciaEnTiempoReal.transform.LookAt(puntoDestinoDeDisparo.position);
        }
    }
}
