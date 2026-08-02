
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;


public class Timing_PlayableAsset : PlayableAsset
{

    [Range(0,1)] [SerializeField]  double courtesyTimePerc = 0.5f;
    public double GetCourtesyTimePerc() => courtesyTimePerc;

    [SerializeField]  bool debug;
    public bool IsDebug() => debug && Application.isEditor;

    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<Timing_PlayableBehaviour>.Create(graph);
       

        var behaviour = playable.GetBehaviour();
        behaviour.courtesyTimePerc = GetCourtesyTimePerc();
        behaviour.debug = IsDebug();

        return playable;
    }
}
