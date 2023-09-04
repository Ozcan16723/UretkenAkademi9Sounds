using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStart : MonoBehaviour
{

    void Start()
    {
        if (transform.parent.tag == "PlayerUnit")
            transform.rotation = Quaternion.Euler(0f, 45f, 0f);
        if (transform.parent.tag == "EnemyUnit")
            transform.rotation = Quaternion.Euler(0f, 225f, 0f);


    }

}
