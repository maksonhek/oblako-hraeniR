using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundHelper : MonoBehaviour
{
    public Renderer BackGroundRenderer;



    
    void Update()
    {
        if (BackGroundRenderer != null){
        BackGroundRenderer.material.mainTextureOffset=new Vector2(0.0f,0.1f*Time.time);


        }    
    }
}
