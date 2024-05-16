using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System;

namespace SimplexiDev.Build.Tasks
{
    //TODO: The `Namespace` parameter needs to be checked to ensure it is valid as a namespace (only alpha-numeric charaters, can be segmented by using a `.`, each segment cannot start with a number). 
    public class ValidateSDBSDKRepositoryProperties : Task
    {
        // Required Parameters
        [Required] public string Owner { get; set; }
        [Required] public string RepoName { get; set; }
        [Required] public string Namespace { get; set; }
        [Required] public string Version { get; set; }
        [Required] public string BaselineVersion { get; set; }

        // Output Parameters
        [Output] public bool ReturnValue { get; set; }

        // Task Action
        public override bool Execute()
        {
            try
            {
                bool retVal = true;
                if (string.IsNullOrWhiteSpace(Owner) || Owner.Contains(" "))
                    retVal = false;
                if (string.IsNullOrWhiteSpace(RepoName) || RepoName.Contains(" "))
                    retVal = false;
                if (string.IsNullOrWhiteSpace(Namespace))
                    retVal = false;
                if (string.IsNullOrWhiteSpace(Version) || !System.Version.TryParse(Version, out Version _))
                    retVal = false;
                if (string.IsNullOrWhiteSpace(BaselineVersion) || !System.Version.TryParse(BaselineVersion, out Version _))
                    retVal = false;

                ReturnValue = retVal;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
