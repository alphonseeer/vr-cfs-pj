using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movea : MonoBehaviour
{
    
   [SerializeField] float moveSpeed = 10f;
    

    // Start is called before the first frame update
    // i am so good !that i study today!
    void Start()
    {
     PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
     MovePlayer();
         
    }

    void PrintInstruction()
    {
         Debug.Log("Welcome to  the gmae");
         Debug.Log("Move your player with WASD or arrow KEYs");
         Debug.Log("Dont`t hit the walls");
    }
    
    void　MovePlayer()
　　{
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed; 
        float ZValue = Input.GetAxis("Vertical") * Time. deltaTime * moveSpeed;

        transform.Translate( xValue,0,ZValue);
    }


}
