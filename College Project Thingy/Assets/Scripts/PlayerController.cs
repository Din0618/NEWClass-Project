using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float movespeed;
    public float rotationspeed =75f;
    public float jumpforce;
    public Rigidbody rig;
    public int coinCount;
    public int health;

    public Animator anim; 
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

        if(Mathf.Abs(x) > 0.1f || Mathf.Abs(z) > 0.1f)
        {
            anim.SetBool("isRunning", true); 
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        
    }

    void TryJump()
    {
       // create a ray facing down 
       Ray ray = new Ray(transform.position, Vector3.down);

       //shoot the raycast 
       if (Physics.Raycast(ray, 1.5f)) { 
            anim.SetTrigger("isJumping");
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
        if(health <= 0)
        {
            anim.SetBool("die", true);
            StartCoroutine("Die");
        }

    }
    IEnumerator DieButCool()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
    }
    
        void OnTriggerEnter(Collider other)   
        {
            if(other.gameObject.name == "Enemy")
            {
                health -= 5;
            }
            
            if(other.gameObject.name == "FallCollider")
            {
                SceneManager.LoadScene(0);
            }
       }

   
    
    
    
    
    
    

}
