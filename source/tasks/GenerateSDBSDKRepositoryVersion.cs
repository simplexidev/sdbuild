using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace SimplexiDev.Build.Tasks
{
    public sealed class GenerateSDBSDKRepositoryVersion : Task
    {
        // Required Parameters
        [Required] public bool IsCIBuild { get; set; }
        [Required] public string RepositoryVersion { get; set; }
        [Required] public string BranchName { get; set; }
        [Required] public string BuildNumber { get; set; }

        // Optional Parameters
        public string PullNumber { get; set; } = string.Empty;

        // Output Parameters
        [Output] public string GeneratedRepositoryVersion { get; set; }

        // Task Action
        public override bool Execute()
        {
            try
            {
                string retVal = RepositoryVersion;
                if (IsCIBuild)
                {
                    if (!string.IsNullOrWhiteSpace(PullNumber) && uint.TryParse(PullNumber, out uint pullNumber))
                        retVal += $"-b{BuildNumber}.pull{pullNumber}";
                    else
                        retVal += $"-b{BuildNumber}.{BranchName.Replace("/", ".")}";
                }
                else
                {
                    retVal += "-local";
                }
                GeneratedRepositoryVersion = retVal;
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
