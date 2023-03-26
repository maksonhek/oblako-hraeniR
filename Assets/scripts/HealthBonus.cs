using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBonus : MonoBehaviour
{
    float speed =0.1f;
     void FixedUpdate()
    {
        Vector3 ObjectPosition = transform.position;
        ObjectPosition.y -= speed;
        transform.position = ObjectPosition; 
        if(screanHelper.IsPositionOnscreen(transform.position)==false){
            Destroy(gameObject);
        }
    }
}
