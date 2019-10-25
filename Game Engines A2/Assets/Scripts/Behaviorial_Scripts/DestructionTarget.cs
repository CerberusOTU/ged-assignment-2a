using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionTarget : MonoBehaviour
{
    private Rigidbody rb;
    bool damageTaken = false;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void takeDamage(float amount)
    {
       damageTaken = true;
    }

    void Update()
    {
        if(damageTaken == true)
        {
            rb.constraints = RigidbodyConstraints.None;
            rb.AddForce(Vector3.forward * 2, ForceMode.Impulse);

            Destroy(gameObject, 1.0f);
        }
    }
}
