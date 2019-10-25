/* using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshSwitch : MonoBehaviour
{
    Weapon weapon;
    public GameObject Tommy;
    public GameObject MP40;
    public GameObject Revolver;

    void Start()
    {
        weapon = GameObject.FindObjectOfType<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && weapon.getIndex() == 0)
                {
                  if (weapon.getHitObj().collider.name == "Revolver")
                    {
                        Transform temp = weapon.getHitObj().collider.GetComponent<Transform>();
                        
                        GameObject tempMesh = null;

                        if(weapon.loadout[0].name == "Tommy")
                        {
                            tempMesh = Tommy;
                        }
                        else if(weapon.loadout[0].name == "MP40")
                        {
                            tempMesh = MP40;
                        }

                        GameObject switched = Instantiate(tempMesh, temp.position, Quaternion.identity) as GameObject;
                        switched.name = weapon.loadout[0].name;
                        Destroy(weapon.getHitObj().collider.gameObject);
                    }
                    else if (weapon.getHitObj().collider.name == "Tommy")
                    {
                        Transform temp = weapon.getHitObj().collider.GetComponent<Transform>();
                        
                        GameObject tempMesh = null;
                        if(weapon.loadout[0].name == "Revolver")
                        {
                            tempMesh = Revolver;
                        }
                        else  if(weapon.loadout[0].name == "MP40")
                        {
                            tempMesh = MP40;
                        
                        }
                        GameObject switched = Instantiate(tempMesh, temp.position, Quaternion.identity) as GameObject;
                        switched.name = weapon.loadout[0].name;
                        Destroy(weapon.getHitObj().collider.gameObject);
                    }
                    else  if (weapon.getHitObj().collider.name == "MP40")
                    {
                        Transform temp = weapon.getHitObj().collider.GetComponent<Transform>();
                        
                        GameObject tempMesh = null;
                        if(weapon.loadout[0].name == "Tommy")
                        {
                            tempMesh = Tommy;
                        }
                        else if(weapon.loadout[0].name == "Revolver")
                        {
                            tempMesh = Revolver;
                        }

                        GameObject switched = Instantiate(tempMesh, temp.position, Quaternion.identity) as GameObject;
                        switched.name = weapon.loadout[0].name;
                        Destroy(weapon.getHitObj().collider.gameObject);
                    }
                }
            }
    }
 */