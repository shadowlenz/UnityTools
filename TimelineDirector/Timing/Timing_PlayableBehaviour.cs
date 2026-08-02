using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

public class Timing_PlayableBehaviour : PlayableBehaviour
{
    public double courtesyTimePerc;
    public bool debug;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);

       

        double courtesyTimeDuration = playable.GetDuration() * courtesyTimePerc;
        double centerDuration = playable.GetDuration() / 2;

        double startCurtesyTime = centerDuration - (courtesyTimeDuration / 2);
        double endCurtesyTime = centerDuration + (courtesyTimeDuration / 2);


   

        ////STATES////

        if (playable.GetTime() < startCurtesyTime)        
        {
            //early
            ProcessEarly(playable, info, playerData);
        }
        else if (playable.GetTime() >= startCurtesyTime && playable.GetTime() <= endCurtesyTime) 
        {
            //perfect
            ProcessCourtesyFrames(playable, info, playerData);
            //  Debug.Log("process: " + playable.GetTime() + " |  centerDuration: " + centerDuration + " | startCurtesyTime: " + startCurtesyTime);
        }
        else
        {
            //late
            ProcessLate(playable, info, playerData);
        }


    }


    public virtual void ProcessEarly(Playable playable, FrameData info, object playerData)
    {
  
        if (debug) Debug.Log("early"); 
    }
    public virtual void ProcessCourtesyFrames(Playable playable, FrameData info, object playerData)
    {
        if (debug) Debug.Log("perfect");
    }
    public virtual void ProcessLate(Playable playable, FrameData info, object playerData)
    {
        if (debug) Debug.Log("late");
    }

 

 
}
