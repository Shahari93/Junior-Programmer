using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public MeshRenderer Renderer;
    [SerializeField] float randomFactor;
    [SerializeField] float rotationFactor;
    [SerializeField] float rColorFactor;
    [SerializeField] float bColorFactor;
    [SerializeField] float gColorFactor;
    [SerializeField] float aColorFactor;
    private Material material;
    public float speed = 1.0f;
    float startTime;

    void Start()
    {
        startTime = Time.time;
        randomFactor = Random.Range(0f, 5f);
        rotationFactor = Random.Range(-2f, 4f);
        rColorFactor = Random.Range(0f, 1f);
        bColorFactor = Random.Range(0f, 1f);
        gColorFactor = Random.Range(0f, 1f);
        aColorFactor = Random.Range(0f, 1f);
        transform.position = new Vector3(randomFactor, randomFactor, randomFactor);
        transform.localScale = Vector3.one * randomFactor;

        material = Renderer.material;

        material.color = new Color(rColorFactor, gColorFactor, bColorFactor, aColorFactor);
    }

    void Update()
    {
        transform.Rotate(rotationFactor * Time.deltaTime, rotationFactor, rotationFactor);
        float t = (Mathf.Sin(Time.time - startTime) * speed);
        material.color = Color.Lerp(Color.white, material.color, t);
    }
}
