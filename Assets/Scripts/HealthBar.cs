using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public Enemy enemy;
    public Transform progressBar;

    private float barWidth;
    private float startPos;

    private void Start()
    {
        barWidth = progressBar.localScale.x;
        startPos = progressBar.localPosition.x - barWidth / 2;
    }

    private void Update()
    {
        float progress = barWidth / 2 * enemy.health;
        progressBar.localScale = new Vector3(progress, progressBar.localScale.y, progressBar.localScale.z);
        progressBar.localPosition = new Vector3(startPos + progress / 2, progressBar.localPosition.y, progressBar.localPosition.z);
    }
}
