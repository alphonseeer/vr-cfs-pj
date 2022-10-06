using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class spinTarget : MonoBehaviour
{
   [SerializeField] Vector3 Center = Vector3.zero;
   [SerializeField]  Vector3 Axis  = Vector3.up ;
   [SerializeField] float Period = 2f;
   float timecounter = 0f;
   
    // Start is called before the first frame update
    void Start()
    {

     


    }

    // Update is called once per frame
    void Update()
    {
        timecounter += Time.deltaTime;
     transform.RotateAround(Center,Axis,360/Period*Time.deltaTime);
      

    }



}
