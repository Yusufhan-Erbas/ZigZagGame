using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject lastGround;

    private void Start()
    {
        for (int i = 1; i < 10; i++)
        {
            MakeGround();
        }
    }

    void MakeGround()
    {
        lastGround = Instantiate(lastGround,lastGround.transform.position+Vector3.left,
            lastGround.transform.rotation);
    }
}
