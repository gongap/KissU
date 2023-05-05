# publishFolder
$publishFolder= $args[0]

# Paths
$rootFolder = (Get-Item -Path "./" -Verbose).FullName
if ([String]::IsNullOrEmpty($publishFolder)) {
    $publishFolder = Join-Path $rootFolder "output/publish"
    $hasPath = Test-Path($publishFolder)
    if (-Not $hasPath) {
        new-item -path $rootFolder -name "output/publish" -type directory
    }
}
Write-Host ("Publish Output " + $publishFolder)

# List of projects
$projects = (
    "tool/KissU.MseServer",
    "tool/KissU.Workbench"
)

# Rebuild solution
Set-Location $rootFolder
& dotnet restore -s http://package.kissu.com/nuget/nuget/v3/index.json
Write-Host ("Restore Completed ! ")
# Publish all projects
foreach($project in $projects) {
    $projectFolder = Join-Path $rootFolder $project
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    $outputPath = Join-Path $publishFolder ("/" + $projectName)
    Set-Location $projectFolder
    Write-Host ("Publish " + $projectName)
    & dotnet publish ($projectName + ".csproj ") --configuration Release --output $outputPath  --nologo --verbosity quiet --no-restore

    $issProject = (Get-Item *.iss).Name
    if (![string]::IsNullOrEmpty($issProject))
    {
        Write-Host ("Setup " + $projectName)
        $programPath = Join-Path $outputPath ($projectName + ".exe")
        $version = (Get-Command $programPath).FileVersionInfo.ProductVersion
        & iscc /Qp /DVersion=$version $issProject
    }
}

Write-Host ("Publish Completed ! ")

# Go back to the root folder
Set-Location $rootFolder
