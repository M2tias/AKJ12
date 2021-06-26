using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    List<string> dialog;
    private int currentDialog = 0;

    [SerializeField]
    GameObject hilightLight;

    private float startedHilight;
    private float hilightDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        // dialog.Enqueue(
        //     "It's his baseball cap! He must have gone to the cave. I hope he's fine. This might cave in anytime..."
        // );
        // dialog.Enqueue("I should go look for him");
        hilightLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startedHilight > hilightDuration)
        {
            hilightLight.SetActive(false);
            DialogManager.main.SetCurrentObj(null);
        }
    }

    public void Hilight()
    {
        hilightLight.SetActive(true);
        startedHilight = Time.time;
        DialogManager.main.SetCurrentObj(this);
    }

    public string GetNextDialog()
    {
        string dialogText = currentDialog < dialog.Count ? dialog[currentDialog] : null;
        currentDialog++;
        return dialogText;
    }

    public void RestartDialog()
    {
        currentDialog = 0;
    }
}
