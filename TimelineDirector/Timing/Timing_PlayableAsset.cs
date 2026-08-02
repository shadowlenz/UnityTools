using UnityEngine;
using UnityEngine.Playables;

public class Timing_PlayableAsset : PlayableAsset
{
    //courtesyTime
    [Range(0,1)] [SerializeField]  double courtesyTimePerc = 0.5f;
    public double GetCourtesyTimePerc() => courtesyTimePerc;
    //debug
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
