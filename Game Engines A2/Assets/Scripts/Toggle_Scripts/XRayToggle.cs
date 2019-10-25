using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XRayToggle : MonoBehaviour
{
    public GameObject partner;
    public Material baseMat;
    public Material xrayMat;

     void Start()
    {
        //Fetch the Material from the Renderer of the GameObject
        partner.GetComponent<MeshRenderer> ().material = baseMat;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.X))
        {
            partner.GetComponent<MeshRenderer> ().material = xrayMat;
        }
        else
        {
            partner.GetComponent<MeshRenderer> ().material = baseMat;
        }
    }
}
