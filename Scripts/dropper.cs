using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dropper : MonoBehaviour
{
   MeshRenderer renderer;
   Rigidbody DropRigidbody;
   [SerializeField] float timetowait = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
       renderer = GetComponent<MeshRenderer>();
        DropRigidbody = GetComponent<Rigidbody>();

        renderer.enabled= false;
        DropRigidbody.useGravity = false;
      
       
    }

    // Update is called once per frame
    void Update()
    {
       if (Time.time>timetowait)
       {
          renderer.enabled= true;
          DropRigidbody.useGravity = true;
         
       }
    }
}
