using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Buildings_Manager : Singleton<M_Buildings_Manager>
{
    [SerializeField] List<B_Office> officeList = new List<B_Office>();
    [SerializeField] List<B_Gasoil> gasoilList = new List<B_Gasoil>();
    [SerializeField] List<B_House> houseList = new List<B_House>();
    [SerializeField] Color officeColor = Color.red;
    [SerializeField] Color gasoilColor = Color.cyan;
    [SerializeField] Color houseColor = Color.green;


    private void Update()
    {
        BuildingsColor();
    }

    void BuildingsColor()
    {
        OfficeColor();
        GasolColor();
        HouseColor();
    }

    void OfficeColor()
    {
        for (int i = 0; i < officeList.Count; i++)
            officeList[i].SetColorOffice(officeColor);
    }
    void GasolColor()
    {
        for (int i = 0; i < gasoilList.Count; i++)
            gasoilList[i].SetColorOffice(gasoilColor);
    }
    void HouseColor()
    {
        for (int i = 0; i < houseList.Count; i++)
            houseList[i].SetColorOffice(houseColor);
    }

}
