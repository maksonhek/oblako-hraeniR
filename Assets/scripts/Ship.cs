using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ship : MonoBehaviour
{
    private AudioSource soundIgroka;
    private const float MAX_HEALTH = 15.0f;
    private float Speed =0.1f;
    private float health = MAX_HEALTH;
    private int hitCount = 0;
    public GameObject OriginalBullet;
    public GameObject hp1;
    public GameObject hp2;
    public GameObject hp3;
    public AudioClip shootUkorol;
    private List<GameObject> hpList = new List<GameObject>();
   
   void Start(){
    hpList.Add(hp1);
    hpList.Add(hp2);
    hpList.Add(hp3);
    soundIgroka=GetComponent<AudioSource>();
    soundIgroka.Play();
   }
    void Update()
    {
       bool keyFire=Input.GetKey(KeyCode.Space);
       bool keyRight=Input.GetKey(KeyCode.D);       
       bool keyLeft =Input.GetKey(KeyCode.A);
       if(keyLeft == true)
       {
       Vector3 ObjectPosition = transform.position;
       ObjectPosition.x -= Speed;
       transform.position=ObjectPosition;

       }
       if(keyRight == true)
       {
       Vector3 ObjectPosition = transform.position;
       ObjectPosition.x += Speed;
       transform.position=ObjectPosition;
       }
       if(keyFire)
       {
       GameObject BulletVersiaDva;
       BulletVersiaDva = Instantiate(OriginalBullet);
       BulletVersiaDva.transform.position = transform.position;
       soundIgroka.PlayOneShot(shootUkorol);
       }
    }
    void OnTriggerEnter2D(Collider2D otherCollider){
        GameObject otherObject = otherCollider.gameObject;
        EnemyBullet bulletScript = otherObject.GetComponent<EnemyBullet>();
        if (bulletScript != null ){
            health -=bulletScript.damage;
            onHit();
            Destroy(otherObject);
            print(bulletScript.damage);
            if(health <=0){
                SceneManager.LoadSceneAsync(SceneID.gameLoseSceneID);
                Destroy(gameObject);
            }
        }
        HealthBonus HpBonusss = otherObject.GetComponent<HealthBonus>();
        if (HpBonusss !=null){
            health = MAX_HEALTH;
            hitCount=0;
            foreach(GameObject kvadrat in hpList){
                kvadrat.SetActive(true);
            }
            Destroy(otherObject);
        }
    }
    void onHit(){
        hpList[hitCount].SetActive(false);
        hitCount+=1;
    }
}
