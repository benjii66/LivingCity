using System.Collections;
using UnityEngine;

public class AT_Task : MonoBehaviour
{
    [SerializeField] int startHour = 2;
    [SerializeField] int endHour = 2;
    [SerializeField] Transform target = null;
    [SerializeField] M_DayTime time = null;


    public Transform Target => target;

    public int StartHour => startHour;
    public int EndHour => endHour;
    public bool IsValidStartHour = false;
    public bool IsValidEndHour = false;
    public bool IsValid => target;

    private void Start()
    {
        ResetValidationHours();
    }


    void ResetValidationHours()
    {
        IsValidStartHour = false;
        IsValidEndHour = false;
    }

    private void Update()=>TestOpen();

    void TestOpen()
    {
        if (startHour == time.DayHour)
            IsValidStartHour = true;

        if (endHour == time.DayHour)
        {
            IsValidEndHour = true;
            IsValidStartHour = false;
        }
    }

  
}
