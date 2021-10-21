using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    private int attackState;
    private Animator anim;

    private void Awake()
    {
        attackState = Animator.StringToHash("isAttacking");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }

    void Attack()
    {
        if (Input.GetKey(KeyCode.J)||Input.GetMouseButtonDown(0))
        {
            anim.SetBool(attackState, true);
        }
        else
        {
            anim.SetBool(attackState, false);
        }
    }
}
