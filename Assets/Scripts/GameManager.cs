using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Image fadeImage;
    private Blade blade;
    private Spawner spawner;

    private void Awake() {
        blade = FindObjectOfType<Blade>();
        spawner = FindObjectOfType<Spawner>();
    }

    private void Start() {
        NewGame();
    }

    private void NewGame() {
        Time.timeScale = 1f;
        ClearScene();
        blade.enabled = true;
        spawner.enabled = true;
    }

    private void ClearScene() {
        Fruit[] fruits = FindObjectsOfType<Fruit>();
        foreach (Fruit fruit in fruits) {
            Destroy(fruit.gameObject);
        }
    }
}
