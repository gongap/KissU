# apiKey
$apiKey = $args[0]

# Paths
$rootFolder = (Get-Item -Path "./" -Verbose).FullName
$packFolder = Join-Path $rootFolder "output"
$hasPath = Test-Path($packFolder)

 if (-Not $hasPath) {
      new-item -path $rootFolder -name "output" -type directory
}
Write-Host ("PackFolder: " + $packFolder)

# List of projects
$projects = (
    "src/KissU.AspNetCore",
    "src/KissU.AspNetCore.Swagger",
    "src/KissU.AspNetCore.Stage",
    "src/KissU.AspNetCore.Kestrel",
    "src/KissU.Codec.MessagePack",
    "src/KissU.Codec.ProtoBuffer",
    "src/KissU.Logging.NLog",
    "src/KissU.Logging.Serilog",
    "src/KissU.ServiceDiscovery.Consul",
    "src/KissU.ServiceDiscovery.Zookeeper",
    "src/KissU.DotNetty",
    "src/KissU.DotNetty.DNS",
    "src/KissU.DotNetty.Http",
    "src/KissU.DotNetty.Mqtt",
    "src/KissU.DotNetty.Udp",
    "src/KissU.DotNetty.WebSocket",
    "src/KissU.Grpc",
    "src/KissU.Thrift",
    "src/KissU.WebSocket",
    "src/KissU.ApiGateWay",
    "src/KissU.Apm.Skywalking",
    "src/KissU.BackgroundServer",
    "src/KissU.Core",
    "src/KissU.Abp",
    "src/KissU.CPlatform",
    "src/KissU.ServiceProxy"
)

# Remove item
Set-Location $packFolder
Remove-Item (Join-Path $packFolder "*.nupkg")

# Rebuild solution
Set-Location $rootFolder
& dotnet restore -s http://package.kissu.com/nuget/nuget/v3/index.json
& dotnet build  --configuration Release

# Create all packages
$i = 0
foreach($project in $projects) {
    $i += 1
    $projectFolder = Join-Path $rootFolder $project
	$projectName = ($project -split '/')[-1]
	
	# Create nuget pack
	Write-Host ("-----===[ $i / " + $projects.length  + " - " + $projectName + " ]===-----")
    Set-Location $projectFolder
    Remove-Item -Force -Recurse (Join-Path $projectFolder "bin/Release")
    & dotnet pack -c Release

    if (-Not $?) {
        Write-Host ("Packaging failed for the project: " + $projectFolder)
        exit $LASTEXITCODE
    }
    
    # Copy nuget package
    $projectName = $project.Substring($project.LastIndexOf("/") + 1)
    $projectPackPath = Join-Path $projectFolder ("/bin/Release/" + $projectName + ".*.nupkg")
    Move-Item -Force $projectPackPath $packFolder
}

# Go back to the pack folder
Set-Location $packFolder

# Publish all packages
$projectPacks = Get-ChildItem  (Join-Path $packFolder "*.nupkg")
foreach($pack in $projectPacks) {
    & dotnet nuget push ($pack) -s http://package.kissu.com/nuget/nuget/v3/index.json --skip-duplicate --api-key "$apiKey"
}

# Go back to the root folder
Set-Location $rootFolder