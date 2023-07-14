using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CambiarTamaño : MonoBehaviour
{
    public float factorAumento = 2f; // Factor de aumento del tamaño del objeto

    void Start()
    {
        // Obtén la escala actual del objeto
        Vector3 escalaActual = transform.localScale;

        // Multiplica la escala actual por el factor de aumento
        Vector3 nuevaEscala = escalaActual * factorAumento;

        // Establece la nueva escala al objeto
        transform.localScale = nuevaEscala;
    }
}
