using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start(){
        Instantiate(CharacterManager.instance.currentCharacter.prefab,transform.position,Quaternion.identity);
    }
}
