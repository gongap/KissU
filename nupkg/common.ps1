# Paths
$packFolder = (Get-Item -Path "./" -Verbose).FullName
$rootFolder = Join-Path $packFolder "../"

# List of solutions
$solutions = (
    # "framework",
    # "modules/account",
    # "modules/audit-logging",
    # "modules/background-jobs",
    # "modules/blogging",
    # "modules/client-simulation",
    # "modules/docs",
    # "modules/feature-management",
    # "modules/identity",
    # "modules/identityserver",
    # "modules/permission-management",
    # "modules/setting-management",
    # "modules/tenant-management",
    # "modules/users",
    # "modules/virtual-file-explorer",
	# "modules/blob-storing-database"
)

# List of projects
$projects = (

    # framework
    "framework/src/KissU.Core",
)
