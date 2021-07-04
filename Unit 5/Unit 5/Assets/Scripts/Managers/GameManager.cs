using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> targets;
    WaitForSeconds waitSpawn = new WaitForSeconds(1.0f);

    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        // While this is true (always), run this corutine
        while (true)
        {
            yield return waitSpawn;
            int randTarget = Random.Range(0, targets.Count);
            Instantiate(targets[randTarget]);
        }
    }
}
