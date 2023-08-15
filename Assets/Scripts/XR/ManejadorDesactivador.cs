using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManejadorDesactivador : MonoBehaviour
{
    public void ActivarModelos()
    {
        
        ModeloCara[] modelosDeLasCaras = GameObject.FindObjectsOfType<ModeloCara>();

        for (int i = 0; i < modelosDeLasCaras.Length; i++)
            modelosDeLasCaras[i].ActivarDesactivarModelo();

        //foreach (ModeloCara cara in modelosDeLasCaras)
        //    cara.ActivarDesactivarModelo();
    }
}
