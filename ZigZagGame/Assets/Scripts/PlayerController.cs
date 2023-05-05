using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 yon = Vector3.left;

    [SerializeField] float speed;

    public GroundSpawner groundSpawner;

    public static bool isDead=false;

    public float velocityHard;

    public int score = 0;

    private void Update()
    {
        if (isDead)
        {
            return;
        }
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

        if (transform.position.y < 0.1f)
        {
            isDead = true;
            Debug.Log("Öldüm ben");
            //Destroy(gameObject,3f);
        }
    }

    private void FixedUpdate()
    {
        Vector3 hareket = yon * speed * Time.deltaTime;//Our object movement value.
        speed += Time.deltaTime *velocityHard;
        transform.position += hareket;//Adding movement value to our position.
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            StartCoroutine(DestroyGround(collision.gameObject));
            groundSpawner.MakeGround();
        }
    }

    IEnumerator DestroyGround(GameObject ground)
    {
        yield return new WaitForSeconds(0.05f);
        ground.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(0.5f);
        Destroy(ground);
    }

}


