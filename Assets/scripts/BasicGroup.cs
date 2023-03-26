using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGroup : MonoBehaviour
{
    
    public EnemyShip ship1;
    public EnemyShip ship2;
    public EnemyShip ship3;
    public EnemyShip ship4;
    public bool isAlive = true;
    private float speed = 0.1f;
    private List<EnemyShip> ships = new List<EnemyShip>(); 
    private bool MoveLeft =true;
   
    private System.Random randomGenerator = new System.Random();
    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);
        ships.Add(ship4);
        InvokeRepeating("timeTooShoot", 1.0f, 1.0f);
    }
   
    // Update is called once per frame
    void FixedUpdate()

    {
      ships.RemoveAll(item=> item == null);
       ships.RemoveAll(item=> item.health <= 0);
        if (ships.Count == 0){
                isAlive =false;
                CancelInvoke();
                return;
        }
        if(MoveLeft)
        {
            float minX=MinX();
            float stepX =minX-speed;
            if (stepX <-17){
                MoveLeft = false;   
            }
            else{
                transform.position = new Vector3(
                    transform.position.x - speed, 
                    transform.position.y,
                    0
                ); 

            }
        } else {
            float maxX =MaxX();    
            float stepX =maxX+speed;
            if(stepX > 17){
                MoveLeft = true;
            }
            else{
                transform.position = new Vector3(
                        transform.position.x + speed, 
                        transform.position.y,
                        0
                );

            }
        }
    }
         
    float MaxX(){
        int i = 0;
        float Max = float.MinValue;
        while(i< ships.Count){
            if(ships[i].transform.position.x >Max){
                Max=ships[i].transform.position.x;
            }
            i++;
        }    
        return Max;
    }

    float MinX() {
        int i =0;
        
        float Min =float.MaxValue;
        while(i<ships.Count){
            if(ships[i].transform.position.x<Min){
                Min=ships[i].transform.position.x;
            }
            i++;
        }
        return Min;
    }

void timeTooShoot(){
   int randomIndex = randomGenerator.Next(ships.Count);
   ships[randomIndex].Vistrel();
}
}
