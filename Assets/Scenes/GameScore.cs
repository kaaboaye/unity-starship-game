using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    private int score;

    public Text text;

    void Start()
    {
        score = 0;
    }

    public void AsteroidDestroied()
    {
        score++;

        text.text = score.ToString();
    }
}
