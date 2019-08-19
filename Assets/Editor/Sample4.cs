using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class Sample4 : EditorWindow
{
    [MenuItem("UIElementsSamples/Sample4")]
    public static void ShowExample()
    {
        Sample4 wnd = GetWindow<Sample4>();
        wnd.titleContent = new GUIContent("Sample4");
    }

    private Label label;
    private Image image;
    private SliderInt slider;

    public void OnEnable()
    {
        VisualElement root = rootVisualElement;

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Sample4.uxml");
        var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Sample4.uss");
        VisualElement labelFromUXML = visualTree.CloneTree();
        labelFromUXML.styleSheets.Add(styleSheet);
        root.Add(labelFromUXML);

        this.label = root.Q<Label>("label");
        this.image = root.Q<Image>("image");
        this.slider = root.Q<SliderInt>("slider");

        slider.RegisterValueChangedCallback<int>(Slider_ValueChanged);
    }

    private void Slider_ValueChanged(ChangeEvent<int> evt)
    {
        this.label.text = $"page {evt.newValue}/{slider.highValue}";
        var backgroundTexture = Resources.Load<Texture2D>($"img_{evt.newValue}");
        this.image.style.backgroundImage = backgroundTexture;
    }
}
