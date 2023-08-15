using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirarObjeto : MonoBehaviour
{
    public Transform objetoAMirar;      // Este es la referencia al objeto en la escena que el transform debe ver

    private void Update()
    {
        // El objeto al que este asignado este script siempre se mantiene mirando al transform asignado como objetoAMirar
        transform.LookAt(objetoAMirar);
    }
}
