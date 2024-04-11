using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorSliderCotroller : MonoBehaviour
{
    [SerializeField] public Slider slider;
    private bool isGameOver = false;
    public Canvas gameOverCanvas;
    private void Start()
    {
        slider.value = 10f;
        gameOverCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver && slider.value <= 0)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Debug.Log("Trap");
            slider.value--;
        }
    }


    void GameOver()
    {
        isGameOver = true;
        gameOverCanvas.gameObject.SetActive(true);
    }
}
