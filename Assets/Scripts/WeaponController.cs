using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public List<GameObject> weaponsList;
    public Transform playerRightHand;
    private GameObject weapon = new GameObject();
    private Collider weaponCollider;

    // Start is called before the first frame update
    void Start()
    {
        weapon = Instantiate(weaponsList[0]);
        weapon.transform.parent = playerRightHand;
        weapon.transform.localPosition = new Vector3(0.01f, 0.16f, 0);
        weapon.transform.rotation = Quaternion.Euler(0, 0, 40);
        weaponCollider = weapon.GetComponent<CapsuleCollider>();
        weaponCollider.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        switch(collision.tag)
        {
            case "Enemy":
                collision.SendMessage("TakeDamage");
                break;
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
