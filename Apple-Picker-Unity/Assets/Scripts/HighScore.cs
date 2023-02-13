using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    static private Text _UI_Text;
    static private int _SCORE = 100;

    private Text txtComponent;

    void Awake()
    {
        _UI_Text = GetComponent<Text>();

        // If the PlayerPrefs HighScore already exists, read it
        if (PlayerPrefs.HasKey("HighScore"))
        {
            SCORE = PlayerPrefs.GetInt("HighScore");
        }
        // Assign the high score to HighScore
        PlayerPrefs.SetInt("HighScore", SCORE);
    }

    static public int SCORE
    {
        get { return _SCORE;  }
        private set
        {
            _SCORE = value;
            PlayerPrefs.SetInt("HighScore", value);
            if (_UI_Text != null)
                _UI_Text.text = "High Score: " + value.ToString("#,0");
        }
    }

    static public void TRY_SET_HIGH_SCORE(int scoreToTry)
    {

        if (scoreToTry <= SCORE) return; //If score is too low, then return
        SCORE = scoreToTry;
    }

    // The following code makes it easy to reset the PlayerPrefs HighScore
    [Tooltip(" Check this box to reset the HighScore in PlayerPrefs")]
    public bool resetHighScoreNow = false;

    void OnDrawGizmos()
    {
        if (resetHighScoreNow)
        {
            resetHighScoreNow = false;
            PlayerPrefs.SetInt("HighScore", 1000);
            Debug.LogWarning(" PlayerPrefs HighScore reset to 1,000.");
        }
    }
}
