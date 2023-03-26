using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupManager : MonoBehaviour
{
    public GameObject firstGroup;
   

   public BasicGroup CreateEnemyGroupp(){
      GameObject tatarGroup = Instantiate(firstGroup);
     BasicGroup groupObject = tatarGroup.GetComponent<BasicGroup>();
      return groupObject;
        }
    }

