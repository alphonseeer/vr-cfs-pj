using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CfsAnime : MonoBehaviour
{

    public Material[] material; 
    public int x ;
    Renderer rend;
    float TimeCounter = 0f ;
    [SerializeField]float Hz = 0f;
    [SerializeField]int size = 0 ;



     

    // Start is called before the first frame update
    void Start()
    {
        x=0;
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = material[x];
    }

    // Update is called once per frame
    void Update()
    {
        
        TimeCounter += Time.deltaTime;
        //Debug.Log(TimeCounter); 
      
        if (TimeCounter >= Hz)
        {

        
        if(x<size-1 )
        {
            
            x++;  
            transform. GetComponent<Renderer>().sharedMaterial = material[x];
           
        }
        else
        {
            x=0;
             transform. GetComponent<Renderer>().sharedMaterial = material[x];
        }
          TimeCounter = 0;
        }
         
       
    }

    
}
