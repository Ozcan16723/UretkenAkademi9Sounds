using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class time : MonoBehaviour
{
    [SerializeField] public float t;
    void Start()
    {
        Time.timeScale = t;
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

}
