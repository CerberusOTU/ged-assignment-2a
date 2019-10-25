using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public GameObject bulletHole;
    public int spawnCount;
    public List<GameObject> holeList;

    private void Start()
    {
       makeList();
    }

    void makeList()
    {
         for(int i =0; i < spawnCount; i++)
        {
            GameObject temp = Instantiate(bulletHole);   
            holeList.Add(temp);         

            temp.transform.parent = this.transform;
            temp.SetActive(false);
        }
    }
}
