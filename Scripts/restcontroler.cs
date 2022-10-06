using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]

public class restcontroler : MonoBehaviour
{
   
   
    



    [SerializeField] public float   RestTime = 50F;
                     float          TimeCounter =0f;
    [SerializeField] public float  AlarmTime = 20F;


     [SerializeField] AudioSource audioData;
      [SerializeField] public GameObject restmusic ;





    // Start is called before the first frame update
    void Start()
    {
        
        audioData =restmusic. GetComponent<AudioSource>();

        // stop from the start
       audioData.Stop();
       //play on the time we set
       audioData.PlayDelayed(AlarmTime);
         
    }

    // Update is called once per frame
    void Update()
    {
       TimeCounter += Time.deltaTime; 
      
       EndRestime ();
    }



    void EndRestime ()
    {
        if(TimeCounter>=RestTime)
        {
           
         // SceneManager.LoadScene("CFS huang", LoadSceneMode.Single); 
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
