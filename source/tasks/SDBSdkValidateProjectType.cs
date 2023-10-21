/***********************************************************************************************************************
* Repository: https://github.com/simplexidev/sdbuildsdk                                                                *
* Package:    SimplexiDev.Build.Sdk                                                                                    *
* File:       /source/SDBSdkValidateProjectType.cs                                                                     *
* License:    https://github.com/simplexidev/sdbuildsdk/blob/main/LICENSE.md                                           *
***********************************************************************************************************************/

using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

using System;

namespace SimplexiDev.Build.Tasks
{
    public sealed class SDBSdkValidateProjectType : Task
    {
        [Required]
        public string ProjectType { get; set; }

        public override bool Execute()
        {
            return Enum.TryParse(ProjectType, out ProjectType _);
        }
    }
}