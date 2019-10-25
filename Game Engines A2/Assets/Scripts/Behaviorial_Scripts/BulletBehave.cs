using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehave : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Disable", 2.0f);
    }

    private void Disable()
    {
        this.transform.gameObject.SetActive(false);
    }
}
