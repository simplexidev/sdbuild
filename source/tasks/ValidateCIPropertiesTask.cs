using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System.Collections.Generic;

namespace SimplexiDev.Build.Sdk.Tasks
{
    public class ValidateSDBSDKContinuousIntegrationProperties : Task
    {
        // Required Parameters
        [Required] public string BuildHost { get; set; }
        [Required] public string BuildNumber { get; set; }
        [Required] public string Branch { get; set; }

        // Optional Parameters
        public string PullNumber { get; set; } = string.Empty;

        // Output Parameters
        [Output] public bool ReturnValue { get; set; }

        // Task Action
        public override bool Execute()
        {
            try
            {
                bool retVal = true;
                List<string> validBuildHosts =
                [
                    "GitHub"//,
                    //"GitLab",
                    //"AzurePipelines",
                    //"TravisCI",
                    //"CircleCI",
                    //"AppVeyor"
                ];
                if (string.IsNullOrWhiteSpace(BuildHost) || !validBuildHosts.Contains(BuildHost))
                    retVal = false;
                if (string.IsNullOrWhiteSpace(BuildNumber) || !ulong.TryParse(BuildNumber, out ulong _))
                    retVal = false;
                if (string.IsNullOrWhiteSpace(Branch) || Branch.Contains(" "))
                    retVal = false;
                if (!string.IsNullOrWhiteSpace(PullNumber) && !uint.TryParse(PullNumber, out uint _))
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
