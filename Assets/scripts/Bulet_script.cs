using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet_script : MonoBehaviour
{
    float speed =0.5f;   
    public int damage =5;

    void FixedUpdate()
    {
        Vector3 ObjectPosition = transform.position;
        ObjectPosition.y += speed;
        transform.position = ObjectPosition; 
        if(screanHelper.IsPositionOnscreen(transform.position)==false){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider){
        GameObject otherObject = otherCollider.gameObject;
        EnemyShip enemeScript = otherObject.GetComponent<EnemyShip>();
        if(enemeScript !=null){
            enemeScript.health -=damage;
            Destroy(gameObject);
            if(enemeScript.health <=0){
                enemeScript.DestroyYouMama();
            }
        }
    }

}       
