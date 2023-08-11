using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _winPanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _fadePanel;

    [Header("Panels")]
    [SerializeField] private GameObject _confetyCamera;

    [Header("Texts")]
    [SerializeField] private Text _levelText;
    [SerializeField] private Text _moneyText;

    [Header("Animators")]
    [SerializeField] private Animator _coinUiAnimator;

    private float _panelDelay;

    private void Start()
    {
        GlobalEventManager.OnLevelStartPlaying += HideStartPanel;
        GlobalEventManager.OnLevelFinish += LevelEnd;
        GlobalEventManager.OnGameRefresh += RefreshPanels;

        _panelDelay = 3f;
    }
    public void UpdateLevelText(int Value)
    {
        _levelText.text = Value.ToString();
    }
    public void UpdateMoneyText(int Value)
    {
        _moneyText.text = Value.ToString();
        _coinUiAnimator.SetTrigger("Scale");
    }
    private void HideStartPanel()
    {
        _startPanel.SetActive(false);
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelStartPlaying -= HideStartPanel;
        GlobalEventManager.OnLevelFinish -= LevelEnd;
        GlobalEventManager.OnGameRefresh -= RefreshPanels;
    }
    private void LevelEnd(bool Win)
    {
        if (Win)
        {
            Invoke(nameof(ShowWinPanel), _panelDelay);
            ShowConfety();
        }
        else
        {
            Invoke(nameof(ShowLosePanel), _panelDelay);
        }
    }
    private void ShowWinPanel()
    {
        _winPanel.SetActive(true);
    }
    private void ShowLosePanel()
    {
        _losePanel.SetActive(true);
    }
    public void ShowFadePanel()
    {
        _fadePanel.SetActive(true);

        Invoke(nameof(DisableFadePanel), 3f);
    }
    private void DisableFadePanel()
    {
        _fadePanel.SetActive(false);
    }
    private void ShowConfety()
    {
        _confetyCamera.SetActive(true);
    }
    private void RefreshPanels()
    {
        _confetyCamera.SetActive(false);
        _startPanel.SetActive(true);
        _losePanel.SetActive(false);
        _winPanel.SetActive(false);
    }
}
