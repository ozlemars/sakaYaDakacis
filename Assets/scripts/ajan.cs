using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class ajan : Agent
{
    private Rigidbody rb;
    private Animator animator;
    public Transform hedef;
    public float carpan = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public override void OnEpisodeBegin()
    {
        // Reset agent's position to a random location
        transform.localPosition = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(hedef.localPosition);
        sensor.AddObservation(transform.localPosition);

        sensor.AddObservation(rb.velocity.x);
        sensor.AddObservation(rb.velocity.z);
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        Vector3 kontrolSinyali = Vector3.zero;
        kontrolSinyali.x = actions.ContinuousActions[0];
        kontrolSinyali.z = actions.ContinuousActions[1];

        // Apply force continuously in FixedUpdate
        rb.AddForce(kontrolSinyali * carpan);

        // Calculate distance to target
        float hedefeOlanFark = Vector3.Distance(transform.localPosition, hedef.localPosition);

        // Reward for reaching the target
        if (hedefeOlanFark < 1.5f)
        {
            SetReward(1.0f);
            EndEpisode();
        }

        // Penalty for falling off the platform
        if (transform.localPosition.y < 0f)
        {
            SetReward(-1.0f);
            EndEpisode();
        }

        // Reward for moving towards the target
        AddReward(0.01f * hedefeOlanFark);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continousActionsOut = actionsOut.ContinuousActions;
        continousActionsOut[0] = Input.GetAxis("Horizontal");
        continousActionsOut[1] = Input.GetAxis("Vertical");
    }
}
