# SimplexiDev.Build.Sdk

This repository contains various MSBuild properties, targets, default items, and tasks that help make .NET-based multi-project repositories cleaner and tidier.

## Property Reference

| Property Name               | Description |
| --------------------------- | ----------- |
| EnableCIBuilds            | Indicates if continuous integration (CI) builds are enabled.\r\nThe default value for this property is `true`. |
| InferCIBuildDetails       | Indicates that build details, including the build host name, git branch, PR number, and build number from the build host directly (via environment variables).\r\nIf this property is set to `false`, the properties `CIBuildHost`, `CIBuildNumber`, `CIBranchName`, and optionally `CIPullNumber` should be provided via the command-line when building (on the host only).\r\nThe default value for this property is `true`. |
| CIBuildHost               | The build host that is currently being used to build the project.\r\nThis property must be set via the command-line on a build host when the `EnableCIBuilds` property is `true` and the `InferCIBuildDetails` property is `false`. |
| CIBuildNumber             | The build number provided by the build host.\r\nThis property must be set via the command-line on a build host when the `EnableCIBuilds` property is `true` and the `InferCIBuildDetails` property is `false` |
| CIBranchName              | The branch name of the repository being built.\r\nThis property must be set via the command-line on a build host when the `EnableCIBuilds` property is `true` and the `InferCIBuildDetails` property is `false` |
| CIPullNumber              | The pull request number of the current build.\r\nThis property should be set via the command-line on a build host when the `EnableCIBuilds` property is `true`, the `InferCIBuildDetails` property is `false`, and the current build is from a pull request. |
| IsInferredCIBuild         | Indicates if the build details were inferred by the host. If set to `false`, the properties were set via command-line and were not inferred. |
| IsCIBuild                 | Indicated whether this build is being built on a build host via CI. |
| RepositoryOwner           | The name of the author/owner of the repository. This should be a single name. This property has no default value and must be set or a build error will occur. |
| RepositoryName            | The name of the repository. This property has no default value and must be set or a build error will occur. |
| RepositoryCreationYear    | The year the repository was created. This is used for the `Copyright` property. |
| RepositoryNamespace       | The root namespace used by all projects in the repository. This property has no default value and must be set or a build error will occur. |
| RepositoryVersion         | The global version of all packages in the repository. This property has no default value and must be set or a build error will occur. |
| RepositoryBaselineVersion | The baseline version of all projects in the repository. This is used by the `PackageValidationBaselineVersion` property. This property has no default value and must be set or a build error will occur. |
| RepositoryRootPath        | The root path of the repository. This property has no default value and must be set or a build error will occur. |
| RepositoryBuildPath       | The common build path for all projects in this repository. Defaults to a folder named `.build` in the repository root. |
| RepositorySourcesPath     | The common sources path containing all projects in the repository. Defaults to a folder named `sources` in the repository root. |
| ProjectType               | The type of project. This property is automatically set depending on the name of the project. Supported values are: `Library`, `Tests`, `Tool`, `Generator`, `App`, and `Sdk`. |

## Examle Usage

This section will be updated soon once the SDK is stable enough to use itself.