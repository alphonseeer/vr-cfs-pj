using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

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



   bool  markerOnce = true ;

           [SerializeField]   string StreamName = "LSL4Unity.Samples.SimpleCollisionEvent";
           [SerializeField]  string StreamType = "Markers";
        private StreamOutlet outlet;
        private string[] sample = {""};


    // Start is called before the first frame update
    void Start()
    {
                   var hash = new Hash128();
            hash.Append(StreamName);
            hash.Append(StreamType);
            hash.Append(gameObject.GetInstanceID());
            StreamInfo streamInfo = new StreamInfo(StreamName, StreamType, 1, LSL.LSL.IRREGULAR_RATE,
                channel_format_t.cf_string, hash.ToString());
            outlet = new StreamOutlet(streamInfo);
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
         //marker.Write("Maru On"+this.name);
        
       outputTrigger();
       markerOnce = false;
       Debug.Log( 1);
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
     public void outputTrigger()
        {
           
            sample[0] = "trialtimeNow"+trialtimeNow +"Triggerin "+Time.deltaTime + gameObject.GetInstanceID();  //  trial time , scene name , this time.
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);
        }

 }
