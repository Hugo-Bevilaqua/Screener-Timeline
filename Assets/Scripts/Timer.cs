using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float clock;
    bool running;
    void Start(){
            clock=0;
            running=false;
        }

    void Update(){ 

        if(running){         
                clock += Time.deltaTime;    
            } 
    }
    public void stopbutton()
    {
        running=false;
    }   
    public void resetbutton()
    {
        running=false;
        clock=0;
    }
    public void startbutton()
    {
    running=true;
    }
    public string retTime(){
        return System.Math.Round(clock, 2).ToString();
    }
}