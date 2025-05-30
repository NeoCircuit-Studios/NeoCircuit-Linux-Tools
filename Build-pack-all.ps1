# Define the project paths
$projects = @(
    "C:\.dev\tools\NeoCircuit-Linux-Tools\Core\Core.csproj",
    "C:\.dev\tools\NeoCircuit-Linux-Tools\FSInstall\FSInstall.csproj",
    "C:\.dev\tools\NeoCircuit-Linux-Tools\NeoCircuit.Linux.Tools\NeoCircuit-Linux-Tools.csproj",
    "C:\.dev\tools\NeoCircuit-Linux-Tools\SSHinstall\SSHinstall.csproj",
    "C:\.dev\tools\NeoCircuit-Linux-Tools\WineInstall\WineInstall.csproj"
)

# Set the output destination folder
$outputDir = "C:\.dev\tools\NeoCircuit-Linux-Tools\Builds"

# Ensure output folder exists
if (-not (Test-Path $outputDir)) {
    New-Item -ItemType Directory -Path $outputDir | Out-Null
}

# Process each project
foreach ($proj in $projects) {
    Write-Host "Publishing: $proj"

    # Run dotnet publish
    dotnet publish $proj `
        -c Release `
        -r linux-x64 `
        --self-contained true `
        -p:PublishSingleFile=true `
        -p:PublishTrimmed=true `
        -p:StripSymbols=true `
        -o "$outputDir"

    # Get the project directory
    $projDir = Split-Path $proj

    # Remove bin\Release to clean up
    $releaseDir = Join-Path $projDir "bin\Release"
    if (Test-Path $releaseDir) {
        Remove-Item -Recurse -Force -Path $releaseDir
        Write-Host "Deleted: $releaseDir"
    }
}

Write-Host "All projects published to: $outputDir"
