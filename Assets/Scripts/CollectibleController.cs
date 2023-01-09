using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CollectibleController : MonoBehaviour
{
    private float rotateSpeed = 1.0f;
    Vector3 rotate;
    private void Start() 
    {
            rotate = new Vector3(0,1,0);
            StartCoroutine(Spinning());    
    }
    private IEnumerator Spinning()
    {
        while(true)
        {
            transform.Rotate(rotate, 360 * rotateSpeed * Time.deltaTime);
            yield return 0;
        }
    }

     private void OnCollisionEnter(Collision other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            //Debug.Log("Collision");
            Destroy(this.gameObject);
        }    
    }
}
