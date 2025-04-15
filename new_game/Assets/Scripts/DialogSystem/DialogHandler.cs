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
        _dialogView.Scip.onClick.AddListener(() => ShowElementFromDialogData(_dialogData.DialogElements[_dialogIndex]));
        ShowElementFromDialogData(_dialogData.DialogElements[_dialogIndex]);
    }

    private void ShowElementFromDialogData(DialogElements dialogElements)
    {
        _dialogView.Portret.sprite = dialogElements.PortretSprite;
        //_dialogView.Text.text = dialogElements.DialogText;
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
