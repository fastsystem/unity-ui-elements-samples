using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class Sample2 : EditorWindow
{
    [MenuItem("UIElementsSamples/Sample2")]
    public static void ShowExample()
    {
        Sample2 wnd = GetWindow<Sample2>();
        wnd.titleContent = new GUIContent("Sample2");
    }

    public void OnEnable()
    {
        VisualElement root = rootVisualElement;

        // Create Toolbar
        {
            var toolbar = new Toolbar();
            root.Add(toolbar);

            var btn1 = new ToolbarButton { text = "Button" };
            toolbar.Add(btn1);

            var spc = new ToolbarSpacer();
            toolbar.Add(spc);

            var tgl = new ToolbarToggle { text = "Toggle" };
            toolbar.Add(tgl);

            var spc2 = new ToolbarSpacer() { name = "flexSpacer1", flex = true };
            toolbar.Add(spc2);

            var menu = new ToolbarMenu { text = "Menu" };
            menu.menu.AppendAction("Default is never shown", a => { }, a => DropdownMenuAction.Status.None);
            menu.menu.AppendAction("Normal menu", a => { }, a => DropdownMenuAction.Status.Normal);
            menu.menu.AppendAction("Hidden is never shown", a => { }, a => DropdownMenuAction.Status.Hidden);
            menu.menu.AppendAction("Checked menu", a => { }, a => DropdownMenuAction.Status.Checked);
            menu.menu.AppendAction("Disabled menu", a => { }, a => DropdownMenuAction.Status.Disabled);
            menu.menu.AppendAction("Disabled and checked menu", a => { }, a => DropdownMenuAction.Status.Disabled | DropdownMenuAction.Status.Checked);
            toolbar.Add(menu);

            var spc3 = new ToolbarSpacer() { name = "flexSpacer2", flex = true };
            toolbar.Add(spc3);

            var popup = new ToolbarMenu { text = "Popup", variant = ToolbarMenu.Variant.Popup };
            popup.menu.AppendAction("Popup", a => { }, a => DropdownMenuAction.Status.Normal);
            toolbar.Add(popup);
        }

        // Import UXML
        {
            var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/Sample2.uxml");
            // var styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/Sample2.uss");
            VisualElement labelFromUXML = visualTree.CloneTree();
            // labelFromUXML.styleSheets.Add(styleSheet);
            root.Add(labelFromUXML);
        }
    }
}