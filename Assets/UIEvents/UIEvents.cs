using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIEvents : MonoBehaviour
{

    private UIDocument uiDocument;
    private Button dartButton;
    [SerializeField] GameObject dartButtonItem;
    Sprite dartSprite;
    Image dartImage;

    // Start is called before the first frame update
    void Awake()
    {
        uiDocument = GetComponent<UIDocument>();

        //Set Up Dart Button
        dartButton = uiDocument.rootVisualElement.Q("dartcard") as Button;
        dartButton.RegisterCallback<ClickEvent>(OnCard1Click);
        dartSprite = dartButtonItem.GetComponent<SpriteRenderer>().sprite;
        dartImage = new Image();
        dartImage.transform.position = dartButton.transform.position;
        dartImage.sprite = dartSprite;
    }

    private void OnCard1Click(ClickEvent evt)
    {
        Instantiate(dartButtonItem);
    }

    private void OnDisable()
    {
        dartButton.UnregisterCallback<ClickEvent>(OnCard1Click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
