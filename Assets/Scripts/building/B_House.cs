using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class B_House : B_Building, IBuilding
{
    [SerializeField] A_Agent agent = null;


    public bool IsValid => agent;

    public A_Agent Agent => agent;



    public void AsTarget()
    {
        agent.SetTarget(transform);
    }



    // Start is called before the first frame update
    void Start()
    {
        AsTarget();
    }

}
