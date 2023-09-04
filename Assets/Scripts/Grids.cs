using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grids : MonoBehaviour
{
    public bool full;

    void Start()
    {
        full = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PlayerUnit"))
        {
            full = true;
        }
    }

}
