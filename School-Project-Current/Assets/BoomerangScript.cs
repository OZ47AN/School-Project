using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    Rigidbody2D Boomerang;

    void Awake()
    {
        Boomerang = gameObject.GetComponent<Rigidbody2D>();

    }
}
