using UnityEditor;
using UnityEngine;

namespace Geurts.InspectorTools
{
    /// <summary>
    /// This class is used to Create Preformatted sections according to there Content.
    /// </summary>
    public abstract class GeurtsSortedInspector : Editor
    {
        #region Public Fields

        public bool _displayDefaultDebugs = false;

        #endregion Public Fields

        #region Public Methods

        /// <summary>
        /// Use this method to display ToolsContent in the SortedInspector.
        /// </summary>
        public abstract void DisplayDebugToolsContent();

        /// <summary>
        /// Use this method to display NotesContent in the SortedInspector.
        /// </summary>
        public abstract void DisplayNotesContent();

        /// <summary>
        /// Use this method to display SettingsContent in the SortedInspector.
        /// </summary>
        public abstract void DisplaySettingsContent();

        /// <summary>
        /// Use this method to display Content in a Formatted manner.
        /// </summary>
        public virtual void DisplaySortedInspector()
        {
            // Notes.
            GeurtsEditorSectionCreator.MainSectionPresets.BeginNotesSection();
            DisplayNotesContent();
            GeurtsEditorSectionCreator.MainSectionPresets.EndMainSection();

            // Variables.
            GeurtsEditorSectionCreator.MainSectionPresets.BeginVariablesSection();
            DisplaySettingsContent();
            GeurtsEditorSectionCreator.MainSectionPresets.EndMainSection();

            // Debuging.
            GeurtsEditorSectionCreator.MainSectionPresets.BeginDebugToolsSection();
            DisplayDebugToolsContent();
            GeurtsEditorSectionCreator.MainSectionPresets.EndMainSection();
        }

        /// <summary>
        /// Use this section to display Content in a Formatted manner and Display a NameRequirement section.
        /// </summary>
        /// <param name="requiredName">Use this parameter to Notify the User of a NameRequirement</param>
        public virtual void DisplaySortedInspector(string requiredName)
        {
            GeurtsEditorSectionCreator.CreateCustomIdentitySection(((Component)target).gameObject, requiredName);

            DisplaySortedInspector();
        }

        #endregion Public Methods
    }
}