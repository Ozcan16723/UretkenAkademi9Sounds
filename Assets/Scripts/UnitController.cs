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
        // Script oyuncu birimlerinde ise,sadece d��man say�s� 0 dan b�y�kse hesap eder
        if (gameObject.CompareTag("PlayerUnit"))
        {
            if (gSystem.enemyUnits.Count <= 0)
                effects.IdleAnim();


            // CalculateDistance s�n�f�ndan al�nan firstEnemy, firstPos'a atan�r
            qounterUnit = cDistance.firstEnemy();

            //D��man ile Oyuncu aras�ndaki mesafe;
            distance = Vector3.Distance(transform.position, qounterUnit.transform.position);



        }

        else // Script d��man birimlerinde ise 
        {
            if (gSystem.playerUnits.Count <= 0)
                effects.IdleAnim();

            // CalculateDistance s�n�f�ndan al�nan firstPlayer, firstPos'a atan�r
            qounterUnit = cDistance.firstPlayer();

            //D��man ile Oyuncu aras�ndaki mesafe;
            distance = Vector3.Distance(transform.position, qounterUnit.transform.position);




        }

        //Birim hareket kontrol�; en yak�n kar�� birime do�ru, sald�r� menziline kadar hareket eder
        if (buttons.isFight == true)
        {
            direction = (qounterUnit.transform.position - transform.position).normalized;
            transform.rotation = Quaternion.LookRotation(direction); // Bak�� yon�

            if (distance > attcakRange)
            {
                transform.Translate(Vector3.forward * Time.deltaTime * speed);
                isMoveing = true;
                effects.RunAnim();
            }
            else
                isMoveing = false;

        }


        // sald�r� menziline girdi�inde /  distance != 0 olaml� ��nk� oyun ba��nda distance 0 de�erini al�yor / 
        //butona bast���nda sald�rmal�.
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
            //sald�r� animasyonu ba�lar
            effects.AttackAnim();

            estimatedTime = Time.time + delay;
        }
    }

    void Dead()
    {
        if (gameObject.CompareTag("PlayerUnit"))  // Script oyuncu birimlerinde ise;
        {
            // Kra�� birim �lmeden �nce enemyUnits dizisinden kald�r�r
            gSystem.enemyUnits.Remove(qounterUnit);
        }
        if (gameObject.CompareTag("EnemyUnit"))// Script d��man birimlerinde ise;
        {
            // Kra�� birim �lmeden �nce playerUnits dizisinden kald�r�r
            gSystem.playerUnits.Remove(qounterUnit);
        }
        Destroy(qounterUnit, qounterDeadTime);

    }
}
