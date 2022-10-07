using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Assets.LSL4Unity.Scripts;

public class eventcontroler : MonoBehaviour
{
    [SerializeField]public GameObject maru; 
    [SerializeField] public float maruTimeIN =  0F;
    [SerializeField] public float maruTime=  0F;




   //set trial time

    [SerializeField] public float   OneTrialTime =  15F;
    [SerializeField] public int     trialtime = 2;

    //timecounter
    int trialtimeNow = 0;
    float TimeCounter =0f;

    //marker sending
    private LSLMarkerStream marker;


   bool  markerOnce = true ;


    // Start is called before the first frame update
    void Start()
    {
        marker =  FindObjectOfType< LSLMarkerStream>();
    }

    // Update is called once per frame
    void Update()
    {
        TimeCounter += Time.deltaTime;
         maruControl () ;
         sendmaruMaker();
         EndOnetrial();
    }

    void maruControl () 
    {
       
         if(TimeCounter >=maruTimeIN&&TimeCounter <=maruTime+maruTimeIN )
        {
            maru.SetActive(true);
            
        } else 
        {
           maru.SetActive(false);

        }
        
    }

    void sendmaruMaker()
    {
        if(TimeCounter >=maruTimeIN && markerOnce  == true)
        {
         marker.Write("Maru On"+this.name);
         markerOnce = false;
        }
    }
    void EndOnetrial()
    {
      if (TimeCounter>= OneTrialTime )
      {

        
       
       
        TimeCounter= 0;
        markerOnce = true;
        trialtimeNow++;
        
      }

  if(trialtimeNow>=trialtime)
          
      {
         
           

        UnityEditor.EditorApplication.isPaused = true;

        
      }
    }

 }




