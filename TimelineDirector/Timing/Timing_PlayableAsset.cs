
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class Timing_PlayableAsset : PlayableAsset
{

    [Range(0,1)] [SerializeField] double courtesyTimePerc = 0.5f;
    public double GetCourtesyTimePerc() => courtesyTimePerc;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Timing_PlayableBehaviour>.Create(graph);

        var behaviour = playable.GetBehaviour();
        behaviour.courtesyTimePerc = GetCourtesyTimePerc();


        return playable;
    }
}
