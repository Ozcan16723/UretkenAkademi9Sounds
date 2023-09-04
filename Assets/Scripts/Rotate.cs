using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    UnitController unitController;
    public float rotateSpeed;
    void Start()
    {
        unitController = transform.parent.parent.GetComponent<UnitController>();

    }

    void Update()
    {
        if (unitController.isMoveing == true)
            transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
    }
}
