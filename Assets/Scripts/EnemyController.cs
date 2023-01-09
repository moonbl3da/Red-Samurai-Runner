using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    void Update()
    {
        transform.Translate(Vector3.back * Time.deltaTime * moveSpeed, Space.World);
        if(transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.CompareTag("Gate"))
        {
            Destroy(this.gameObject);
        }    
    }
}
