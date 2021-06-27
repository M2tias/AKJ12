using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTrigger : MonoBehaviour
{
    [SerializeField]
    List<string> dialog;
    private int currentDialog = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            DialogManager.main.SetCurrentStoryTrigger(this);
            SwapObjects swapper = gameObject.GetComponent<SwapObjects>();
            Debug.Log(swapper);
            if (swapper != null) swapper.SwapThings();
        }
    }

    public void PlayerHit()
    {
        DialogManager.main.SetCurrentStoryTrigger(this);
        SwapObjects swapper = gameObject.GetComponent<SwapObjects>();
        Debug.Log(swapper);
        if (swapper != null) swapper.SwapThings();
    }

    public string GetNextDialog()
    {
        string dialogText = currentDialog < dialog.Count ? dialog[currentDialog] : null;
        currentDialog++;
        return dialogText;
    }

    public void Kill()
    {
        Destroy(gameObject);
    }
}
