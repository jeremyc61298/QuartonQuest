﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinPanelController : MonoBehaviour
{
    public delegate IEnumerator CancelHandler();
    public event CancelHandler OnCancel;
    public GameObject JoinPanel = null;
    public Button cancelButton;

    public void OnCancelButtonClicked()
    {
        StartCoroutine(Cancel_Async());
    }

    public IEnumerator Cancel_Async()
    {
        cancelButton.interactable = false;
        yield return OnCancel?.Invoke();
        JoinPanel.SetActive(false);
        cancelButton.interactable = true;
    }
}
