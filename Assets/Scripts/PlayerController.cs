using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed = 5.0f;
    public float walkSpeed = 2.0f;
    public float hp = 100.0f;
    private float h;
    private float v;
    //private GameObject go;
    private Rigidbody rb;
    private Animator anim;
    private int walkState;
    private int runState;
    private int attackState;

    public List<GameObject> weaponsList;
    public Transform playerRightHand;
    private GameObject weapon = new GameObject();

    private AudioSource runAudio;

    private Collider weaponCollider;

    private void Awake()
    {
        walkState = Animator.StringToHash("isWalking");
        runState = Animator.StringToHash("isRunning");
        attackState = Animator.StringToHash("isAttacking");
    }
    // Start is called before the first frame update
    void Start()
    {
        //go = GetComponent<GameObject>();
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        
        weapon = Instantiate(weaponsList[0]);
        weapon.transform.parent = playerRightHand;
        weapon.transform.localPosition = new Vector3(0.01f, 0.16f, 0);
        weapon.transform.rotation = Quaternion.Euler(0, 0, 40);
        weaponCollider = weapon.GetComponent<CapsuleCollider>();
        weaponCollider.enabled = false;

        runAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))//攻撃モーション中に移動不可
        {
            Move();
        }
        AnimationController();
        Attack();
    }


    void Move()
    {
        Vector3 lookPosition = new Vector3(h, 0, v);
        if(Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += transform.forward * runSpeed * Time.deltaTime;
                if(!runAudio.isPlaying)
                {
                    runAudio.Play();
                }
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += (-1) * transform.forward * runSpeed * Time.deltaTime;
                if (!runAudio.isPlaying)
                {
                    runAudio.Play();
                }
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += (-1)* transform.right * runSpeed * Time.deltaTime;
                if (!runAudio.isPlaying)
                {
                    runAudio.Play();
                }
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += transform.right * runSpeed * Time.deltaTime;
                if (!runAudio.isPlaying)
                {
                    runAudio.Play();
                }
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += transform.forward * walkSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += (-1) * transform.forward * walkSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += Vector3.left * walkSpeed * Time.deltaTime;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.position += Vector3.right * walkSpeed * Time.deltaTime;
            }
        }

    }
    void Attack()
    {
        if (Input.GetKey(KeyCode.J))
        {
            anim.SetBool(attackState, true);
        }
        else
        {
            anim.SetBool(attackState, false);
        }
    }

    void AnimationController()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool(runState, true);
                anim.SetBool(walkState, false);
            }
            else
            {
                anim.SetBool(runState, false);
                anim.SetBool(walkState, false);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
            {
                anim.SetBool(walkState, true);
                anim.SetBool(runState, false);
            }
            else
            {
                anim.SetBool(walkState, false);
                anim.SetBool(runState, false);
            }

        }
    }
    void DisableWeaponCollider()
    {
        weaponCollider.enabled = false;
    }

    void EnableWeaponCollider()
    {
        weaponCollider.enabled = true;
    }
}
