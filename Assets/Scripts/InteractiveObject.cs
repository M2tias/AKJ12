using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveObject : MonoBehaviour
{
    [SerializeField]
    GameObject hilightLight;

    private float startedHilight;
    private float hilightDuration = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        hilightLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - startedHilight > hilightDuration)
        {
            hilightLight.SetActive(false);
        }
    }

    public void Hilight()
    {
        hilightLight.SetActive(true);
        startedHilight = Time.time;
    }
}
