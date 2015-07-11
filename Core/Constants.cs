// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Constants.cs" company="Robert Logiewa">
//   (C) All rights reserved
// </copyright>
// <summary>
//   Class containing some important constants for the project.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace RpgTools.Core
{
    using System;
    using System.IO;
    using System.Reflection;

    /// <summary>Class containing some important constants for the project.</summary>
    public class Constants
    {
        /// <summary>A string which indicates something is not available.</summary>
        public const string NotAvailable = "N/A";

        /// <summary>String indicating that all options should be used.</summary>
        public const string AllOptions = "All";

        /// <summary>Initialises static members of the <see cref="Constants"/> class.</summary>
        static Constants()
        {
            MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            ExecutionPath = Assembly.GetEntryAssembly().Location;
            CharacterSavePathMyDocuments = Path.Combine(MyDocuments, @"\Character Tool\Characters\");
            SettingsSavePathMyDocuments = Path.Combine(MyDocuments, @"\Character Tool\Settings\");
        }

        /// <summary>Gets the my documents.</summary>
        public static string MyDocuments { get; private set; }

        /// <summary>Gets the execution path.</summary>
        public static string ExecutionPath { get; private set; }

        /// <summary>Gets the save path inside the my documents folder. This is the recommended path.</summary>
        public static string CharacterSavePathMyDocuments { get; private set; }

        /// <summary>Gets the settings save path inside the users my documents folder.</summary>
        public static string SettingsSavePathMyDocuments { get; private set; }
    }
}