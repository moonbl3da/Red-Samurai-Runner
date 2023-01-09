using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    Vector3 rotate;
    public float rotateSpeed = 10.0f;

    private void Start() 
    {
        rotate = new Vector3(1,0,0);    
    }
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        transform.Rotate(rotate, -180 * rotateSpeed * Time.deltaTime,Space.World);
        
        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }
  
}
