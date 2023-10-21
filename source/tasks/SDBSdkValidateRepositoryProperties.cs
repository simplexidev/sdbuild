/***********************************************************************************************************************
* Repository: https://github.com/simplexidev/sdbuildsdk                                                                *
* Package:    SimplexiDev.Build.Sdk                                                                                    *
* File:       /source/SDBSdkValidateRepositoryProperties.cs                                                            *
* License:    https://github.com/simplexidev/sdbuildsdk/blob/main/LICENSE.md                                           *
***********************************************************************************************************************/

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System.IO;

namespace SimplexiDev.Build.Tasks
{
    public sealed class SDBSdkValidateRepositoryProperties : Task
    {
        [Required]
        public string RepositoryPath { get; set; }
        [Required]
        public string RepositorySourcesPath { get; set; }
        [Required]
        public string RepositoryName { get; set; }

        public override bool Execute()
        {
            if (string.IsNullOrWhiteSpace(RepositoryPath) || !Directory.Exists(RepositoryPath))
                return false;
            if (!Directory.Exists(Path.Combine(RepositoryPath, ".git")) && !File.Exists(Path.Combine(RepositoryPath, ".git")))
                return false;
            if (string.IsNullOrWhiteSpace(RepositoryName))
                return false;
            if (string.IsNullOrWhiteSpace(RepositorySourcesPath) || !Directory.Exists(RepositorySourcesPath))
                return false;
            return true;
        }
    }
}