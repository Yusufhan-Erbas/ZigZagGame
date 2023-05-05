using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    [SerializeField] GameObject lastGround;

    private void Start()
    {
        for (int i = 1; i < 20; i++)
        {
            MakeGround();
        }
    }

    public void MakeGround()
    {
        Vector3 yon;
        if (Random.Range(0, 2) == 0)//Random ground generated in x axis .
        {
            yon = Vector3.left;
        }
        else// Random ground generated in z axis .
        {
            yon = Vector3.back;
        }
        lastGround = Instantiate(lastGround,lastGround.transform.position+yon,
            lastGround.transform.rotation);
    }
}
