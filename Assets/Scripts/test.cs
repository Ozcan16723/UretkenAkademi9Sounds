using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
public class test : MonoBehaviour
{
    public bool full;
    //public float delay;
    //float estimatedTime = 0;
    //public GameObject cube;

    //RaycastHit obj;
    //Camera cam;
    //cam = GameObject.Find("Main Camera").GetComponent<Camera>();
    //public Camera mainCamera;
    // Start is called before the first frame update


    //GameObject[] objArray;
    //List<GameObject> objList;
    void Start()
    {
        full = false;
        //objArray = GameObject.FindGameObjectsWithTag("object");
        //objList = GameObject.FindGameObjectsWithTag("object").ToList<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        #region before
        //Ray hit = mainCamera.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(hit, out _object, 100f))
        //{
        //    if (_object.collider.tag == "Grid")
        //    {
        //        Debug.Log(_object.transform.position);
        //    }
        //}
        #endregion

        #region nesneden nesneye ýþýn
        //if (Input.GetMouseButton(0) && Physics.Raycast(transform.position, new Vector3(-1, 0, 0), out obj, 10f) && obj.collider.tag == "Player")
        //{
        //    Debug.Log("collided");
        //}
        #endregion

        #region kameradan nesneye ýþýn
        //Ray ray = cam.ViewportPointToRay(new Vector2(0.5f, 0.5f));
        //if (Input.GetMouseButton(0) && Physics.Raycast(ray, out obj, 100f) && obj.collider.tag == "Player")
        //{
        //    Debug.Log("collided");
        //}
        #endregion

        #region mouse imlecinden nesneye ýþýn
        //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        //if (Input.GetMouseButton(0) && Physics.Raycast(ray, out obj, 100f) && obj.collider.tag == "Grid")
        //{
        //    Debug.Log(obj.transform.position);
        //}
        #endregion

        //Timer(delay);

    }

    //void Timer(float delay)
    //{
    //    if (Time.time>=estimatedTime)
    //    {
    //        Debug.Log(".");
    //        estimatedTime= Time.time + delay;
    //    }
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("PlayerUnit"))
        {
            full = true;
        }
    }

}
