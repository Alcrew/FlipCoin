using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreenScript : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] ParticleSystem partSys;
    public float FillSpeed = 0.3f;
    private float targetProgress = 0;
    [SerializeField] GameObject _gamePanel;
    [SerializeField] GameObject _loadingPanel;
    [SerializeField] GameObject _loadingText;
    [SerializeField] GameObject _tossCointText;

    private void Awake()
    {
        //slider = gameObject.GetComponent<Slider>();
        //partSys = GameObject.Find("ProgressBarParticles").GetComponent<ParticleSystem>();
        _loadingPanel.SetActive(true);
    }

    void Start()
    {
        IncrementProgress(1.0f);
        _gamePanel.SetActive(false);
        _tossCointText.SetActive(false);
        StartCoroutine(loadingCoroutine());
    }

    void Update()
    {

        if (slider.value < targetProgress)
        {
            slider.value += FillSpeed * Time.deltaTime;
            if (!partSys.isPlaying)
                partSys.Play();
        }
        else
        {
            partSys.Stop();
            loadingCoroutine();
        }

    }
    IEnumerator loadingCoroutine()
    { 
        yield return new WaitForSeconds(3);
        _loadingText.SetActive(false);
        _tossCointText.SetActive(true);
        yield return new WaitForSeconds(3);
        _gamePanel.SetActive(true);
        _loadingPanel.SetActive(false);

    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }


}
