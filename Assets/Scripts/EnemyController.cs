using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private bool isDamaged;
    public int damagedState;
    public int deadState;
    public int hp = 100;
    Animator anim = new Animator();

    private void Awake()
    {
        damagedState = Animator.StringToHash("isDamaged");
        deadState = Animator.StringToHash("isDead");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("TakeDamage"))
        {
            anim.SetBool(damagedState, false);
        }
        if(hp<=0)
        {
            Dead();
        }
    }

    private void TakeDamage()
    {
        anim.SetBool(damagedState, true);
        Debug.Log("It hurts!");
        hp -= 25;

    }
    private void Dead()
    {
        anim.SetBool(deadState, true);


    }
}
