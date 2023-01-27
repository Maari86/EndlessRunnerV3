using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    private TextMeshProUGUI scoreText;
    public int score;

    void Awake()
    {
        PlayerAttack.HitEnemy += RunCo;
        Projectile.HitEnemy += RunCo;
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    void Start()
    {
        score = 0;
    }

    void Update()
    {

        scoreText.text = "Hit Score   " + score.ToString();
    }

    private IEnumerator Pulse()
    {
        for (float i = 1f; i <= 1.2f; i += 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1.2f, 1.2f, 1.2f);

        score += 10;
        
        for (float i = 1.2f; i >= 1f; i -= 0.05f)
        {
            scoreText.rectTransform.localScale = new Vector3(i, i, i);
            yield return new WaitForEndOfFrame();
        }
        scoreText.rectTransform.localScale = new Vector3(1f, 1f, 1f);

    }

    public void RunCo()
    {
        StartCoroutine(Pulse());
    }

    public void OnDestroy()
    {
        PlayerAttack.HitEnemy -= RunCo;
        Projectile.HitEnemy -= RunCo;
    }


}