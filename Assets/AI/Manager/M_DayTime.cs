using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_DayTime : Singleton<M_DayTime>
{
    [SerializeField, Range(0, 10)] float timeSpeed = 2;
    [SerializeField] int dayHour = 0;
    [SerializeField] Light sun = null;
    [SerializeField, Range(0, 1)] float currentTimeOfDay = 0;
    float secondsInFullDay = 120f;

    int maxHour = 24;
    public bool IsNoon => dayHour == 12;

    public int DayHour => dayHour;

    public float TimeSpeed => timeSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InitHour", 5, timeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        InitSun();
    }

    void InitHour()
    {
        if (dayHour < maxHour)
            dayHour++;
    }

    void InitSun()
    {
        currentTimeOfDay += (Time.deltaTime / secondsInFullDay) * timeSpeed;
        sun.transform.localRotation = Quaternion.Euler((currentTimeOfDay * 360f) - 90, 170, 0);
        float _intensityMultiplier = 1;
        if (dayHour <= 4)
            _intensityMultiplier = 0;
        else if (dayHour <= 7)
            _intensityMultiplier = 0.0002f;
        else if (dayHour >= 7 && dayHour <= 10)
            _intensityMultiplier = 0.0008f;
        else if (dayHour >= 10 && dayHour <= 17)
            _intensityMultiplier = 0.0006f;
        else if (dayHour >= 17)
            _intensityMultiplier = -0.0008f;
        else if (dayHour >= 21)
            _intensityMultiplier = -0.00015f;

        sun.intensity += _intensityMultiplier;
        if (dayHour == maxHour)
        {
            sun.transform.localRotation = Quaternion.Euler((float)-86.633, -190, 0);
            dayHour = 0;
            _intensityMultiplier = 1;
            sun.intensity = 1;
        }
    }



}
