using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] levelSections;
    public float zPos = 320;
    public bool creatSection = false;
    public int sectionNumber;
    public GameObject player;
    public GameObject[] objs;
    public bool desClone = false;
    private void Update()
    {
        if(creatSection == false)
        {
            creatSection = true;
            StartCoroutine(GenerateSection());
        }
        if(desClone == false)
        {
            desClone = true;
            StartCoroutine(DeleteObjects());
        }
    }
    IEnumerator GenerateSection()
    {
        sectionNumber = Random.Range(0,5);
        Instantiate(levelSections[sectionNumber],new Vector3(0,0,zPos),Quaternion.identity);
        zPos += 80;
        yield return new WaitForSeconds(8);
        creatSection = false;
    }

    IEnumerator DeleteObjects()
    {
        objs = GameObject.FindGameObjectsWithTag("Section");
        for(int i = 0; i < objs.Length-1; i++)
        {
            if(player.transform.position.z > objs[i].transform.position.z+80)
            {
                Destroy(objs[i]);   
            }
            
        }
        yield return new WaitForSeconds(2);
        desClone = false;
    }
}
