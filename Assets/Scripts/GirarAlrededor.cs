using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirarAlrededor : MonoBehaviour
{
    public Transform puntoCentral;      // Transform en la escena a partir del cual va a girar
    public float velocidad = 40f;       // La velocidad de giro que llevara el objeto 

    void Update()
    {
        // La funcion RotateAround hace que el componente transform de este objeto gire alrededor de un punto
        // (puntoCentral) y a traves de un eje (Vector positivo en Y) a una determinada velocidad
        transform.RotateAround(puntoCentral.position, Vector3.up, velocidad * Time.deltaTime);
    }
}
