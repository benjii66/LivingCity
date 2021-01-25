using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Buildings_Manager : MonoBehaviour
{
    [SerializeField] List<B_Building> buildingList = new List<B_Building>();
    [SerializeField] Color officeColor = Color.red;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AttachColor();
    }


    void AttachColor()
    {
        for (int i = 0; i < buildingList.Count; i++)
        {
            buildingList[i].SetColor(officeColor);
        }
    }
}
