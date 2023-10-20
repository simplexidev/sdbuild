
$SlnGenVersion = "10.4.0"
$RepoPath = Split-Path -Parent $MyInvocation.MyCommand.Definition

# Error Strings ####################################################################################
$errorRepoPathMustBeValid = "The parameter '-RepoPath' must be a valid directory."
$errorRepoPathMustBeGitRepo = "The parameter '-RepoPath' must be a git repository."
$errorInstallingSlnGen = "An error occured while installing dotnet slngen."

# Script Setup #####################################################################################
if (-Not (Test-Path $RepoPath))
{
Write-Output $errorRepoPathMustBeValid
Exit 1
}
if (-Not (Test-Path (Join-Path $RepoPath ".git")))
{
Write-Output $errorRepoPathMustBeGitRepo
Exit 1
}

Set-Location $RepoPath

# Install `dotnet slngen` ##########################################################################

$slngenInstalled = Invoke-Expression "dotnet tool list -g | Select-String -Pattern ""slngen"" -Context 0,1" -ErrorAction SilentlyContinue
if (-not $toolInstalled)
{
    Write-Output "Installing dotnet slngen..."
    Invoke-Expression "dotnet tool install -g slngen --version 10.4.0"
    if ($LastExitCode -ne 0)
    {
        Write-Output $errorInstallingSlnGen
        Exit $LastExitCode
    }
}

# Generate Solution File ###########################################################################

$projectFiles = Join-Path $RepoPath "source" "SimplexiDev.Build.Sdk.csproj"
$solutionFile = Join-Path $RepoPath "source" "sdbuildsdk.sln"
Invoke-Expression "dotnet tool slngen $projectFiles --solutionfile $solutionFile"