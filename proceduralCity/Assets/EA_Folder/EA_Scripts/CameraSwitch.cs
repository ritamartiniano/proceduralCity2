using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Camera mainCamera;
    public Camera fpsCamera;
    public  GameObject walkingCamera;
    public  GameObject thirdPCamera;
    public GameObject movableObject; 
    
     void Start()
    {
        mainCamera.enabled = true;
        fpsCamera.enabled = false;
        walkingCamera.SetActive(false);
        thirdPCamera.SetActive(true);
        movableObject.SetActive(true);
    }
     void Update()
    {
        if (Input.GetKeyDown(KeyCode.V) && (mainCamera.enabled == true))
        {
            mainCamera.enabled = false;
            fpsCamera.enabled = true;
            walkingCamera.SetActive(true);
            thirdPCamera.SetActive(false);
            movableObject.SetActive(false);


        }
     
        else if (Input.GetKeyDown(KeyCode.V) && (fpsCamera.enabled == true))
        {
            mainCamera.enabled = true;
            fpsCamera.enabled = false;
            walkingCamera.SetActive(false);
            thirdPCamera.SetActive(true);
            movableObject.SetActive(true);


        }
    }
}