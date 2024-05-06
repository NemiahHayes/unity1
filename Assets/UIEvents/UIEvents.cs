using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEvents : MonoBehaviour
{

    private UIDocument uiDocument;
    private Button dartButton;
    private Button bananaButton;
    [SerializeField] GameObject bananaButtonItem;
    [SerializeField] GameObject dartButtonItem;
    

    // Start is called before the first frame update
    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        //Set Up Banana Button
        bananaButton = uiDocument.rootVisualElement.Q("bananacard") as Button;
        bananaButton.RegisterCallback<ClickEvent>(OnBananaClick);

        //Set Up Dart Button
        dartButton = uiDocument.rootVisualElement.Q("dartcard") as Button;
        dartButton.RegisterCallback<ClickEvent>(OnDartClick);
    }

    private void OnDartClick(ClickEvent evt)
    {
        Instantiate(dartButtonItem);
    }

    private void OnBananaClick(ClickEvent evt)
    {
        Instantiate(bananaButtonItem);
    }

    private void OnDisable()
    {
        dartButton.UnregisterCallback<ClickEvent>(OnDartClick);
        bananaButton.UnregisterCallback<ClickEvent>(OnBananaClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
