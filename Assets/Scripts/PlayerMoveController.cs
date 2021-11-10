using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField]
    private float mRunSpeed = 5.0f;
    [SerializeField]
    private float mWalkSpeed = 2.0f;
    private float h;
    private float v;
    private Rigidbody rb;
    private Transform mTransform;
    private Camera mainCam;
    private Vector3 lookPosition;
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        mainCam = Camera.main;
        rb = GetComponent<Rigidbody>();
        mTransform = this.transform;
    }

    void Update()
    {
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))//攻撃モーション中に移動不可
        {
        Move();
        PlayerRotate();
        }
        //Debug.Log(transform.rotation.eulerAngles);
    }
    void Move()
    {
        PlayerAnimationController._instance.SetWalkState(false);
        PlayerAnimationController._instance.SetRunState(false);
        lookPosition = Vector3.Normalize(Vector3.ProjectOnPlane(mainCam.transform.position, Vector3.up));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime,Space.World);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, mainCam.transform.eulerAngles.y, transform.rotation.z));
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetRunState(true);

            }
        }
        else
        {
            if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, mainCam.transform.eulerAngles.y, transform.rotation.z));
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.S))
            {             
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                
                transform.Translate(transform.forward * mRunSpeed * Time.deltaTime, Space.World);
                PlayerAnimationController._instance.SetWalkState(true);
            }
        }
    }
    private void PlayerRotate()
    {
        if((Input.GetKeyDown(KeyCode.W)&&Input.GetKeyDown(KeyCode.A))||(Input.GetKeyDown(KeyCode.W)&&Input.GetKey(KeyCode.A))||(Input.GetKey(KeyCode.W)&&Input.GetKeyDown(KeyCode.A)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0,mainCam.transform.eulerAngles.y -45, 0));
        }
        else if((Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D))|| (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.D))|| (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.D)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, mainCam.transform.eulerAngles.y + 45, 0));
        }
        else if((Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.A))|| (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.A))|| (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.A)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, mainCam.transform.eulerAngles.y - 135, 0));
        }
        else if((Input.GetKeyDown(KeyCode.S) && Input.GetKeyDown(KeyCode.D))|| (Input.GetKeyDown(KeyCode.S) && Input.GetKey(KeyCode.D))|| (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.D)))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, mainCam.transform.eulerAngles.y + 135, 0));
        }
        else if(Input.GetKeyDown(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, mainCam.transform.eulerAngles.y +180, 0));
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, mainCam.transform.eulerAngles.y - 90, 0));
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, mainCam.transform.eulerAngles.y + 90, 0));
        }
    }
}
