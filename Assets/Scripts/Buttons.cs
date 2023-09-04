using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [HideInInspector] public bool forward, back, right, left, isMoved, up, down;
    [HideInInspector] public bool isFight;
    [HideInInspector] public bool remove;
    [HideInInspector] public bool isSelectedSwordsman, isSelectedmusketeer, isSelectedSmg, isSelectedMachinegun, isSelectedCannon;
    Level level;
    public Button removeButton;
    int number;
    private AudioSource audiosource;
    void Start()
    {
        number = 1;
        remove = false;
        isFight = false;
        level = GameObject.Find("Level").GetComponent<Level>();


    }

    #region MovementButtons

    //public void UpDown(float sliderValue)
    //{
    //    print(sliderValue);
    //  switch(sliderValue)
    //    {
    //        case -1:
    //            down = true;
    //            break;
    //        case 0:
    //            down = false;
    //            up = false;
    //            break;
    //        case 1:
    //            up = true;
    //            break;
    //    }

    //}
    //public void Forward()
    //{
    //    forward = !forward;
    //    isMoved = !isMoved;

    //}

    //public void Back()
    //{
    //    back = !back;
    //    isMoved = !isMoved;

    //}
    //public void Right()
    //{
    //    right = !right;
    //    isMoved = !isMoved;

    //}
    //public void Left()
    //{
    //    left = !left;
    //    isMoved = !isMoved;
    //}
    #endregion

    public void Fight()
    {
        isFight = true;
        audiosource = GameObject.Find("AudioManager").GetComponent<AudioSource>();
        audiosource.Stop();

    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void EndGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
 
    public void RemoveUnits()
    {
        number++;
        if (number % 2 == 0)
        {
            remove = true;
            removeButton.GetComponent<Image>().color = Color.red;
        }
        else
        {
            remove = false;
            removeButton.GetComponent<Image>().color = Color.black;
        }


    }

    public void Swordsman()
    {
        isSelectedSwordsman = true;

        level.swordsmanInfo.SetActive(true);
        level.musketeerInfo.SetActive(false);
        level.smgInfo.SetActive(false);
        level.machinegunInfo.SetActive(false);
        level.cannonInfo.SetActive(false);

    }
    public void Musketeer()
    {
        isSelectedmusketeer = true;

        level.swordsmanInfo.SetActive(false);
        level.musketeerInfo.SetActive(true);
        level.smgInfo.SetActive(false);
        level.machinegunInfo.SetActive(false);
        level.cannonInfo.SetActive(false);
    }
    public void Smg()
    {
        isSelectedSmg = true;

        level.swordsmanInfo.SetActive(false);
        level.musketeerInfo.SetActive(false);
        level.smgInfo.SetActive(true);
        level.machinegunInfo.SetActive(false);
        level.cannonInfo.SetActive(false);
    }
    public void Machinegun()
    {
        isSelectedMachinegun = true;

        level.swordsmanInfo.SetActive(false);
        level.musketeerInfo.SetActive(false);
        level.smgInfo.SetActive(false);
        level.machinegunInfo.SetActive(true);
        level.cannonInfo.SetActive(false);
    }
    public void Cannon()
    {
        isSelectedCannon = true;

        level.swordsmanInfo.SetActive(false);
        level.musketeerInfo.SetActive(false);
        level.smgInfo.SetActive(false);
        level.machinegunInfo.SetActive(false);
        level.cannonInfo.SetActive(true);
    }
}
