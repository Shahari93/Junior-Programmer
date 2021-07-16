using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongratScript : MonoBehaviour
{
    public TextMesh Text;
    public ParticleSystem SparksParticles;

    private List<string> TextToDisplay = new List<string>();
    private float TimeToNextText;
    private int CurrentText;
    void Start()
    {
        TimeToNextText = 0.0f;
        CurrentText = 0;

        TextToDisplay.Add("Congratulation");
        TextToDisplay.Add("All Errors Fixed");

        Text.text = TextToDisplay[0];

        SparksParticles.Play();
    }

    void Update()
    {
        TimeToNextText += .003f;

        if (TimeToNextText > 1.5f)
        {
            CurrentText = 1;
            Text.text = TextToDisplay[CurrentText];
            if (CurrentText == TextToDisplay.Count - 1 && TimeToNextText > 3f)
            {
                CurrentText = 0;
                Text.text = TextToDisplay[CurrentText];
                TimeToNextText = 0.0f;
            }
        }
    }
}