using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] private Button _buttonPause;
    [SerializeField] private Button _buttonClosePanelAutors;

    [SerializeField] private GameObject _panelPause;
    [SerializeField] private GameObject _panelAutors;

    public void OpenPanelPause()
    {
        _buttonPause.enabled = false;
        _panelPause.SetActive(true);
    }

    public void Continue()
    {
        _panelPause.SetActive(false);
        _buttonPause.enabled = true;
    }

    public void OpenPanelAutors()
    {
        _panelAutors.SetActive(true);
        _panelPause.SetActive(false);
    }

    public void ClosePanelAutors()
    {
        _panelAutors.SetActive(false);
        _panelPause.SetActive(true);
    }
}
