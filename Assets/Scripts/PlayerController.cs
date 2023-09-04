using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed;
    bool once;
    //public float playerHorizontalSpeed;
    //public float playerVerticalSpeed;
    Buttons buttons;
    //bool once;

    private void Start()
    {
        once = true;
        // baþlangýç rotasyonu
        transform.Rotate(30, -90, 0);
        buttons = GameObject.Find("ButtonManager").GetComponent<Buttons>();
    }
    void Update()
    {
        #region Pc Kontrol
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontal * playerSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * vertical * playerSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Translate(-Vector3.up * playerSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Translate(Vector3.up * playerSpeed * Time.deltaTime);
        }
        #endregion

        #region Mobil Kontrol

        //if (buttons.forward == true)
        //    transform.Translate(Vector3.forward * playerHorizontalSpeed * Time.deltaTime); 
        //if (buttons.back == true)
        //    transform.Translate(Vector3.back * playerHorizontalSpeed * Time.deltaTime); 
        //if (buttons.right == true)
        //    transform.Translate(Vector3.right * playerHorizontalSpeed * Time.deltaTime); 
        //if (buttons.left == true)
        //    transform.Translate(Vector3.left * playerHorizontalSpeed * Time.deltaTime);
        //if (buttons.up == true)
        //    transform.Translate(Vector3.up * playerVerticalSpeed * Time.deltaTime);
        //if (buttons.down == true)
        //    transform.Translate(Vector3.down * playerVerticalSpeed * Time.deltaTime);
        #endregion

        //Savaþ baþladýðýnda rotasyon normale döner.
        if (buttons.isFight == true && once == true)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
            once = false;
        }
    }



}
