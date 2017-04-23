using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimeManager : MonoBehaviour {

    Light lt;

    public float StartTime;

    //LengthOfDay is set in seconds
    public float LengthOfDay;
    public float TimeScale;
    private float _currentTime;
    public float CurrentTime;
    private bool _switchCycle = false;
    public bool IsDayime;

    public Color MaxDaylight;
    public Color MinDaylight;
    private Color _maxDaylight;
    private Color _minDaylight;
    public float IntensityMult;

    public float MinTimeStart;
    public float MaxTimeStart;

    private bool nextFrame = true;

    //For other scripts to reference game time
    public static GameTimeManager GameTime;
    public GameTimeManager()
    {
        GameTime = this;

    }

	void Start ()
    {
        lt = this.GetComponent<Light>();

        _maxDaylight = MaxDaylight;
        _minDaylight = MinDaylight;

        _currentTime = StartTime;

    }

    void Update ()
    {
        if (nextFrame)
            NextFrame();

        //updates CurrentTime and IsDaytime
        CurrentTime = _currentTime;
        IsDayime = _switchCycle;

    }

    void NextFrame()
    {
        nextFrame = false;

        //increase current time
        _currentTime++;
        if (_currentTime >= LengthOfDay)
            _currentTime = 0;

        //if before morning or after evening, intesity is 0
        if ((_currentTime / LengthOfDay) < MinTimeStart || (_currentTime / LengthOfDay) > MaxTimeStart)
        {
            lt.intensity = 0;
            lt.color = _minDaylight;

        }
        else
        {
            //changes intensity scaled to current time over the length of a day
            float tempNum = ((_currentTime / LengthOfDay) - MinTimeStart) / (MaxTimeStart - MinTimeStart);
            float fadeNum = 2f;
            if (!_switchCycle)
                lt.intensity = Mathf.Clamp01(Mathf.Sqrt(tempNum * 2) * fadeNum) * IntensityMult;
            else lt.intensity = Mathf.Clamp01((Mathf.Sqrt((1 - tempNum) * 2)) * fadeNum) * IntensityMult;

            //changes the lighting according to current time
            Color tempColor;
            if (!_switchCycle)
                tempColor = new Color(_minDaylight.r + ((_maxDaylight.r - _minDaylight.r) * tempNum * 2),
                                      _minDaylight.g + ((_maxDaylight.g - _minDaylight.g) * tempNum * 2),
                                      _minDaylight.b + ((_maxDaylight.b - _minDaylight.b) * tempNum * 2),
                                      _maxDaylight.a);
            else
                tempColor = new Color(_minDaylight.r + ((_maxDaylight.r - _minDaylight.r) * (1 - tempNum) * 2),
                                      _minDaylight.g + ((_maxDaylight.g - _minDaylight.g) * (1 - tempNum) * 2),
                                      _minDaylight.b + ((_maxDaylight.b - _minDaylight.b) * (1 - tempNum) * 2),
                                      _maxDaylight.a);

            lt.color = tempColor;

        }

        //Checks if current time is over half the length of a day, is so switch cycles
        if (_currentTime >= LengthOfDay / 2)
            _switchCycle = true;
        else _switchCycle = false;

        //Starts timed scaled counter
        StartCoroutine(CountDown());

    }

    IEnumerator CountDown()
    {
        //Waits for time scaled 1 second before finishing the coroutine
        yield return new WaitForSeconds(TimeScale);
        nextFrame = true;

    }

}
