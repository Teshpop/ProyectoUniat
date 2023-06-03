using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyConter : MonoBehaviour
{
    [SerializeField] private BoxCollider2D Puerta;
    [SerializeField] private SpriteRenderer puertaObject;
    [SerializeField] private int keys, contador;

    
    public void keyAgarrado()
    {
        keys++;
        PuertaAbierta();
    }

    private void PuertaAbierta()
    {
        if(keys >= contador)
        {
            Puerta.isTrigger = true;
            puertaObject.color = Color.white;
        }
    }
    
}
