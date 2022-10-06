using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using System;  
using System.IO;



public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField]public GameObject target; 
    [SerializeField] public float targetTimeIN =  0F;
    [SerializeField] public float targetTime=  0F;

    [SerializeField]public GameObject Screen; 
    [SerializeField] public float ScreenTimeIN =  0F;
    [SerializeField] public float ScreenTime=  0F;

    [SerializeField]public GameObject stimuli; 
    [SerializeField] public float stimuliTimeIN =  0F;
    [SerializeField] public float stimuliTime=  0F;

    
    [SerializeField]public GameObject CFS; 
    [SerializeField] public float CFSTimeIN =  0F;
    [SerializeField] public float CFSTime=  0F;

    [SerializeField]public GameObject NEXT ; 
    [SerializeField] public float   NEXTin =  13F;
    
    [SerializeField]public GameObject colorquestion ;
     [SerializeField] public float colorquestionIN =  7F;
    [SerializeField] public float colorquestionTime=  2F; 

     [SerializeField]public GameObject whatquestion ;
     [SerializeField] public float whatquestionIN =  9F;
    [SerializeField] public float whatquestionTime=  2F; 

    [SerializeField]public GameObject surequestion ;
    [SerializeField] public float surequestionIN =  11F;
    [SerializeField] public float surequestionTime=  2F; 








    [SerializeField] public float   OneTrialTime =  15F;
    [SerializeField] public int trialtime = 2;

    
  
    public Texture[] textures;
    public float changeInterval = 1F;
    [SerializeField] public Renderer rend;

    [SerializeField] public GameObject StimuliPic;


     [SerializeField] public Material[]  randomcolor;
     [SerializeField] public Renderer rendromdancolor1;
      [SerializeField] public Renderer rendromdancolor2;

     [SerializeField] public Material white ;



    int trialtimeNow = 0;
    float TimeCounter =0f;

    int indexcolor;

    float socrer =0;
    float question1CountYes=0 ;
    float question1CountNO =0;
    float question1Countsure=0 ;

    //output data setting 
    List<int> q1 = new List<int>();
    List<int> q2 = new List<int>();
    int[] sampleData ;
    int[] sampleData1  ;
    // CSV namesetting
    [SerializeField]string CSVflieName = "NO.1";

    // get the output function from other script.
    GameObject Savefunction;
    saveCsv saveCsv;


    // Start is called before the first frame update
    void Start()
    {
       //get rend from
      rend = StimuliPic.GetComponent<Renderer>(); 
     // rendromdancolor1 = GetComponent<Renderer>();
       //rendromdancolor2 = GetComponent<Renderer>(); 


     indexcolor = UnityEngine.Random.Range(0,randomcolor.Length);


        Savefunction= GameObject.Find("Savefunction");
        saveCsv = Savefunction.GetComponent<saveCsv>();

    }

    // Update is called once per frame
    void Update()
    {
        
        
//

         
           
           TimeCounter += Time.deltaTime;
           //Debug.Log(TimeCounter);
          targetControl () ;
          screenControl () ;
          CFSControl();
          StimuleControl() ;
          Nextcontrol();
           changecolorBytime();
           colorquestionControl ();
           whatquestionControl ();
           SurequestionControl();
          
          
           //  saveCsv.CSVSave(sampleData,sampleData1,"NO.1");
         
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

    void screenControl ()
    {
      if (TimeCounter >= 1 && TimeCounter<=6 )
      {
        Screen.SetActive(false);
      }
      else
      {
          Screen.SetActive(true);
      }
    }

    void CFSControl ()
    {
        if(TimeCounter>=CFSTimeIN && TimeCounter  <=CFSTimeIN+CFSTime )
        {
          CFS.SetActive(true);
        }
        else
        {
            CFS.SetActive(false);
        }
    }

    void StimuleControl ()
    {
        if(TimeCounter>=stimuliTimeIN && TimeCounter  <=stimuliTime+stimuliTimeIN )
        {
          stimuli.SetActive(true);
        }
        else
        {
            stimuli.SetActive(false);
        }
    }

  float colorquestionControl ()
   {
             if(TimeCounter>=colorquestionIN && TimeCounter  <=colorquestionIN+colorquestionTime )
        {
         colorquestion.SetActive(true);
         colorquestionSystem ();
        }
        else
        {
            colorquestion.SetActive(false);
        }
        return socrer;
   }

     float whatquestionControl ()
   {
             if(TimeCounter>=whatquestionIN && TimeCounter  <=whatquestionIN+whatquestionTime )
        {
         whatquestion.SetActive(true);
          whatquestionSystem ();
        }
        else
        {
            whatquestion.SetActive(false);
        }
        return question1CountYes;
       
   }

        float SurequestionControl ()
   {
             if(TimeCounter>=surequestionIN&& TimeCounter  <=surequestionIN+surequestionTime )
        {
         surequestion.SetActive(true);
          surequestionSystem ();
        }
        else
        {
            surequestion.SetActive(false);
        }
        return question1Countsure;
   }

    void Nextcontrol ()
    { 
       
      if (TimeCounter>= NEXTin)
      {
           NEXT.SetActive(true);

      }
      else
      {
            NEXT.SetActive(false);
      }
    }
    void EndOnetrial()
    {
      if (TimeCounter>= OneTrialTime )
      {

        randomPic();
        indexcolor = UnityEngine.Random.Range(0,randomcolor.Length); 
       
        TimeCounter= 0;
        trialtimeNow++;
        
      }
      if(trialtimeNow>=trialtime)
          
      {
         // out put the score to csv
          Debug.Log(trialtimeNow);
        
          Debug.Log("scorer"+socrer);Debug.Log("what,yes"+question1CountYes);Debug.Log("sure"+question1Countsure);
           printQ1();

           sampleData = q1.ToArray();
           sampleData1 = q2. ToArray();
           

           saveCsv.CSVSave(sampleData,sampleData1,CSVflieName);
           

            //UnityEditor.EditorApplication.isPaused = true;

         // restandnext();
      }

    } 

    void randomPic ()
    {
               int index =UnityEngine. Random.Range(0,textures.Length ); 
         //Debug.Log(index);
         rend.material.mainTexture = textures[index];
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

   void changecolor()
    {
      
     
     rendromdancolor1.material= randomcolor[indexcolor];
     rendromdancolor2.material= randomcolor[indexcolor];

       // setting two white block to romdancolor in the list []

    }

     void changecolorBytime()
     {
       if(TimeCounter>CFSTimeIN+1&&TimeCounter<CFSTimeIN+1+1)
       {
         changecolor();
       }
      else
      
       {
            rendromdancolor1.material= white;
             rendromdancolor2.material= white;
       }
     }
     float colorquestionSystem ()
     {
        
       if (Input.GetKeyDown("left")&&indexcolor==0)
       {
           Debug.Log("red");
           socrer++;
            Debug.Log(socrer);
       } 
      if (Input.GetKeyDown("up")&&indexcolor==1)
       {
           Debug.Log("blue");
           socrer++;
            Debug.Log(socrer);
          
       } 
      // if (Input.GetKeyDown("right")&&indexcolor==2)
      // {
         //  Debug.Log("yellow");
         //  socrer++;
          //  Debug.Log(socrer);
          
      // } //just dont use yellow now
       
       return socrer;

     }

     float whatquestionSystem ()
     {
       
       if (Input.GetKeyDown("left"))
       {
           
          question1CountYes ++;
           q1.Insert(trialtimeNow,1);
       } 

       if (Input.GetKeyDown("right"))
       {
           
          question1CountNO++;
            q1.Insert(trialtimeNow,0);;
       } 
       
      
       return question1CountYes;

     }

      float surequestionSystem ()
     {
        
       if (Input.GetKeyDown("left"))
       {
         
          question1Countsure ++;
          q2.Insert(trialtimeNow,1);
       } 

      if (Input.GetKeyDown("right"))
       {

          question1CountNO++;
           q2.Insert(trialtimeNow,0);;
       } 

       
      
       return question1Countsure;

     }

     void printQ1()
     {
      foreach(int chr in q1)
     {
     
     Debug.Log(trialtimeNow+":"+chr);
     }
     }






}
//this.GetComponent<Text>().text = myList[9 - count].ToString();
// change the text