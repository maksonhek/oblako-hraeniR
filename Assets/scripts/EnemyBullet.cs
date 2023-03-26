using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
  float speed =0.8f;   
    public int damage =5;

    void FixedUpdate()
    {
        Vector3 ObjectPosition = transform.position;
        ObjectPosition.y -= speed;
        transform.position = ObjectPosition; 
        if(screanHelper.IsPositionOnscreen(transform.position)==false){
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
