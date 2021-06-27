using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapObjects : MonoBehaviour
{
    [SerializeField]
    List<GameObject> HideThese;
    [SerializeField]
    List<GameObject> ShowThese;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapThings()
    {
        foreach (GameObject obj in HideThese)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        foreach (GameObject obj in ShowThese)
        {
            if (obj != null)
                obj.SetActive(true);
        }
    }
}
