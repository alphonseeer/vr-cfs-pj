using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class erpControler : MonoBehaviour
{
       //oj and time
     [SerializeField]public GameObject target; 
    [SerializeField] public float targetTimeIN =  0F;
    [SerializeField] public float targetTime=  0F;

    [SerializeField]public GameObject Screen; 
    [SerializeField] public float ScreenTimeIN =  0F;
    [SerializeField] public float ScreenTime=  0F;

    [SerializeField]public GameObject stimuli; 
    [SerializeField] public float stimuliTimeIN =  0F;
    [SerializeField] public float stimuliTime=  0F;
   
   //set trial time

    [SerializeField] public float   OneTrialTime =  15F;
    [SerializeField] public int     trialtime = 2;

    //timecounter
    int trialtimeNow = 0;
    float TimeCounter =0f;

    //set to get the stimuli texture 
    [SerializeField]public Texture[] textures;
    //public float changeInterval = 1F;
    public Renderer rend;
    [SerializeField] public GameObject StimuliPic;
   
   
    // Start is called before the first frame update
    void Start()
    {
         rend = StimuliPic.GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
         TimeCounter += Time.deltaTime;
targetControl () ;
ScreenControl () ;
StimuleControl ();
setPicEachTrial ();




         EndOnetrial();
         restandnext();

    }


    void targetControl () 
    {
         if (TimeCounter >=targetTime+targetTimeIN )
        {
            target.SetActive(false);

        }
        else if(TimeCounter >=targetTimeIN)
        {
            target.SetActive(true);
        }

    }


    void ScreenControl () 
    {
         if (TimeCounter >=ScreenTime+ScreenTimeIN )
        {
            Screen.SetActive(false);

        }
        else if(TimeCounter >=ScreenTimeIN)
        {
            Screen.SetActive(true);
        }

    }

    void StimuleControl ()
    {
        if(TimeCounter>=stimuliTimeIN  )
        {
          stimuli.SetActive(true);
        }
        else if (TimeCounter  >=stimuliTime+stimuliTimeIN)
        {
            stimuli.SetActive(false);
        }
    }


    
    void setPicEachTrial ()
    {
         int index =trialtimeNow ; 
         Debug.Log(index);
         rend.material.mainTexture = textures[index];

    }

     void EndOnetrial()
    {
      if (TimeCounter>= OneTrialTime )
      {

       setPicEachTrial ();
       
       
        TimeCounter= 0;
        trialtimeNow++;
        
      }

    }
        void restandnext()
    {
       if(trialtimeNow>=trialtime){

       
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
