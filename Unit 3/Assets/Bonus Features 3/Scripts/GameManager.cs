using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float score;
    private PlayerContollerBonus playerContoller;

    public Transform startingPos;
    public float lerpSpeed;

    private void Start()
    {
        playerContoller = GameObject.Find("PlayerCharacter").GetComponent<PlayerContollerBonus>();
        score = 0;
        playerContoller.isGameOver = true;

        StartCoroutine(PlayIntro());
    }

    private void Update()
    {
        if (!playerContoller.isGameOver)
        {
            if (playerContoller.isDash)
            {
                score += 2;
            }
            else
            {
                score++;
            }

            Debug.Log("Score: " + score);
        }
    }

    IEnumerator PlayIntro()
    {
        Vector3 startPos = playerContoller.transform.position;
        Vector3 endPos = startingPos.position;
        float journyLength = Vector3.Distance(startPos, endPos);
        float startingTime = Time.time;

        float distanceCovered = (Time.time - startingTime) * lerpSpeed;
        float fractionOfJourny = distanceCovered / journyLength;

        playerContoller.GetComponent<Animator>().SetFloat("Speed_Multiplier", 0.5f);

        while (fractionOfJourny < 1)
        {
            distanceCovered = (Time.time - startingTime) * lerpSpeed;
            fractionOfJourny = distanceCovered / journyLength;
            playerContoller.transform.position = Vector3.Lerp(startPos, endPos, fractionOfJourny);
            yield return null;
        }
        playerContoller.GetComponent<Animator>().SetFloat("Speed_Multiplier", 1);
        playerContoller.isGameOver = false;
    }
}
