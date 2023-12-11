using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCounterUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText = null;

    private void Update()
    {
        scoreText.text = ($"Score: {GameManager.Instance.score}");
    }
}
