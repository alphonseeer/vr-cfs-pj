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



    [SerializeField]public GameObject stimuli; 
    [SerializeField] public float stimuliTimeIN =  0F;
    [SerializeField] public float stimuliTime=  0F;

    [SerializeField] public float NatureTime=  1F;
    [SerializeField] public float NegativeTime=  1F;
    [SerializeField] public float PostiveTime=  1F;

    public float OpenTime=  2F;
    float randomRestTime1 ; 
    float randomRestTime2; 
    float randomRestTime3; 
   
   //set trial time

    [SerializeField] public float   OneTrialTime =  15F;
    [SerializeField] public int     trialtime = 2;

    //TimeCounter
    int trialtimeNow = 0;
    float TimeCounter =0f;

    //set to get the stimuli texture 
    [SerializeField]public Texture[] texturesNature;
     [SerializeField]public Texture[] texturesNegative;
      [SerializeField]public Texture[] texturesPostive;


    [SerializeField]public Texture[] crossPoint;

   

    //public float changeInterval = 1F;
    public Renderer rend;
    [SerializeField] public GameObject StimuliPic;

    //
         float point1 ;
         float point2 ;
         float point3 ;
         float point4 ;
         float point5 ; 
         float point6 ;
         bool point01;
         bool point12 ;
         bool point23 ;
         bool point34 ;
         bool point45 ;
         bool point56 ;


   
   
    // Start is called before the first frame update
    void Start()
    {
         rend = StimuliPic.GetComponent<Renderer>(); 


          point01 = true ;
          point12 = true ;
           point23 = true ;
          point34 = true ;
          point45 = true;
          point56 = true ;
         
         randomRestTime1 =UnityEngine. Random.Range(0.7f,1.5f);
         randomRestTime2 =UnityEngine. Random.Range(0.7f,1.5f);
         randomRestTime3 =UnityEngine. Random.Range(0.7f,1.5f);

          point1 =NatureTime+OpenTime;
          point2 = point1 +randomRestTime1;
         point3 = point2 + NegativeTime ;
          point4 = point3+ randomRestTime2;
          point5 = point4 + PostiveTime; 
          point6 = point5 + randomRestTime3 ;

          OneTrialTime = point6;



    }

    // Update is called once per frame
    void Update()
    {
         TimeCounter += Time.deltaTime;
         
         
      
         
         setThreeTypePic();




         EndOnetrial();
         restandnext();

    }


    void targetControl () 
    {
         if (TimeCounter >=targetTime+targetTimeIN )
        {
            target.SetActive(true);

        }
        else if(TimeCounter >=targetTimeIN)
        {
            target.SetActive(true);
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
            stimuli.SetActive(true);
        }
    }


    
    void setPicEachTrial ()
    {
         int index =trialtimeNow ; 
         Debug.Log(index);
         rend.material.mainTexture = texturesNature[index];

    }
       
    void setThreeTypePic()
    {
          int index =trialtimeNow ; 
        
        if(TimeCounter<OpenTime)
        {
             rend.material.mainTexture = crossPoint [0];
        }



       if(TimeCounter> OpenTime&&TimeCounter<=NatureTime+OpenTime&&point01== true)
        {
         
          rend.material.mainTexture = texturesNature [index];
         point01 = false ;
         Debug.Log(1);
          }
        

        if(TimeCounter>point1&&TimeCounter<=point2&&point12== true) 
        {
         
          rend.material.mainTexture = crossPoint [0];
         
          
             point12 = false ;
        }

       if(TimeCounter>point2&&TimeCounter<=point3&&point23== true )
        {
          
          rend.material.mainTexture = texturesNegative [index];
         
       
             point23 = false ;
        }
       if(TimeCounter>point3&&TimeCounter<=point4&&point34== true)
        {
               
          rend.material.mainTexture = crossPoint [0];
          
         
             point34 = false ;
        }     
       if(TimeCounter>point4&&TimeCounter<=point5&& point45== true )
        {
           
          rend.material.mainTexture = texturesPostive [index];
           point45 = false ;
        }
       
       if(TimeCounter>point5&&TimeCounter<=point6&&point56== true )
        {
                 
          rend.material.mainTexture = crossPoint [0];
          point56 = false ;
        }
        


    }

     void EndOnetrial()
    {
      if (TimeCounter>= OneTrialTime )
      {

      // setPicEachTrial ();
       
       

        
         point01 = true ;
          point12 = true ;
          point23 = true;
         point34 = true ;
        point45 = true ;
         point56 = true ;

         randomRestTime1 =UnityEngine. Random.Range(0.7f,1.5f);
         randomRestTime2 =UnityEngine. Random.Range(0.7f,1.5f);
         randomRestTime3 =UnityEngine. Random.Range(0.7f,1.5f);
        
        
        OneTrialTime = point6;
        Debug.Log(OneTrialTime);
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
