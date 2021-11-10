using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatusController : MonoBehaviour
{
    public static PlayerStatusController _instance;
    [SerializeField]
    private float mMaxHp;
    [SerializeField]
    private float mCurrentHp;
    [SerializeField]
    private float mMaxStamina;
    [SerializeField]
    private float mCurrentStamina;
    [SerializeField]
    private int mLevel;

    public float maxHp
    {
        get { return mMaxHp; }
        set { mMaxHp = value; }
    }

    public float currentHp
    {
        get { return mCurrentHp; }
        set { mCurrentHp = value; }
    }

    public float maxStamina
    {
        get { return mMaxStamina; }
        set { mMaxStamina = value; }
    }

    public float currentStamina
    {
        get { return mCurrentStamina; }
        set { mCurrentStamina = value; }
    }

    public int level
    {
        get { return mLevel; }
        set { mLevel = value; }
    }


    private void Awake()
    {
        _instance = this;
        mCurrentHp = mMaxHp;
        mCurrentStamina = mMaxStamina;
    }

    private void TakeDamage(float damage)
    {
        mCurrentHp -= damage;
    }

    private void ConsumeStamina(float stamina)
    {
        mCurrentStamina -= stamina;
    }


}
