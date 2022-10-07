using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSL;

namespace  Assets.LSL4Unity.Scripts.LSLeventTrigger
{
    public class LSLeventTrigger : MonoBehaviour
    {
 
        string StreamName = "LSL4Unity.Samples.SimpleCollisionEvent";
        string StreamType = "Markers";
        private liblsl.StreamOutlet outlet;
         private liblsl.StreamInfo streamInfo;


        private const liblsl.channel_format_t  channelFormat  = liblsl.channel_format_t.cf_string;
        private string[] sample = {""};

        int trialtimeNow ;

        void Start()
        {
            var hash = new Hash128();
            hash.Append(StreamName);
            hash.Append(StreamType);
            hash.Append(gameObject.GetInstanceID());
            liblsl.StreamInfo streamInfo = new liblsl.StreamInfo(StreamName, StreamType, 1,liblsl.IRREGULAR_RATE,
                channelFormat, hash.ToString());
            outlet = new liblsl.StreamOutlet(streamInfo);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (outlet != null)
            {
                sample[0] = "TriggerEnter " + gameObject.GetInstanceID();
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (outlet != null)
            {
                sample[0] = "TriggerExit " + gameObject.GetInstanceID();
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);
            }
        }

        public void outputTrigger()
        {
           
            sample[0] = "trialtimeNow"+trialtimeNow +"Triggerin "+Time.deltaTime + gameObject.GetInstanceID();  //  trial time , scene name , this time.
                // Debug.Log(sample[0]);
                outlet.push_sample(sample);
        }
    }
}
