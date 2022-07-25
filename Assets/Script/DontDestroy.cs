using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Summary: This class performs the task of maintaining the object that saves all the 
//settings that we assign to the initial music of the game, this helps us to keep the 
//music always active in all the scenes, in addition to the fact that it was done in 
//this way because it gives us the possibility of being able to deactivate it when entering a 
//scene that has a different music.

// Method Awake
//Why do we use awake()
//Awake is called when an active GameObject containing the script is initialized when a scene loads, or 
//when a previously inactive GameObject is made active, or after a GameObject created with 
//Object.Instantiate is initialized. Use Awake to initialize variables or states before the application starts.

//Variable GameObject[] musicObj
//this variable is responsible for saving all the settings made by the user
public class DontDestroy : MonoBehaviour
{
        private void Awake(){
        GameObject[] musicObj = GameObject.FindGameObjectsWithTag("Gamemusic");
        if (musicObj.Length > 1)
        {
            Destroy(this.gameObject);
            
        }
        DontDestroyOnLoad(this.gameObject);
    }
}
