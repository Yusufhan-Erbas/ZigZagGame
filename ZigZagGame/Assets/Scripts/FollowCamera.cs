using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] GameObject target;
    Vector3 distance;

    private void Start()
    {
        distance = transform.position - target.transform.position;//Distence of camera and player.
    }

    private void LateUpdate()
    {
        if (PlayerController.isDead)//if player dead,stop following to Player.
        {
            return;
        }
        transform.position = target.transform.position + distance;//Camera follow same difference.
    }
}
