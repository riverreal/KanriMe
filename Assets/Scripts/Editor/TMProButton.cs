using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TMPButton {

    [MenuItem("GameObject/UI/TextMeshPro - Button", false, 0)]
    static void CreateTMPButton()
    {
        GameObject obj = new GameObject("TMPButton");
        obj.AddComponent<Image>();
        obj.AddComponent<Button>();

        obj.transform.SetParent(Selection.activeTransform, false);

        GameObject child = new GameObject("ButtonText");
        RectTransform rect= child.AddComponent<RectTransform>();
        TextMeshProUGUI text = child.AddComponent<TextMeshProUGUI>();

        text.SetText("Button");
        text.color = Color.black;
        text.fontSize = 30;
        text.alignment = TextAlignmentOptions.Center;

        child.transform.SetParent(obj.transform,false);
        
        rect.anchorMin = new Vector2(0, 0);
        rect.anchorMax = new Vector2(1, 1);
        rect.offsetMax = new Vector2(0, 0);
        rect.offsetMin = new Vector2(0, 0);
    }
}