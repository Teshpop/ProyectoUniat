using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cartelTutorial : MonoBehaviour
{
    public GameObject cartel, oprime;
    private bool activar = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            oprime.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
      
           
            if(Input.GetKeyDown(KeyCode.E) && activar ==false)
            {
                cartel.SetActive(true);
                oprime.SetActive(false);
                activar = true;
            }
            else if(Input.GetKeyDown(KeyCode.E) && activar == true)
            {
                cartel.SetActive(false);
                oprime.SetActive(true);
                activar = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Player"))
        {
            activar = false;
            oprime.SetActive(false);
            cartel.SetActive(false);
        }
    }


 
}
