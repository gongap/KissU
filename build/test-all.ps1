$rootFolder = (Get-Item -Path "../" -Verbose).FullName

$solutionPath = $rootFolder
Set-Location $solutionPath
dotnet test --no-build --no-restore --collect:"XPlat Code Coverage"
if (-Not $?) {
    Write-Host ("Test failed for the solution: " + $solutionPath)
    Set-Location $rootFolder
    exit $LASTEXITCODE
}

Set-Location $rootFolder

