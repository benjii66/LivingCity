using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A_Agent : MonoBehaviour
{
    [SerializeField, Range(0, 10)] float speed = 2;
    [SerializeField] Transform target = null;
    [SerializeField] AT_Task[] tasks = null;
    [SerializeField] bool gotTarget = false;


    public Transform Target => target;

    public Transform otherTarget = null;
    public void SetTarget(Transform _target) => target = _target;

    public bool IsValid => target;


    void Update() => MoveTo();

    public bool GotTarget => gotTarget;

    void MoveTo()
    {
        if (!IsValid) return;
        for (int i = 0; i < tasks.Length; i++)
        {
            SetTarget(tasks[i].Target);
            if (tasks[i].IsValidStartHour)
            {
                gotTarget = true;
                transform.position = Vector3.MoveTowards(transform.position, target.position + Vector3.forward, Time.deltaTime * speed);
                transform.LookAt(target.position);
                otherTarget = tasks[i].Target;
            }
        }
    }


    private void OnDrawGizmos()
    {
        DrawTarget(IsValid, Color.green, 4);
        DrawTarget(gotTarget, Color.cyan, 2);
    }

    void DrawTarget(bool _status, Color _color, int _multiplicator)
    {
        if (_status)
        {
            Gizmos.color = _color;
            Gizmos.DrawSphere(transform.position + (Vector3.up * _multiplicator), 0.5f);
        }
        else
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + (Vector3.up * _multiplicator), 0.5f);
        }
    }


}
