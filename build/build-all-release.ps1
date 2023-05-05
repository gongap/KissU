$rootFolder = (Get-Item -Path "../" -Verbose).FullName

$solutionPath = $rootFolder
Set-Location $solutionPath
dotnet build  --configuration Release
if (-Not $?) {
    Write-Host ("Build failed for the solution: " + $solutionPath)
    Set-Location $rootFolder
    exit $LASTEXITCODE
}

Set-Location $rootFolder

