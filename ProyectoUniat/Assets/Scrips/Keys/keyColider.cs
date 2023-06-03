using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyColider : MonoBehaviour
{
    [SerializeField] keyConter keyconter;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            keyconter.keyAgarrado();
            Destroy(this.gameObject);
        }
    }
}
