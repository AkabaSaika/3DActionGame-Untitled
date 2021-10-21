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

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mTransform = this.transform;
    }

    void Update()
    {
        
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))//攻撃モーション中に移動不可
        //{
        Move();
        //}

    }
    void Move()
    {
        PlayerAnimationController._instance.SetWalkState(false);
        PlayerAnimationController._instance.SetRunState(false);
        Vector3 lookPosition = Vector3.Normalize(new Vector3(h, 0, v));
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime,Space.Self);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);

            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);

            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);

            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetRunState(true);

            }
        }
        else
        {
            if(Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.W)&&Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if(Input.GetKey(KeyCode.S)&&Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.LookAt(lookPosition + transform.position);
                transform.Translate(Vector3.forward * mRunSpeed * Time.deltaTime, Space.Self);
                PlayerAnimationController._instance.SetWalkState(true);
            }
        }
    }
}
