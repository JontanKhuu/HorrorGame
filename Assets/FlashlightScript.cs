using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System.Threading.Tasks;
using Unity.IO.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlashlightScript : MonoBehaviour
{   
    Light m_light;
    public bool batteryDrainOn;
    public GameObject lightCone;
  //  public AudioSource clickSFX;
    public float minBrightness;
    public float maxBrightness;
    public float batteryDrain;

    void Start(){
        m_light = GetComponent<Light>();
        m_light.enabled = !m_light.enabled;
    }
    void Update()
    {   
        m_light.intensity = Mathf.Clamp(m_light.intensity,minBrightness,maxBrightness);
        if(m_light.enabled == true && batteryDrainOn == true){
            m_light.intensity -= Time.deltaTime * (batteryDrain/1000);
        }
    }

    public void flashlightOn(InputAction.CallbackContext context){
        m_light.enabled = !m_light.enabled;
    }
    public void replaceBattery(float amount){
        m_light.intensity += amount;
    }
}
