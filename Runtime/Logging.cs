using System.Xml;
using UnityEngine;
using UnityEngine.UIElements;


namespace UIBuddy {
    internal static class Logging {
        private static string GetElementName(VisualElement element) {
            return string.IsNullOrEmpty(element.name) ? "Unnamed element" : element.name;
        }

        internal static void AttributeNameWarning(VisualElement element, XmlAttribute attribute) {
            Debug.LogWarning(
                $"Invalid attribute name on {GetElementName(element)}: {attribute.Name}=\"{attribute.Value}\"");
        }

        internal static void AttributeValueWarning(VisualElement element, XmlAttribute attribute) {
            Debug.LogWarning(
                $"Invalid attribute value on {GetElementName(element)}: {attribute.Name}=\"{attribute.Value}\"");
        }

        internal static void AttributeUnsupportedWarning(VisualElement element, XmlAttribute attribute) {
            Debug.LogWarning(
                $"Unsupported attribute on {GetElementName(element)}: {attribute.Name}=\"{attribute.Value}\"");
        }
    }
}