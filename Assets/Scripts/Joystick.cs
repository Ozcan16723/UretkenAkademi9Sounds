using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joystick : MonoBehaviour
{
    [HideInInspector] public Vector2 direction;
    RectTransform knob;
    RectTransform center;
    [SerializeField] public float range;
    [SerializeField] public bool fixedJoystick;
    Buttons buttons;

    void Start()
    {
        knob = transform.GetChild(0).GetComponent<RectTransform>();
        center = transform.GetChild(1).GetComponent<RectTransform>();
        buttons = GameObject.Find("ButtonManager").GetComponent<Buttons>();

        ShowJoyStick(false);
    }

    void Update()
    {
        if (Input.touchCount > 0 && buttons.isFight == true)
        {
            Touch finger = Input.GetTouch(0);


            if (finger.phase == TouchPhase.Began && finger.position.x > 1000)
            {

                ShowJoyStick(true);

                knob.position = Input.mousePosition;
                center.position = Input.mousePosition;


            }

            if (finger.phase == TouchPhase.Moved && finger.position.x > 1000)
            {
                knob.position = Input.mousePosition;
                knob.position = center.position + Vector3.ClampMagnitude(knob.position - center.position, center.sizeDelta.x * range);

                if (knob.position != Input.mousePosition && !fixedJoystick)
                {
                    Vector3 obv = Input.mousePosition - knob.position;
                    center.position += obv;
                }



                direction = (knob.position - center.position).normalized;

            }

            if (finger.phase == TouchPhase.Ended)
            {
                ShowJoyStick(false);
                direction = Vector2.zero;
            }

        }

    }
    void ShowJoyStick(bool state)
    {
        knob.gameObject.SetActive(state);
        center.gameObject.SetActive(state);
    }
}
