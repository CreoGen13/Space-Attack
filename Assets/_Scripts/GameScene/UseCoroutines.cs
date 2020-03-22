using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UseCoroutines : MonoBehaviour
{
    #region INITIALIZING
    public GameObject enemyPrefab;
    public GameObject asteroidFirstPrefab;
    public GameObject asteroidSecondPrefab;

    public Text scoreText;
    public Text restartText;
    public Text gameOverText;
    #endregion
    void Start()
    {
        DataHolder.score = 0;
        DataHolder.gameOver = false;

        restartText.text = "";
        gameOverText.text = "";

        StartCoroutine(WaveOfAsteroids());
    }
    private void Update()
    {
        scoreText.text = "Score: " + DataHolder.score;
        if(DataHolder.gameOver && !DataHolder.gameOverScene)
            StartCoroutine(GameOver());
        if(DataHolder.gameOver)
            if(Input.GetKeyDown(KeyCode.Space))
                SceneManager.LoadScene("SpaceGameRemastered");
    }
    IEnumerator CloneEnemyPrefab()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.5f);
            Instantiate(enemyPrefab, new Vector3(Random.Range(-7.9f, 7.9f), 0, 8), Quaternion.identity);
        }
    }
    IEnumerator WaveOfAsteroids()
    {
        yield return new WaitForSeconds(0f);
        while (!DataHolder.gameOver)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Random.value > 0.5)
                    Instantiate(asteroidFirstPrefab, new Vector3(Random.Range(-7.9f, 7.9f), 0, 8), Quaternion.identity);
                else
                    Instantiate(asteroidSecondPrefab, new Vector3(Random.Range(-7.9f, 7.9f), 0, 8), Quaternion.identity);
                yield return new WaitForSeconds(Random.Range(0.3f, 0.6f));
            }
            yield return new WaitForSeconds(5f);
        }
    }
    IEnumerator GameOver()
    {
        DataHolder.gameOverScene = true;
        restartText.color = new Color32(0, 0, 0, 0);
        restartText.text = "Press 'SPACE' to restart";
        gameOverText.color = new Color32(0, 0, 0, 0);
        gameOverText.text = "GAME\nOVER";
        for(byte i = 1; i>0; i+=3)
        {
            gameOverText.color = new Color32(255, 255, 255, i);
            yield return new WaitForSeconds(0.001f);
        }
        gameOverText.color = new Color32(255, 255, 255, 255);
        restartText.color = new Color32(255, 255, 255, 255);

    }
}
