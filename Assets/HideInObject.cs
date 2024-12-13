using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class HideInObject : MonoBehaviour
{   
    public GameObject player;
    public GameObject Main_Camera;
    public GameObject Camera_2;
    public int Manager;

    [SerializeField] private bool triggerActive = false;

    public void ChangeCamera(){
        GetComponent<Animator>().SetTrigger("Change");
    }
    public void ManageCamera(){
        if (Manager == 0){
            Cam_2();
            Manager = 1;
        }   
        else {
            Cam_1();
            Manager = 0;
        }
    }
    void Cam_1(){
        Main_Camera.SetActive(true);
        Camera_2.SetActive(false);
        player.SetActive(true);
    }

    void Cam_2(){
        Main_Camera.SetActive(false);
        Camera_2.SetActive(true);
        player.SetActive(false);
    }

    public void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            triggerActive = true;
            print("Player Entered");
        }
    }

    public void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            triggerActive = false;
            print("Player Left");
        }
    }

    private void Update(){
        if (triggerActive && Input.GetKeyDown(KeyCode.Space)){
            ManageCamera();
        }
    }

}
