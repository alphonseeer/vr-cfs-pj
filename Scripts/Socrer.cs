using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socrer : MonoBehaviour
{
    int hits = 0;
   private void OnCollisionEnter(Collision other)
    { 
       if (other.gameObject.tag  != "Hits")
       {
           
      
        hits ++;
       Debug.Log("you`ve bumped into a thing this many times :"+hits);
       } 
   }
}
