using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public static DialogManager main;
    private InteractiveObject obj;
    private StoryTrigger storyObj;
    private bool readingStory = false;

    public bool IsDialogOpen
    {
        get; private set;
    }

    [SerializeField]
    private TextMeshProUGUI dialogText;
    [SerializeField]
    private Canvas DialogCanvas;

    void Awake()
    {
        main = this;

    }

    void Start()
    {
        obj = null;
        storyObj = null;
        IsDialogOpen = false;
    }

    void Update()
    {

        if (storyObj != null)
        {
            if (readingStory == false)
            {
                string text = storyObj.GetNextDialog();

                // Debug.Log(text);
                if (text != null)
                {
                    DialogCanvas.gameObject.SetActive(true);
                    dialogText.text = text;
                    IsDialogOpen = true;
                    readingStory = true;
                }
                else
                {
                    DialogCanvas.gameObject.SetActive(false);
                    IsDialogOpen = false;
                    storyObj.Kill();
                    storyObj = null;
                }
            }
            else if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0))
            {
                readingStory = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.E) || Input.GetMouseButtonUp(0))
        {
            if (obj != null)
            {
                string text = obj.GetNextDialog();

                if (text != null)
                {
                    dialogText.text = text;
                }
                else
                {
                    obj.RestartDialog();
                    obj = null;
                }
            }

            if (obj != null)
            {
                DialogCanvas.gameObject.SetActive(true);
                IsDialogOpen = true;
            }
            else
            {
                DialogCanvas.gameObject.SetActive(false);
                IsDialogOpen = false;
            }
        }
    }

    public void SetCurrentObj(InteractiveObject obj)
    {
        this.obj = obj;
    }

    public void SetCurrentStoryTrigger(StoryTrigger storyObj)
    {
        this.storyObj = storyObj;
    }
}
