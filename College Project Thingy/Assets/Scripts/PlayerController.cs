using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movespeed;
    public float rotationspeed =75f;
    public float jumpforce;
    public Rigidbody rig;
    public int coinCount;
    public int health;
    void Movement()
    { 
        // get the input axis 
        float x = Input.GetAxis ("Horizontal");

        float z = Input.GetAxis ("Vertical");

        Vector3 rotation = Vector3.up * x;

        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        Vector3 dir = (transform.forward * z + transform.right * x) * movespeed; 

        dir.y = rig.velocity.y;

    
        //Calculate a direction relative to where we are facing     
        //set that velocity 
        rig.velocity = dir;

        
    }

    void TryJump()
    {
       // create a ray facing down 
       Ray ray = new Ray(transform.position, Vector3.down);

       //shoot the raycast 
       if (Physics.Raycast(ray, 1.5f)) { 
              rig.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
       }
    }

     //Update is called once per frame 

     void Update() 
    {

        //Imput for movement
        Movement(); 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TryJump();
        }
    }
    
        

   
    
    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
}
