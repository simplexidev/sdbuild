# SDMSBuild

This repository contains various MSBuild properties, targets, and tasks that help make SimplexiDev projects work how we want.

## Getting Started

Fork the template repository [`SDRepoTemplate`](https://github.com/simplexidev/sdrepotempate), and you're all setup. Just add any overrides to the root `Directory.Build.props` file, and start creating projects.

For documentation about the properties, targets, and tasks included in this repository, view the respective files for in-line documentation. Most files have a property that can be set include or exclude specific files to allow use of a subset of features.

## Roadmap

- Add SourceLink support for GitHub


## Documentation

### `ContinuousIntegration.props`

| Property | Description |
| -------- | ----------- |
| `SDContinuousInegrationPropsImported` | Indicates whether the `SimplexiDev.Bild.ContinuousIntegration.props` file was imported.<br/><br/>This property cannot be overridden. |
| `SDCIBuildService` | The build service that is currently running.<br/><br/>This property should not be overridden in your project, but rather used as command-line options via build scripts (like GitHub Actions). |
| `SDCIBuildNumber` | The build number of the currently running job.<br/><br/>This property should not be overridden in your project, but rather used as command-line options via build scripts (like GitHub Actions). |
| `SDCIBuildBranch` | The branch that is currently being built.<br/><br/>This property should not be overridden in your project, but rather used as command-line options via build scripts (like GitHub Actions). |

#### Overridden SDK Properties

| Property | Description |
| -------- | ----------- |
| `ContinuousIntegrationBuild` | This property is set to `true` if the `SDCIBuildServive` and `SDBuildBranch` values are overridden and the `SDUseGitHubSourceLink` property is `true`. |