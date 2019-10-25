using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Look : MonoBehaviour
{
    public static bool cursorLocked = true;
    public Transform player;
    public Transform cams;
    public Transform weapon;
    public float xSens;
    public float ySens;

    public float maxAngle;

    private Quaternion camCenter;
    void Start()
    {
        camCenter = cams.localRotation; //set rotation origin for cameras to camCenter

       
    }

    // Update is called once per frame
    void Update()
    {
        SetY();
        SetX();
        CursorLock();
    }

    void SetY()
    {
        float input = Input.GetAxis("Mouse Y") * ySens * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, -Vector3.right);
        Quaternion delta = cams.localRotation * adj;

        if(Quaternion.Angle(camCenter, delta) < maxAngle)
        {
            cams.localRotation = delta;
        } 
        else if(cams.localRotation.eulerAngles.x < (360 - maxAngle))
        {
            cams.localRotation = Quaternion.Slerp(cams.localRotation, Quaternion.Euler(360 - maxAngle, 0, 0), Time.deltaTime * 4f);
        }
        else if(cams.localRotation.eulerAngles.x < (maxAngle))
        {
            cams.localRotation = Quaternion.Slerp(cams.localRotation, Quaternion.Euler(maxAngle, 0, 0), Time.deltaTime * 4f);
        }
    }

     void SetX()
    {
        float input = Input.GetAxis("Mouse X") * ySens * Time.deltaTime;
        Quaternion adj = Quaternion.AngleAxis(input, Vector3.up);
        Quaternion delta = player.localRotation * adj;
        player.localRotation = delta;
    }

    void CursorLock()
    {
        if(cursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = false;               
            }
        }
        else
        {
           Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true;

            if(Input.GetKeyDown(KeyCode.Escape))
            {
                cursorLocked = true;               
            }     
        }
    }
}
