using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEditor.UIElements;


public class Sample3 : EditorWindow
{
    [MenuItem("UIElementsSamples/Sample3")]
    public static void ShowExample()
    {
        Sample3 wnd = GetWindow<Sample3>();
        wnd.titleContent = new GUIContent("Sample3");
    }

    public void OnEnable()
    {
        VisualElement root = rootVisualElement;

        root.AddManipulator(new MouseEventLogger());
        root.Add(new Label() { style = { backgroundColor = Color.yellow }, text = "output console log!" });
    }

    class MouseEventLogger : Manipulator
    {
        protected override void RegisterCallbacksOnTarget()
        {
            target.RegisterCallback<MouseUpEvent>(OnMouseUpEvent);
            target.RegisterCallback<MouseDownEvent>(OnMouseDownEvent);
        }

        protected override void UnregisterCallbacksFromTarget()
        {
            target.UnregisterCallback<MouseUpEvent>(OnMouseUpEvent);
            target.UnregisterCallback<MouseDownEvent>(OnMouseDownEvent);
        }

        void OnMouseUpEvent(MouseEventBase<MouseUpEvent> evt)
        {
            Debug.Log("Mouse Up " + evt + " in " + evt.propagationPhase + " for target " + evt.target);
        }

        void OnMouseDownEvent(MouseEventBase<MouseDownEvent> evt)
        {
            Debug.Log("Mouse Down " + evt + " in " + evt.propagationPhase + " for target " + evt.target);
        }
    }
}