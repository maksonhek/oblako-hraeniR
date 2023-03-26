using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private AudioSource musica;
    private int ColvoDestroed =0;
    private int MaxGroup = 5;
    private GroupManager  peremennayGroupManager;
    private BasicGroup currentGroup;
    public void Start()
        { ColvoDestroed =0;
            peremennayGroupManager = GetComponent<GroupManager>();
            currentGroup = peremennayGroupManager.CreateEnemyGroupp();
            musica = GetComponent<AudioSource>();
            musica.Play();
        }

    public void Update()
    {
    if (currentGroup.isAlive == false){
        Destroy (currentGroup.gameObject);
        ColvoDestroed++;
        if (ColvoDestroed==MaxGroup){
            SceneManager.LoadSceneAsync(SceneID.gameWinSceneID);
        }else{
            currentGroup=peremennayGroupManager.CreateEnemyGroupp();
        }    
    }        
    }
}
