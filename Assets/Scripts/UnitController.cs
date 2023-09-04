using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public float speed;
    public float attcakRange;
    public float attackSpeed;
    //public float attcakPower;
    public float qounterDeadTime;
    [HideInInspector] public bool isMoveing;
    float distance;
    float estimatedTime;
    [HideInInspector] public Vector3 direction;
    [HideInInspector] public GameObject qounterUnit;
    CalculateDistance cDistance;
    GridSystem gSystem;
    Buttons buttons;
    Effects effects;
    void Start()
    {
        cDistance = GetComponent<CalculateDistance>();
        gSystem = GameObject.Find("Grid System").GetComponent<GridSystem>();
        buttons = GameObject.Find("ButtonManager").GetComponent<Buttons>();
        effects = transform.GetChild(0).GetComponent<Effects>();

    }

    // Update is called once per frame
    void Update()
    {
        // Script oyuncu birimlerinde ise,sadece düþman sayýsý 0 dan büyükse hesap eder
        if (gameObject.CompareTag("PlayerUnit"))
        {
            if (gSystem.enemyUnits.Count <= 0)
                effects.IdleAnim();


            // CalculateDistance sýnýfýndan alýnan firstEnemy, firstPos'a atanýr
            qounterUnit = cDistance.firstEnemy();

            //Düþman ile Oyuncu arasýndaki mesafe;
            distance = Vector3.Distance(transform.position, qounterUnit.transform.position);



        }

        else // Script düþman birimlerinde ise 
        {
            if (gSystem.playerUnits.Count <= 0)
                effects.IdleAnim();

            // CalculateDistance sýnýfýndan alýnan firstPlayer, firstPos'a atanýr
            qounterUnit = cDistance.firstPlayer();

            //Düþman ile Oyuncu arasýndaki mesafe;
            distance = Vector3.Distance(transform.position, qounterUnit.transform.position);




        }

        //Birim hareket kontrolü; en yakýn karþý birime doðru, saldýrý menziline kadar hareket eder
        if (buttons.isFight == true)
        {
            direction = (qounterUnit.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction); // Bakýþ yonü

            if (distance > attcakRange)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                isMoveing = true;
                effects.RunAnim();
            }
            else
                isMoveing = false;

        }


        // saldýrý menziline girdiðinde /  distance != 0 olamlý çünkü oyun baþýnda distance 0 deðerini alýyor / 
        //butona bastýðýnda saldýrmalý.
        if (distance <= attcakRange && distance != 0 && buttons.isFight == true)
        {
            Attack(attackSpeed);

            if (qounterUnit.GetComponent<HealthBar>().health <= 0)
            {
                Dead();
            }
        }





    }

    void Attack(float delay)
    {
        if (Time.time >= estimatedTime)
        {
            //saldýrý animasyonu baþlar
            effects.AttackAnim();

            estimatedTime = Time.time + delay;
        }
    }

    void Dead()
    {
        if (gameObject.CompareTag("PlayerUnit"))  // Script oyuncu birimlerinde ise;
        {
            // Kraþý birim ölmeden önce enemyUnits dizisinden kaldýrýr
            gSystem.enemyUnits.Remove(qounterUnit);
        }
        if (gameObject.CompareTag("EnemyUnit"))// Script düþman birimlerinde ise;
        {
            // Kraþý birim ölmeden önce playerUnits dizisinden kaldýrýr
            gSystem.playerUnits.Remove(qounterUnit);
        }
        Destroy(qounterUnit, qounterDeadTime);

    }
}
