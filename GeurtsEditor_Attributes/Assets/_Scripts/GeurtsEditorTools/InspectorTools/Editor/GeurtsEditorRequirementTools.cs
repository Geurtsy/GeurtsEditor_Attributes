using UnityEditor;
using UnityEngine;

namespace Geurts.InspectorTools
{
    /// <summary>
    /// Use this class to create areas that Notify the user of Component Requirements.
    /// </summary>
    public static class GeurtsEditorRequirementTools
    {
        #region Public Fields

        public static readonly string _namingErrorCode = "For better organisation, environmental objects have specific naming conventions.";

        #endregion Public Fields

        #region Private Fields

        private static readonly int _defaultEndSpacing = 5;

        #endregion Private Fields

        #region Public Enums

        public enum ErrorType { WARNING, ERROR, RECOMMENDATION }

        #endregion Public Enums

        #region Public Methods

        /// <summary>
        /// Display a Collider2DRequirement.
        /// </summary>
        /// <param name="targetGameObject">The GameObject that requires this Component.</param>
        /// <param name="errorType">The type of error missing this component creates.</param>
        /// <param name="message">The error message.</param>
        public static void DisplayCollider2DRequirement(GameObject targetGameObject, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplayCollider2DRequirement"))
                return;

            Collider2D collider2D = targetGameObject.GetComponent<Collider2D>();

            if (collider2D == null)
            {
                string errorCode = GetErrorCode(targetGameObject, "MISSING_COLLIDER2D", "Collider2D");

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);

                EditorGUILayout.BeginHorizontal();
                if (GUILayout.Button("Assign BoxCollider2D"))
                {
                    targetGameObject.AddComponent<BoxCollider2D>();
                }

                if (GUILayout.Button("Assign CircleCollider2D"))
                {
                    targetGameObject.AddComponent<CircleCollider2D>();
                }
                EditorGUILayout.EndHorizontal();

                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        /// <summary>
        /// Displays an area that notifies the user of the required Component.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="targetGameObject">The GameObject that requires this Component.</param>
        /// <param name="errorType">The type of error missing this component creates.</param>
        /// <param name="message">The error message that will be displayed.</param>
        public static void DisplayComponentRequirement<T>(GameObject targetGameObject, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplayComponentRequirement"))
                return;

            T component = targetGameObject.GetComponent<T>();

            if (component == null)
            {
                GUI.contentColor = Color.white;

                string componentName = typeof(T).Name;
                string errorCode = GetErrorCode(targetGameObject, "MISSING_COMPONENT", componentName);

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);
                if (GUILayout.Button("Create Component: " + componentName))
                {
                    targetGameObject.AddComponent(typeof(T));
                }
                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        /// <summary>
        /// Displays a problematic area that notifies the user of the required layer the target
        /// GameObject must be on.
        /// </summary>
        /// <param name="targetGameObject"></param>
        /// <param name="layerName">Target GameObject's required Layer.</param>
        /// <param name="errorType">The type of error created when lacking this requirement.</param>
        /// <param name="message">The error message that will be displayed in the problematic area.</param>
        public static void DisplayLayerRequirement(GameObject targetGameObject, string layerName, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplayLayerRequirement"))
                return;

            if (targetGameObject.layer != LayerMask.NameToLayer(layerName))
            {
                string errorCode = GetErrorCode(targetGameObject, "INCORRECT_LAYER", "layer, " + layerName);

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);

                if (GUILayout.Button("Assign Layer: " + layerName))
                {
                    targetGameObject.layer = LayerMask.NameToLayer(layerName);
                }

                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        /// <summary>
        /// Display a Name Requirement as an error. Use
        /// GeurtsEditorSectionCreator.CreateCustomIdentityRequirement for more advance name
        /// management. Both can be used for heightened name integrity.
        /// </summary>
        /// <param name="targetGameObject">The GameObject that requires a specific naming convention.</param>
        /// <param name="requiredName">The RequiredName the Target GameObject must have.</param>
        /// <param name="errorType">The type of error created from improper naming convention.</param>
        /// <param name="message">The message displayed inside the problematic error.</param>
        public static void DisplayNameRequirement(GameObject targetGameObject, string requiredName, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplayNameRequirement"))
                return;

            string currentName = targetGameObject.name;
            string[] splitNames = currentName.Split(' ');

            if (splitNames[0] != requiredName)
            {
                string errorCode = GetErrorCode(targetGameObject, "INVALID_NAME", "correct name");

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);
                if (GUILayout.Button("Reset Name to Default"))
                {
                    targetGameObject.name = requiredName + " (Unnamed)";
                }
                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        /// <summary>
        /// Displays a ProblematicArea that Notifies the user of the Parent requirment.
        /// </summary>
        /// <param name="targetGameObject">The GameObject that Requires a parent.</param>
        /// <param name="requiredParentName">
        /// The parent name that is Required. This is used prevent using an incorrect parent.
        /// </param>
        /// <param name="errorType">
        /// The type of Error that is Created by not fullfilling Specified Requirement.
        /// </param>
        /// <param name="message">The message that is displayed in the Problematic Area.</param>
        public static void DisplayParentRequirement(GameObject targetGameObject, string requiredParentName, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplayParentRequirement"))
                return;

            if (targetGameObject.transform.parent == null)
            {
                string errorCode = GetErrorCode(targetGameObject, "NULL_PARENT", "parent");

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);
                if (GUILayout.Button("Create Parent"))
                {
                    GameObject newGameObject = new GameObject(requiredParentName);
                    newGameObject.transform.parent = targetGameObject.transform.parent;
                    targetGameObject.transform.parent = newGameObject.transform;
                }
                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
            else
            {
                string currentParentName = targetGameObject.transform.parent.name;

                if (currentParentName.Split(' ')[0] == requiredParentName)
                {
                    return;
                }

                string errorCode = GetErrorCode(targetGameObject, "INVALID_PARENT", "parent");

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);

                GUILayout.BeginHorizontal();
                if (GUILayout.Button("Create New Parent"))
                {
                    GameObject newGameObject = new GameObject(requiredParentName);
                    newGameObject.transform.parent = targetGameObject.transform.parent;
                    targetGameObject.transform.parent = newGameObject.transform;
                }
                else if (GUILayout.Button("Rename Parent"))
                {
                    targetGameObject.transform.parent.name = requiredParentName;
                }
                GUILayout.EndHorizontal();

                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        /// <summary>
        /// Displays a Problematic Area that notfies the user of the SpriteRenderer Requirement.
        /// </summary>
        /// <param name="targetGameObject">The GameObject that must have a SpriteRenderer.</param>
        /// <param name="errorType">The Error type created due to lacking the requiremed component.</param>
        /// <param name="message">The error message displayed in the problematic area.</param>
        public static void DisplaySpriteRendererRequirement(GameObject targetGameObject, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplaySpriteRendererRequirement"))
                return;

            SpriteRenderer spriteRenderer = targetGameObject.GetComponent<SpriteRenderer>();

            if (spriteRenderer == null)
            {
                string errorCode = GetErrorCode(targetGameObject, "MISSING_SPRITE_RENDERER", "SpriteRenderer");

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);

                if (GUILayout.Button("Create SpriteRenderer"))
                {
                    targetGameObject.AddComponent<SpriteRenderer>();
                }

                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        /// <summary>
        /// Displays a Problematic Area that notifies the user of the Tag Requirment.
        /// </summary>
        /// <param name="targetGameObject">The target GameObject that Requires a specific Tag.</param>
        /// <param name="requiredTag">The Required Tag.</param>
        /// <param name="errorType">The Error type that is Created from this lacking the requirement.</param>
        /// <param name="message">The Message that is displayed in the problematic Area.</param>
        public static void DisplayTagRequirement(GameObject targetGameObject, string requiredTag, ErrorType errorType, string message)
        {
            if (!CheckTargetGameObject(targetGameObject, "DisplayTagRequirement"))
                return;

            if (!targetGameObject.CompareTag(requiredTag))
            {
                string errorCode = GetErrorCode(targetGameObject, "INVALID_PARENT", "parent");

                GeurtsEditorAreaCreator.BeginProblematicArea(errorType, errorCode + message);
                if (GUILayout.Button("Change Tag"))
                {
                    targetGameObject.tag = requiredTag;
                }
                GeurtsEditorAreaCreator.EndArea(true, false, _defaultEndSpacing);
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static bool CheckTargetGameObject(GameObject targetGameObject, string functionName)
        {
            if (targetGameObject == null)
            {
                GeurtsEditorFieldTools.CreateInternalErrorMessage(functionName + ": targetGameObject is null.\nFunction will not run.");
                return false;
            }
            else
                return true;
        }

        private static string GetErrorCode(GameObject targetGameObject, string errorCode, string requirementName)
        {
            string objectName = "";

            if (targetGameObject == null)
                objectName = "Null";
            else
                objectName = targetGameObject.name;

            return errorCode + ": " + objectName + " requires " + requirementName + ". ";
        }

        #endregion Private Methods
    }
}