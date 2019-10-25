using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
   ///UI///
    public Text HealthText;
    public Image Health;
    public Image DamageOverlay;
    public Image DamageFlash;
    public float PlayerHealth = 1f;

    Vector3 temp;
    

    ///////////////////

    void Start()
    {
    
    }

    void Update()
    {

        var tempColor = DamageOverlay.color;
        tempColor.a = -(PlayerHealth) * 0.01f + 1;
        var tempColor2 = DamageFlash.color;

        if (Input.GetKeyDown(KeyCode.V) && PlayerHealth > 25)
        {
            PlayerHealth -= 25;
            tempColor2.a = 0.8f;
        }
        if (Input.GetKey(KeyCode.B) && PlayerHealth < 100)
        {
            PlayerHealth += 1;
        }
        HealthText.text = (PlayerHealth).ToString();
        //Health Bar Transform
        temp = transform.localScale;
        temp.x = 1f;
        temp.y = 1f;
        Health.transform.localScale = temp;
        tempColor2.a -= 0.02f;

       
                DamageOverlay.color = tempColor;
            DamageFlash.color = tempColor2;

    }

}
