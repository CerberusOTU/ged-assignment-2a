using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public float intensity;
    public float smooth;

    private Quaternion origRot;
    private void Start()
    {
        origRot = transform.localRotation;
    }

    private void Update()
    {
        UpdateSway();
    }

    private void UpdateSway()
    {
        if(Input.GetMouseButton(1))
        {
            intensity = 0;
        }
        //controls
        float xMouse = Input.GetAxis("Mouse X");
        float yMouse = Input.GetAxis("Mouse Y");

        //calculate target Rotation
        Quaternion xAdjustRot = Quaternion.AngleAxis(-intensity * xMouse, Vector3.up);
        Quaternion yAdjustRot = Quaternion.AngleAxis(intensity * yMouse, Vector3.right);

        Quaternion targetRot = origRot * xAdjustRot * yAdjustRot;

        //rotate towards target rotation
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRot, Time.deltaTime * smooth);

    }
}
