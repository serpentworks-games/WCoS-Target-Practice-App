using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [Header("App Settings")]
    [SerializeField] string[] targetStrings = new string[0];
    [SerializeField] float cycleSpeed;
    [SerializeField] float cycleIncreaseAmount;
    [SerializeField] float cycleModifier;

    [Header("Menu Settings")]
    [SerializeField] Canvas menuCanvas;
    [SerializeField] TextMeshProUGUI speedTextField;
    [SerializeField] TextMeshProUGUI versionTextField;
    [SerializeField] TextMeshProUGUI copyrightTextField;
    [SerializeField] Canvas targetCyclerCanvas;
    [SerializeField] TextMeshProUGUI textField;

    private void Awake()
    {
        menuCanvas.gameObject.SetActive(true);
        targetCyclerCanvas.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        versionTextField.text = "Version: " + Application.version;
        copyrightTextField.text = "(c) 2021 WCoS & " + Application.companyName;
    }

    // Update is called once per frame
    void Update()
    {
        if (cycleSpeed < 1)
        {
            cycleSpeed = 1;
        }
        else if (cycleSpeed > 10)
        {
            cycleSpeed = 10;
        }

        speedTextField.text = "Speed: " + cycleSpeed;
    }


    IEnumerator CycleText()
    {
        while (true)
        {
            int newIndex = Random.Range(0, targetStrings.Length);
            textField.text = targetStrings[newIndex];

            yield return new WaitForSeconds(cycleModifier / cycleSpeed);
        }
    }

    public void IncreaseSpeed()
    {
        cycleSpeed += cycleIncreaseAmount;
    }

    public void DecreaseSpeed()
    {
        cycleSpeed -= cycleIncreaseAmount;
    }

    public void StartApp()
    {
        StartCoroutine("CycleText");
    }

    public void StopApp()
    {
        StopCoroutine("CycleText");
    }
}
