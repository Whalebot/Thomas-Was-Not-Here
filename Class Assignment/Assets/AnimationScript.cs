using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour
{
    Movement playerMov;
    Animator anim;

    // Use this for initialization
    void Start()
    {
        playerMov = GetComponentInParent<Movement>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Descending") || anim.GetCurrentAnimatorStateInfo(0).IsName("Landing")) anim.SetBool("FromAir", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Descending") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Landing"))
            anim.SetBool("FromAir", false);

        if (playerMov.inputDirection.x != 0) anim.SetBool("Walking", true);
        else anim.SetBool("Walking", false);

        anim.SetBool("Running", playerMov.sprinting);

        //if (playerStatus.state == PlayerStatus.State.Hitstun) anim.SetBool("Hitstun", true);
        //else anim.SetBool("Hitstun", false);

        //if (playerMov.isDashing) anim.SetBool("Dashing", true);
        //else { anim.SetBool("Dashing", false); }


        //if (playerMov.isBackdashing) anim.SetBool("Backdashing", true);
        //else { anim.SetBool("Backdashing", false); }
        //if (playerMov.newDash) { DashClick(); }

        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dash") || anim.GetCurrentAnimatorStateInfo(0).IsName("Backdash")) { anim.SetBool("FromDash", true); }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Dash") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Backdash"))
            anim.SetBool("FromDash", false);


        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Run")) { anim.SetBool("FromRun", true); }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Run") && !anim.GetCurrentAnimatorStateInfo(0).IsName("RunStop"))
            anim.SetBool("FromRun", false);

        //anim.SetInteger("AttackID", player_AttackScript.attackID);

        if (playerMov.rb.velocity.y < 0) anim.SetInteger("Ascending", -1);
        else if (playerMov.rb.velocity.y > 1)
            anim.SetInteger("Ascending", 1);
        else anim.SetInteger("Ascending", 0);

        if (playerMov.isGrounded) anim.SetBool("Grounded", true);
        else anim.SetBool("Grounded", false);

        //if (player_AttackScript.startup) { anim.SetBool("Startup", true); }
        //else anim.SetBool("Startup", false);

        //if (player_AttackScript.active) anim.SetBool("Active", true);
        //else anim.SetBool("Active", false);

        //if (player_AttackScript.recovery) anim.SetBool("Recovery", true);
        //else anim.SetBool("Recovery", false);


        //if (!player_AttackScript.startup && !player_AttackScript.active) anim.SetBool("Attacking", false);
        //else anim.SetBool("Attacking", true);

    }
}
