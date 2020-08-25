using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
//https://www.youtube.com/watch?v=COckHIIO8vk&list=PLPV2KyIb3jR4KLGCCAciWQ5qHudKtYeP7&index=4

public class CharacterAnimator : MonoBehaviour
{
    const float locomotionAnimationSmoothTime = 0.1f;
    NavMeshAgent agent;
    Animator animator;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomotionAnimationSmoothTime, Time.deltaTime);
        //Last variable is damptime, taking a tenth of a second to smooth between values
    }
}
