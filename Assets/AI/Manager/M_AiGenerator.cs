using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_AiGenerator : Singleton<M_AiGenerator>
{
    [SerializeField] List<A_Agent> aiList = new List<A_Agent>();
    [SerializeField] int agentNumber = 4;
    [SerializeField] A_Agent agent = null;
    [SerializeField] A_Agent agent2 = null;
    [SerializeField] A_Agent agent3 = null;

    public bool IsValidAgent => agent && agent2 && agent3;

    private void Start()
    {
        Create();
    }
 

    public A_Agent Agent => agent;
    public A_Agent Agent2 => agent2;
    public A_Agent Agent3 => agent3;

    public int AgentNumber => agentNumber;

    public List<A_Agent> AiList => AiList;
    void Create()
    {
        if (!IsValidAgent) return;
        for (int i = 0; i < agentNumber; i++)
        {
            int _agentPick = Random.Range(1, 3);
            AgentCreator(_agentPick);
        }
      
    }
    void AgentCreator(int _agentNumber)
    {
        CreateAgent(_agentNumber);
        CreateAgent2(_agentNumber);
        CreateAgent3(_agentNumber);
      

    }
    void CreateAgent(int _numberAgent)
    {
        if (_numberAgent == 1)
        {
            agent3 = Instantiate(agent3, randomPosition(), Quaternion.identity, transform);
            aiList.Add(agent3);
        }
    }
    void CreateAgent2(int _numberAgent)
    {
        if (_numberAgent == 2)
        {
            agent2 = Instantiate(agent2, randomPosition(), Quaternion.identity, transform);
            aiList.Add(agent2);
        }

    }
    void CreateAgent3(int _numberAgent)
    {
        if (_numberAgent == 3)
        {
            agent = Instantiate(agent, randomPosition(), Quaternion.identity, transform);
            aiList.Add(agent);
        }
    }


    public Vector3 randomPosition()
    {
        float _angle = Random.Range(15, 150);

        float _angleZ = Random.Range(15, 150);
        float _x = Mathf.Cos(_angle) * transform.position.x;
        float _y = transform.position.y;
        float _z = Mathf.Sin(_angleZ) * transform.position.z;

        return new Vector3(_x, _y, _z);
    }
}
