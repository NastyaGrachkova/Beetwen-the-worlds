using System.Collections;
using UnityEngine;

public class DialogHandler
{
    private DialogData _dialogData;
    private DialogView _dialogView;
    private int _dialogIndex;
    private WaitForSeconds _waitForSeconds = new WaitForSeconds(0.01f);

    public DialogHandler(DialogData dialogData, DialogView dialogView)
    {
        _dialogData = dialogData;
        _dialogView = dialogView;
    }

    public void StartDialog()
    {
        _dialogView.ShowDialogPanel();
        _dialogIndex = 0;
        _dialogView.Scip.onClick.RemoveAllListeners();

        _dialogView.Scip.onClick.AddListener(() =>
        {
            if (_dialogIndex < _dialogData.DialogElements.Count)
                ShowElementFromDialogData(_dialogData.DialogElements[_dialogIndex], _dialogData.DialogElements.Count);
            else
                _dialogView.PutAwayDialogPanel();
        });

        ShowElementFromDialogData(_dialogData.DialogElements[_dialogIndex], _dialogData.DialogElements.Count);
    }
    public void StartDialog(DialogData dialogData)
    {
        _dialogView.ShowDialogPanel();
        _dialogIndex = 0;
        _dialogView.Scip.onClick.RemoveAllListeners();
        _dialogView.Scip.onClick.AddListener(() =>
        {
            if (_dialogIndex < dialogData.DialogElements.Count)
                ShowElementFromDialogData(dialogData.DialogElements[_dialogIndex], dialogData.DialogElements.Count);
            else
                _dialogView.PutAwayDialogPanel();
        });
        ShowElementFromDialogData(dialogData.DialogElements[_dialogIndex], dialogData.DialogElements.Count);
    }

    private void ShowElementFromDialogData(DialogElements dialogElements, int dialogElementsLength)
    {
        if (dialogElements.PortretSprite != null)
        {
            _dialogView.Portret.gameObject.SetActive(true);
            _dialogView.Portret.sprite = dialogElements.PortretSprite;
        }
        else 
            _dialogView.Portret.gameObject.SetActive(false);
        _dialogView.StartCoroutine(TypeText(dialogElements.DialogText));
        _dialogIndex++;
    }

    private IEnumerator TypeText(string FullText)
    {
        _dialogView.Text.text = "";
        for (int i = 0; i < FullText.Length; i++)
        {
            _dialogView.Text.text += FullText[i];
            yield return _waitForSeconds;
        }

    }
}
