using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GirlAnimation : MonoBehaviour
{
    [Inject] Player player;
    private Animator animator;
    private Rigidbody2D rb;

    private void Start() {
        animator = player.GetComponent<Animator>();
        rb = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0)
        {
            animator.Play("run");
        }
        else
        {
            animator.Play("stay");
        }
    }
}
