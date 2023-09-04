using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Buttons buttons;
    bool once = true;
    bool win, lose;
    GridSystem gSystem;
    [SerializeField] public GameObject winUI;
    [SerializeField] public GameObject loseUI;
    CameraController cameraController;
    [SerializeField] GameObject winSound;
    void Start()
    {
        buttons = GameObject.Find("ButtonManager").GetComponent<Buttons>();
        gSystem = GameObject.Find("Grid System").gameObject.GetComponent<GridSystem>();
        cameraController = GameObject.Find("Camera").gameObject.GetComponent<CameraController>();
        Time.timeScale = 1;
    }


    void Update()
    {
        // savaþ baþladýðýnda ýzgaralar kaybolur
        if (buttons.isFight == true && once == true)
        {
            GameObject.Find("PlayerGrids").SetActive(false);
            GameObject.Find("EnemyGrids").SetActive(false);
            once = false;
        }

        // kazanma ve kaybetme panelleri
        if (gSystem.playerUnits.Count <= 0 && buttons.isFight == true)
        {
            cameraController.cameraWorking = false;
            Time.timeScale = 0;
            loseUI.SetActive(true);
            lose = true;
        }
        if (gSystem.enemyUnits.Count <= 0 && buttons.isFight == true)
        {
            cameraController.cameraWorking = false;
            Time.timeScale = 0;
            winUI.SetActive(true);
            win = true;
            winSound.SetActive(true);
        }
        if (win == true && lose == true)
        {
            cameraController.cameraWorking = false;
            Time.timeScale = 0;
            winUI.SetActive(false);
        }

        //// savaþ baþladdýðýnda fare imleci kaybolur
        //if (buttons.isFight == true)
        //{
        //    Cursor.lockState = CursorLockMode.Locked;
        //}
    }
}
