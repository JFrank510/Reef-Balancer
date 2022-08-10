using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{
    private void Start(){
        GameObject track = (GameObject) Instantiate(CharacterManager.instance.currentCharacter.prefab,transform.position,Quaternion.identity);
        track.name = "Player";
    }
}
