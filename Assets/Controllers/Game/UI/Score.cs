using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private static int score = 0;
    public TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        text.text = score.ToString();
    }

    public static void AddScore(int toAdd)
    {
        score += toAdd;
    }
}
