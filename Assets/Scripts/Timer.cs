using UnityEngine;
using TMPro;
using System.Collections;

public class Timer : MonoBehaviour {

    private int minutes, seconds, cents;
    private float timeElapsed;
    [SerializeField, Tooltip("Tempo em segundos")] private float tempoRegressivo;
    [SerializeField] private TMP_Text timerText, regressivoTimerText;


    private void Start() {
        StartCoroutine(nameof(StartTimer));
    }
    private void Update() {

        if (tempoRegressivo == 0) {
            return;
        }

        tempoRegressivo -= Time.deltaTime;
        if (tempoRegressivo < 0) {
            tempoRegressivo = 0;
        }

        minutes = (int)(tempoRegressivo / 60f);
        seconds = (int)(tempoRegressivo - minutes * 60f);
        cents = (int)((tempoRegressivo - (int)tempoRegressivo) * 1000f);

        regressivoTimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, cents);
    }

    private IEnumerator StartTimer() {
        while (true) {
            timeElapsed += Time.deltaTime;

            minutes = (int)(timeElapsed / 60f);
            seconds = (int)(timeElapsed - minutes * 60f);
            cents = (int)((timeElapsed - (int)timeElapsed) * 1000f);

            timerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, cents);
            yield return null;
        }
        
        
    }
}
