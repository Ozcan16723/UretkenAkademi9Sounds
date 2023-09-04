using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class CalculateDistance : MonoBehaviour
{
    GridSystem gSystem;
    bool enemyCycle;
    bool playerCycle;
    int enemyUnitÝndex;
    int playerUnitÝndex;
    float eMin;
    float pMin;
    void Start()
    {
        enemyCycle = true;
        playerCycle = true;
        gSystem = GameObject.Find("Grid System").GetComponent<GridSystem>();
    }
    private void Update()
    {

    }
    public GameObject firstEnemy()
    {

        if (gSystem.enemyUnits.Count > 0) //Ekranda düþman varsa
        {

            if (enemyCycle) // Birlikler hareket ediyorsa
            {
                gSystem.enemyDistance.Clear(); // düþman deðerleri dizisi her döngüde temizlenmeli
                for (int i = 0; i < gSystem.enemyUnits.Count; i++)
                {
                    // herhangi bir düþman deðeri boþ ise kaldýr
                    if (gSystem.enemyUnits[i] == null)
                        gSystem.enemyUnits.Remove(gSystem.enemyUnits[i]);

                    // düþman uzaklýk deðerleri distance dizisinde toplanýr
                    gSystem.enemyDistance.Add(Vector3.Distance(transform.position, gSystem.enemyUnits[i].transform.position));

                }

                // distance eleman sayýsý sýfýr olmamalý          
                if (gSystem.enemyDistance.Count != 0)
                {
                    eMin = gSystem.enemyDistance[0];
                    enemyUnitÝndex = 0;
                    for (int j = 0; j < gSystem.enemyDistance.Count; j++)
                    {
                        // min deðeri distance dizisndeki her elmanla karþýlaþtýrýlýr. 
                        if (eMin > gSystem.enemyDistance[j]) // Min deðeri, o andaki distance elmanýndan büyükse 
                        {
                            eMin = gSystem.enemyDistance[j];
                            enemyUnitÝndex = j; // ***Düþman dizisi indexi ile distance dizisi indexlerini baðlar***
                        }
                    }
                }


                enemyCycle = false;
            }

            // Düþman birliklerinin hareket etmesi durumunu kontrol eder.
            for (int i = 0; i < gSystem.enemyUnits.Count; i++)
            {
                enemyCycle = gSystem.enemyUnits[i].transform.hasChanged; //cycyle = true
            }

            return gSystem.enemyUnits[enemyUnitÝndex];

        }

        else return gameObject;
    }

    public GameObject firstPlayer()
    {
        if (gSystem.playerUnits.Count > 0) //Ekranda player varsa
        {
            if (playerCycle) // Birlikler hareket ediyorsa
            {
                gSystem.playerDistance.Clear(); // düþman deðerleri dizisi her döngüde temizlenmeli
                for (int i = 0; i < gSystem.playerUnits.Count; i++)
                {
                    if (gSystem.playerUnits[i] == null)
                        gSystem.playerUnits.Remove(gSystem.playerUnits[i]);

                    // düþman uzaklýk deðerleri distance dizisinde toplanýr
                    gSystem.playerDistance.Add(Vector3.Distance(transform.position, gSystem.playerUnits[i].transform.position));

                }

                // distance eleman sayýsý sýfýr olmamalý          
                if (gSystem.playerDistance.Count != 0)
                {
                    pMin = gSystem.playerDistance[0];
                    playerUnitÝndex = 0;
                    for (int j = 0; j < gSystem.playerDistance.Count; j++)
                    {
                        // min deðeri distance dizisndeki her elmanla karþýlaþtýrýlýr. 
                        if (pMin > gSystem.playerDistance[j]) // Min deðeri, o andaki distance elmanýndan büyükse 
                        {
                            pMin = gSystem.playerDistance[j];
                            playerUnitÝndex = j; // ***Düþman dizisi indexi ile distance dizisi indexlerini baðlar***
                        }
                    }
                }


                playerCycle = false;
            }

            // Düþman birliklerinin hareket etmesi durumunu kontrol eder.
            for (int i = 0; i < gSystem.playerUnits.Count; i++)
            {
                playerCycle = gSystem.playerUnits[i].transform.hasChanged; //cycyle = true
            }

            return gSystem.playerUnits[playerUnitÝndex];

        }

        else return gameObject;
    }
}
