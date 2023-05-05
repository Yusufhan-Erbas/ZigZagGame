using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 yon = Vector3.left;

    [SerializeField] float speed;

    public GroundSpawner groundSpawner;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x == 0) //Object move x axis
            {
                yon = Vector3.left;
            }
            else//Object move z axis.
            {
                yon = Vector3.back;
            }
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;//Our object movement value.
        transform.position += hareket;//Adding movement value to our position.
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))//if Player left ground new ground added.
        {
            DestroyGround(collision.gameObject);
            groundSpawner.MakeGround();
        }
    }

    void DestroyGround(GameObject ground)
    {
        Destroy(ground);
    }

}


