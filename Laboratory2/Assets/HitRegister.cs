using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitRegister : MonoBehaviour
{
    public TMP_Text scoreText;
    public Transform mainCamera;
    public Transform target;
    private float score = 0;
    private float maxDistance = 10f;

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnCollisionEnter(Collision collision)
    {
        float distance = Vector3.Distance(mainCamera.position, target.position);
        float distancePercent = distance / maxDistance;
        if (distancePercent >= 0.25 && distancePercent < 0.5){
            score += 0.25f;
        } else if(distancePercent >= 0.5 && distancePercent < 1){
            score += 0.5f;
        } else if(distancePercent >= 1){
            score += 1f;
        }
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = $"Score: {score}";
        }
    }
}