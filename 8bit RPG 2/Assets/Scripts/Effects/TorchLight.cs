using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour {

    Light lt;

    public float MaxIntensity;
    public float MinIntensity;

    void Start ()
    {
        lt = this.GetComponent<Light>();
        lt.intensity = MinIntensity;

    }

    void Update ()
    {
        var gt = GameTimeManager.GameTime;

        //fades light which is scaled about game time
        if ((gt.CurrentTime / gt.LengthOfDay) < gt.MinTimeStart || (gt.CurrentTime / gt.LengthOfDay) > gt.MaxTimeStart)
        {
            lt.intensity = MaxIntensity;

        }
        else
        {
            //changes intensity scaled to current time over the length of a day
            float tempNum = ((gt.CurrentTime / gt.LengthOfDay) - gt.MinTimeStart) / (gt.MaxTimeStart - gt.MinTimeStart);
            float fadeNum = 2f;
            if (!gt.IsDayime)
                lt.intensity = Mathf.Clamp(MaxIntensity - Mathf.Clamp01(Mathf.Sqrt(tempNum * 2) * fadeNum) * MaxIntensity, MinIntensity, MaxIntensity);
            else lt.intensity = Mathf.Clamp(MaxIntensity - Mathf.Clamp01((Mathf.Sqrt((1 - tempNum) * 2)) * fadeNum) * MaxIntensity, MinIntensity, MaxIntensity);
            /*if (!gt.IsDayime)
                lt.intensity = MaxIntensity - (Mathf.Lerp(MinIntensity, MaxIntensity, tempNum) * 2);
            else lt.intensity = MaxIntensity - (Mathf.Lerp(MaxIntensity, MinIntensity, tempNum) * 2);*/
            //lt.intensity = MaxIntensity - ((((Mathf.Cos(Mathf.PI * tempNum * 2) * -1) + 1) / 2) * MaxIntensity);

        }

    }

}

