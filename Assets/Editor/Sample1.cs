using MyControls;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;


public class Sample1 : EditorWindow
{
    [MenuItem("UIElementsSamples/Sample1")]
    public static void ShowExample()
    {
        Sample1 wnd = GetWindow<Sample1>();
        wnd.titleContent = new GUIContent("Sample1");
    }

    public void OnEnable()
    {
        VisualElement root = rootVisualElement;

        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Sample1.uxml");
        VisualElement labelFromUXML = visualTree.CloneTree();
        root.Add(labelFromUXML);

        root.Q<RedButton>("btn1").clicked += ButtonClicked;
        root.Q<RedButton>("btn2").clicked += ButtonClicked;
        root.Q<RedButton>("btn3").clicked += ButtonClicked;
    }

    void ButtonClicked(EventBase eventBase)
    {
        var redButton = (RedButton)eventBase.target;
        Debug.Log($"Clicked {redButton.text} RedButton!! ");
    }
}