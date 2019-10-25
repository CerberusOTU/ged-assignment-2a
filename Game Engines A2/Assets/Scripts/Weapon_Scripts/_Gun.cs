using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class _Gun : ScriptableObject
{
   public string name;
   public string className;
   public float firerate;
   public float bloom;
   public float recoil;
   public float maxRecoil_x;
   public float recoilSpeed;
   public float recoilDampen; //Less is more
   public float kickBack;
   public float aimSpeed;

   //Ammo & reloading
   public float reloadTime;
   public int maxAmmo;

   public int currentAmmo;
   
   public bool isReloading;
   //////////////
   public GameObject obj;
}
