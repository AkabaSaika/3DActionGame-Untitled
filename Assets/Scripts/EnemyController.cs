using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private bool isDamaged;
    public int damagedState;
    public int deadState;
    private int walkState;
    public float hp = 100f;
    Animator anim = new Animator();
    private Transform player;
    private const float MAX_VISION_DISTANCE = 10;
    [SerializeField] private float attackDistance = 1;
    [SerializeField] private float moveSpeed = 2f;

    private void Awake()
    {
        walkState = Animator.StringToHash("isWalking");
        damagedState = Animator.StringToHash("isDamaged");
        deadState = Animator.StringToHash("isDead");
    }
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
        DetectPlayer();
        
    }

    private void TakeDamage(float damage)
    {
        anim.SetBool(damagedState, true);
        Debug.Log("It hurts!");
        hp -= damage;

    }
    private void Dead()
    {
        anim.SetBool(deadState, true);
    }

    private void DetectPlayer()
    {
        if((transform.position-player.position).magnitude<=MAX_VISION_DISTANCE)
        {
            float angleBetweenPlayerAndEnemy = Vector3.Angle(transform.forward, player.position - transform.position);
            if(angleBetweenPlayerAndEnemy <= 30 && angleBetweenPlayerAndEnemy >= 0)
            {
                //Debug.Log("I seen you");
                Ray ray = new Ray(transform.position, player.position - transform.position);
                Debug.DrawLine(transform.position, player.position - transform.position,Color.red);
                RaycastHit hitInfo;
                if(Physics.Raycast(ray,out hitInfo))
                {
                    if(hitInfo.collider.gameObject.tag=="Player")
                    {
                        transform.LookAt(player);
                        //transform.Translate(transform.forward*moveSpeed*Time.deltaTime);
                    }
                }
            }

        }
    }
}
