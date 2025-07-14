using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Refrences")]
    public Transform orientation;
    public Transform player;
    public Transform playerObj;

    public float rotationSpeed; 

    // Start is called before the first frame update
    void Start()
    {
      Cursor.lockState = CursorLockMode.Locked; 
      Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 viewDR = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z); 
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical"); 
        Vector3 inputDIR = orientation.forward * verticalInput + orientation.right * horizontalInput; 

        if(inputDIR != Vector3.zero) 
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDIR.normalized, Time.deltaTime * rotationSpeed); 
        }
    }
}
