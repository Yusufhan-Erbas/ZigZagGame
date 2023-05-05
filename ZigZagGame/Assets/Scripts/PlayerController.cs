using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Out Component")]
    Vector3 yon = Vector3.left;
    [SerializeField] float speed;
    [SerializeField] Text scoreText, bestScoreText;
    [SerializeField] GameObject restartPanel,playGamePanel;

    [Header("Public Variable")]
    int bestScore = 0;
    public GroundSpawner groundSpawner;
    public static bool isDead=true;
    public float velocityHard;
    float score = 0f;
    float addAmount=1f;

    private void Start()
    {
        if (RestartGame.isRestart)
        {
            isDead = false;
            playGamePanel.SetActive(false);
        }
        bestScore = PlayerPrefs.GetInt("BestScore");
        bestScoreText.text ="Best: "+ bestScore.ToString();
    }

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
            if (bestScore < score)
            {
                bestScore = (int)score;
                PlayerPrefs.SetInt("BestScore", bestScore);
            }
            restartPanel.SetActive(true);
            Destroy(gameObject,3f);
        }
    }

    private void FixedUpdate()
    {
        if (isDead)
        {
            return;
        }

        Vector3 hareket = yon * speed * Time.deltaTime;//Our object movement value.
        speed += Time.deltaTime *velocityHard;
        transform.position += hareket;//Adding movement value to our position.

        score += speed * addAmount * Time.deltaTime;

        scoreText.text =((int) score).ToString();
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

    public void PlayGame()
    {
        isDead = false;
        playGamePanel.SetActive(false);
    }

}


