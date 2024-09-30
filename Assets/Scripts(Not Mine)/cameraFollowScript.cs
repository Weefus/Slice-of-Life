using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRunnerScript : MonoBehaviour
{

    public float interpVelocity;
    public float followConstraint;
    public GameObject target;
    public Vector3 offset;
    //    public float followInfluence;
    Vector3 targetPos;


    // Use this for initialization
    void Start()
    {
        targetPos = transform.position;
        // Camera Constraint.  0 no follow, 5-15, medium follow, 20+ strict follow
        followConstraint = 5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target)
        {
            Vector3 posNoZ = transform.position;
            posNoZ.z = target.transform.position.z;

            Vector3 targetDirection = (target.transform.position - posNoZ);

            interpVelocity = targetDirection.magnitude * followConstraint;

            targetPos = transform.position + (targetDirection.normalized * interpVelocity * Time.deltaTime);

            transform.position = Vector3.Lerp(transform.position, targetPos + offset, 0.8f);



        }
    }
}