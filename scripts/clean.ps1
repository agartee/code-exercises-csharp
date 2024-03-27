$rootDir = (get-item $PSScriptRoot).Parent.FullName

$binDir = "$rootDir\.bin"
if (Test-Path -Path $binDir) {
  Write-Host "Removing $binDir..." -ForegroundColor Blue
  Remove-Item -Recurse -Force "$binDir"
}

$testCoverageDir = "$rootDir\.test-coverage"
if (Test-Path -Path $testCoverageDir) {
  Write-Host "Removing $testCoverageDir..." -ForegroundColor Blue
  Remove-Item -Recurse -Force "$testCoverageDir"
}
