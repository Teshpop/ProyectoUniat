using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameMaster gm;
    [SerializeField] private GameObject Puerta;
    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        transform.position = gm.lastChecPointsPos;
        if(gm.lastChecPointsPos == gm.PosAbrir)
        {
            Puerta.GetComponent<BoxCollider2D>().isTrigger = true;
            Puerta.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }


    
}
