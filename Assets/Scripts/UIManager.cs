using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text t_level;
    public RectTransform progressBar;

    private float barWidth;
    private float startPos;

    private void Start()
    {
        barWidth = progressBar.sizeDelta.x;
        startPos = progressBar.position.x - barWidth / 2;
    }

    private void Update()
    {
        t_level.text = ExpSystem.level.ToString();
        float progress = barWidth / ExpSystem.expToLevelUp * ExpSystem.exp;
        progressBar.sizeDelta = new Vector2(progress, progressBar.sizeDelta.y);
        progressBar.position = new Vector2(startPos + progress / 2, progressBar.position.y);
    }

}
