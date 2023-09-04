using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float mouseSens = 200;
    private float rotationX;
    public bool cameraWorking;
    Buttons buttons;
    //Joystick joystick;
    //public float joystickSenseX;
    //public float joystickSenseY;
    void Awake()
    {
        //Cursor.lockState = CursorLockMode.Locked;
    }
    void Start()
    {
        cameraWorking = true;
        buttons = GameObject.Find("ButtonManager").GetComponent<Buttons>();
        //joystick = GameObject.Find("Joystick").GetComponent<Joystick>();
    }

    // Update is called once per frame
    void Update()
    {

        if (buttons.isFight == true)
        {



            #region Pc Kontrol
            float mousePosX = Input.GetAxis("Mouse X");
            float mousePosY = Input.GetAxis("Mouse Y");

            //Oyuncunun X ekseni hareketi
            player.Rotate(Vector3.up * mousePosX * mouseSens * Time.deltaTime);

            if (cameraWorking == true)
            {
                //Kameranýn Y ekseni hareketi
                rotationX -= mousePosY;
                rotationX = Mathf.Clamp(rotationX, -90, 90);
                transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            }

            #endregion

            #region Mobil Kontrol
            //Oyuncunun X ekseni hareketi
            //player.Rotate(new Vector3(0, joystick.direction.x, 0) * joystickSenseX * Time.deltaTime);

            ////Kameranýn Y ekseni hareketi
            //transform.Rotate(new Vector3(-joystick.direction.y, 0, 0) * joystickSenseY * Time.deltaTime);
            //rotationX -= joystick.direction.y * joystickSenseY;
            //rotationX = Mathf.Clamp(rotationX, -45, 45);
            //transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            #endregion
        }



    }
}
