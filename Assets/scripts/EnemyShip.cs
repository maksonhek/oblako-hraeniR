using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    private AudioSource soundKaboom;
    private System.Random generator = new System.Random();
    public GameObject hpBonusOriginal;
    public GameObject bulletOriginal;
    public Animator SpriteAnimatorA4;
    public AudioClip soundBoom;
    public int health = 10; 
    public void Start(){
        soundKaboom=GetComponent<AudioSource>();
        
    }
    public void Vistrel(){
    GameObject newBullet = Instantiate(bulletOriginal);
    newBullet.transform.position = transform.position;
    }
    public void DestroyYouMama(){
        transform.parent = null;
        SpriteAnimatorA4.SetBool("DeadInside", true);
        soundKaboom.PlayOneShot(soundBoom);
    }
    public void OnDestroyEnemyAnimationOn(){
        double randomValue=generator.NextDouble();
        if (randomValue>0.7){
            GameObject hpBonus = Instantiate(hpBonusOriginal);
            hpBonus.transform.position = transform.position;
        }
        Destroy(gameObject);
    }
}
