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

    public void Explode() {
        blade.enabled = false;
        spawner.enabled = false;
        StartCoroutine(ExplodeSequence());
    }

    private IEnumerator ExplodeSequence() {
        float elapsed = 0f;
        float duration = 0.5f;

        while (elapsed < duration) {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.clear, Color.white, t);
            Time.timeScale = 1f - t;
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        yield return new WaitForSecondsRealtime(1f);
        NewGame();
        elapsed = 0f;

        while (elapsed < duration) {
            float t = Mathf.Clamp01(elapsed / duration);
            fadeImage.color = Color.Lerp(Color.white, Color.clear, t);
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
    }
}