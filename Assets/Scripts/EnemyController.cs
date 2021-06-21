using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private bool isDamaged;
    public int damagedState;
    Animator anim = new Animator();

    private void Awake()
    {
        damagedState = Animator.StringToHash("isDamaged");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    private void TakeDamage()
    {
        anim.SetBool("isDamaged", true);
        Debug.Log("It hurts!");
        anim.SetBool("isDamaged", false);
    }
}
