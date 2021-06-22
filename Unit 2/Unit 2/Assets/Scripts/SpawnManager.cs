using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            int animalIndex = Random.Range(0, animalPrefab.Length);
            if (animalIndex > animalPrefab.Length - 1)
            {
                return;
            }
            Instantiate(animalPrefab[animalIndex], new Vector3(0, 0, 20), animalPrefab[animalIndex].transform.rotation);
        }
    }
}
