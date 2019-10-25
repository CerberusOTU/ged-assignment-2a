using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class PluginReader : MonoBehaviour
{
   const string DLL_NAME = "Plugin";
   [DllImport(DLL_NAME)]
   private static extern int Test();

   void Start()
   {

   }

   void Update()
   {
      if (Input.GetKeyDown("l"))
      {
         Debug.Log(Test());
      }
   }
}