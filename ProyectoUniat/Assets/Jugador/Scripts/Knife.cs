using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 20;
    public Rigidbody2D rbKnife;
    void Start()
    {
        rbKnife.velocity=transform.right*speed;
    }

}
