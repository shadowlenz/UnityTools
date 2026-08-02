using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Timeline;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

[CanEditMultipleObjects]
[CustomTimelineEditor(typeof(Timing_PlayableAsset))]
public class Timing_PlayableAsset_Editor : ClipEditor
{
    /*
    public override ClipDrawOptions GetClipOptions(TimelineClip clip)
    {
        var clipOptions = base.GetClipOptions(clip);
        clipOptions.highlightColor = Color.red;
        return clipOptions;
    }
    */

    
    public override void DrawBackground(TimelineClip clip, ClipBackgroundRegion region)
    {
        base.DrawBackground(clip, region);

        Timing_PlayableAsset myTarget = (Timing_PlayableAsset)clip.asset;
        var courtesyTimePerc = myTarget.GetCourtesyTimePerc();
        var blendDuration = (clip.duration - (courtesyTimePerc * clip.duration)) / 2;

        clip.easeInDuration = blendDuration;
        clip.easeOutDuration = blendDuration;

    }


}
