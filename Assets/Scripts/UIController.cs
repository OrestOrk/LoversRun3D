using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject _startPanel;

    [Header("Text")]
    [SerializeField] private Text _levelTextValue;
    void Start()
    {
        GlobalEventManager.OnLevelStartPlaying += HideStartPanel;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLevelText(int Value)
    {
        _levelTextValue.text = Value.ToString();
    }
    private void HideStartPanel()
    {
        _startPanel.SetActive(false);
    }
    private void OnDestroy()
    {
        GlobalEventManager.OnLevelStartPlaying -= HideStartPanel;
    }
}
