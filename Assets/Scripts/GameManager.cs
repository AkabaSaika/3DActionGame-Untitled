using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //玩家死亡处理
        if(player.GetComponent<PlayerController>().hp<=0)
        {
            Debug.Log("死んだ");
            Destroy(player);
        }
    }
}
