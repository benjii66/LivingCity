using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_Building : MonoBehaviour
{
    [SerializeField] int openHour = 4;
    [SerializeField] int closeHour = 4;
    [SerializeField] M_DayTime dayTime = null;
    [SerializeField] bool isOpen = false;
    [SerializeField] Color buildingColor = Color.white;
    [SerializeField] Collider buildingCollider = null;
    [SerializeField] Locations loc = Locations.office;

    public enum Locations
    {
        office,
        house,
        gasoil
    }
    public Color BuildingColor => buildingColor;

    public Locations Loc => loc;

    public int OpenHour => openHour;
    public int CloseHour => closeHour;

    public bool IsOpen => isOpen;

    public void SetColorOffice(Color _color) => buildingColor = _color;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        OpenClose();
    }
    void OpenClose()
    {
        if (openHour == dayTime.DayHour)
        {
            isOpen = true;
        }
        if (closeHour == dayTime.DayHour && closeHour != openHour)
        {
            isOpen = false;
        }
    }
   

    private void OnDrawGizmos()
    {
  


        Gizmos.color = buildingColor;
        Gizmos.DrawWireCube(buildingCollider.bounds.center, buildingCollider.bounds.size);

        if (IsOpen)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(transform.position + (Vector3.up * 45), 2);
        }
        if (!IsOpen)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + (Vector3.up * 45), 2);
        }
    }

}
