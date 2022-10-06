using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomPic : MonoBehaviour
{
    public Texture[] textures;
    public float changeInterval = 1F;
    public Renderer rend;
   
    float timecounter=0;
    // Start is called before the first frame update
    void Start()
    {
      rend = GetComponent<Renderer>(); 
    }

    // Update is called once per frame
    void Update()
    {
            if (textures.Length == 0)
            return;

        //int index = Mathf.FloorToInt(Time.time / changeInterval );
        //index = index % textures.Length;
       timecounter+= Time.deltaTime;
        if (timecounter> changeInterval)
        {
        int index = Random.Range(0,textures.Length ); 
         Debug.Log(index);
         rend.material.mainTexture = textures[index];
         timecounter =0;

        }
         
        
          
    
 


        

    }
}
