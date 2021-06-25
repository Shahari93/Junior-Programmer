using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    [SerializeField] float elapsedTime;
    [SerializeField] private float interval = 0.5f;
    [SerializeField] private float intervalLimit = 1.1f;

    // Update is called once per frame
    void Update()
    {
        SpawnDogFromInput();
    }

    private void SpawnDogFromInput()
    {
        elapsedTime += 0.1f;

        if (elapsedTime <= interval)
        {
            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
            }
        }
        if (elapsedTime >= intervalLimit)
        {
            elapsedTime = 0;
        }
    }
}