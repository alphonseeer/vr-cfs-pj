using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class nextscreenByspace : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            restandnext();
       
    }
    void restandnext()
    {
        if (Input.GetKeyDown("space"))
        {
      int currentsceneIndex = SceneManager.GetActiveScene().buildIndex;
      int nextSceneIndex = currentsceneIndex +1;
      if(nextSceneIndex  == SceneManager.sceneCountInBuildSettings)
      {
        nextSceneIndex = 0;
      }
      SceneManager.LoadScene(nextSceneIndex);
        }
      
    }
}
    
