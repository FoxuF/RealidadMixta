using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeloCara : MonoBehaviour
{

    public GameObject modeloMascara;

    public void ActivarDesactivarModelo()
    {
        modeloMascara.SetActive(!modeloMascara.activeInHierarchy);
    }
}
