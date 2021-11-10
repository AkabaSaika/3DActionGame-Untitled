using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Image hpBar;
    public Image staminaBar;

    private PlayerStatusController playerStatus;
    // Start is called before the first frame update
    void Start()
    {
        playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatusController>();
    }

    // Update is called once per frame
    void Update()
    {
        hpBar.fillAmount = playerStatus.currentHp / playerStatus.maxHp;
    }


}
