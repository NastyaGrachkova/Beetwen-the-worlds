using UnityEngine;

public class DialogHandler
{
    private DialogData _dialogData;
    private DialogView _dialogView;
    private int _dialogIndex;

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
        _dialogView.Text.text = dialogElements.DialogText;
        _dialogIndex++;
    }
}
