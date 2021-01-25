using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] Canvas canva = null;
    [SerializeField] TMP_Text hour = null;
    [SerializeField] M_DayTime time = null;




    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("UpdateHour", 5, time.TimeSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHour();
       
    }


    void UpdateHour()
    {
        hour.text = $"Hour : {time.DayHour}";
    }
}
