using UnityEngine;
using UnityEngine.Playables;

public class Timing_PlayableBehaviour : PlayableBehaviour
{
    public double courtesyTimePerc;
    public bool debug;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        base.ProcessFrame(playable, info, playerData);
        //

        double courtesyTimeDuration = playable.GetDuration() * courtesyTimePerc;
        double centerDuration = playable.GetDuration() / 2;

        double startCurtesyTime = centerDuration - (courtesyTimeDuration / 2);
        double endCurtesyTime = centerDuration + (courtesyTimeDuration / 2);

        ////STATES////
        if (playable.GetTime() < startCurtesyTime)        
        {
            //early
            ProcessFrame_EarlyState(playable, info, playerData);
        }
        else if (playable.GetTime() >= startCurtesyTime && playable.GetTime() <= endCurtesyTime) 
        {
            //perfect
            ProcessFrame_PerfectState(playable, info, playerData);
            //  Debug.Log("process: " + playable.GetTime() + " |  centerDuration: " + centerDuration + " | startCurtesyTime: " + startCurtesyTime);
        }
        else
        {
            //late
            ProcessFrame_LateState(playable, info, playerData);
        }

    }


    public virtual void ProcessFrame_EarlyState(Playable playable, FrameData info, object playerData)
    {
        if (debug) Debug.Log("early"); 
    }
    public virtual void ProcessFrame_PerfectState(Playable playable, FrameData info, object playerData)
    {
        if (debug) Debug.Log("perfect");
    }
    public virtual void ProcessFrame_LateState(Playable playable, FrameData info, object playerData)
    {
        if (debug) Debug.Log("late");
    }

 

 
}
