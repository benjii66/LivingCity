using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Agent : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float speed = 2;
    [SerializeField] Transform target = null;
    [SerializeField] AT_Task[] tasks = null;
    //[SerializeField] List<A_Task> task = new List<A_Task>();

    public Transform Target => target;

    public void SetTarget(Transform _target) => target = _target;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTo();
    }


    public bool IsAtPos => Vector3.Distance(transform.position, target.position) < 0.1f;

    void MoveTo()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            SetTarget(tasks[i].Target);
            if (tasks[i].IsValidStartHour)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * speed);
                transform.LookAt(target.position);
            }

        }
    }


    private void OnDrawGizmos()
    {
        if (IsAtPos)
        {
            Gizmos.color = Random.ColorHSV();
            Gizmos.DrawSphere(transform.position + (Vector3.up * 2), 0.5f);
        }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + (Vector3.up * 2), 0.5f);
    }



}
