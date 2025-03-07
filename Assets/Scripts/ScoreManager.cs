using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Multiple instances of ScoreManager detected! Destroying duplicate.");
            Destroy(gameObject);
            return;
        }
    }


    public TextMeshProUGUI scoreText;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        ScoreUpdate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreIncrement () { score++; ScoreUpdate(); }

    public void ScoreUpdate () { scoreText.text = "Score: " + score; }
}
