using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCameraController : MonoBehaviour
{
    private Transform _followObject;
    private Vector3 _cameraPos;
    private float _preX;
    private float _preY;
    private float _currX;
    private float _currY;
    private float _rotateAngleX;
    private float _rotateAngleY;
    private Vector2 _MouseBtnDownPosInScreen;
    private Vector2 _MouseBtnUpPosInScreen;
    private Vector3 _posMouseBtnDownPosInWorld;
    private Vector3 _posMouseBtnUpPosInWorld;
    [SerializeField]
    private float _Xoffset=5.0f;
    [SerializeField]
    private float _Yoffset=5.0f;
    [SerializeField]
    private float _Zoffset=-5.0f;

    // Start is called before the first frame update
    void Start()
    {
        _followObject = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _cameraPos = _followObject.position + new Vector3(_Xoffset, _Yoffset, _Zoffset);
        if(Input.GetMouseButtonDown(0))
        {
            _preX = Input.mousePosition.x;
            _preY = Input.mousePosition.y;
            _MouseBtnDownPosInScreen = new Vector2(_preX, _preY);
        }
        if(Input.GetMouseButtonUp(0))
        {
            _currX = Input.mousePosition.x;
            _currY = Input.mousePosition.y;
            _MouseBtnUpPosInScreen = new Vector2(_currX, _currY);
        }
        _posMouseBtnDownPosInWorld = Camera.main.ScreenToWorldPoint(new Vector3(_preX, _preY, Mathf.Abs(-Camera.main.transform.position.z)));
        _posMouseBtnUpPosInWorld = Camera.main.ScreenToWorldPoint(new Vector3(_currX, _currY, Mathf.Abs(-Camera.main.transform.position.z)));
        //rotateAngle = Vector3.Angle(_posMouseBtnDownPosInWorld, _posMouseBtnUpPosInWorld);
        _rotateAngleX = Vector3.Angle(Vector3.Project(_posMouseBtnDownPosInWorld, Vector3.right), Vector3.Project(_posMouseBtnUpPosInWorld, Vector3.right));
        _rotateAngleY = Vector3.Angle(Vector3.Project(_posMouseBtnDownPosInWorld, Vector3.up), Vector3.Project(_posMouseBtnUpPosInWorld, Vector3.up));
        transform.Rotate(Vector3.right, _rotateAngleX);
        transform.Rotate(Vector3.up, _rotateAngleY);
        //Debug.Log(_MouseBtnDownPosInScreen + "\n" + _MouseBtnUpPosInScreen + "\n" + _posMouseBtnDownPosInWorld + "\n" + _posMouseBtnUpPosInWorld);
        transform.position = _cameraPos;
        Debug.Log(_rotateAngleX + "/n" + _rotateAngleY);
    }
}
