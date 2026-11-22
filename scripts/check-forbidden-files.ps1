param(
    [ValidateSet('staged', 'tracked')]
    [string]$Mode = 'staged'
)

$ErrorActionPreference = 'Stop'
$root = (git rev-parse --show-toplevel).Trim()
if ($LASTEXITCODE -ne 0 -or -not $root) {
    Write-Error 'Not inside a git repository.'
    exit 2
}

$files = if ($Mode -eq 'tracked') {
    git -C $root -c core.quotepath=false ls-files
} else {
    git -C $root -c core.quotepath=false diff --cached --name-only --diff-filter=ACMR
}

if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }

$forbidden = @()
foreach ($file in $files) {
    if ([string]::IsNullOrWhiteSpace($file)) { continue }
    $norm = $file.Replace('\', '/')
    if ($norm -imatch '\.dll$' -or
        $norm -imatch '\.tpk$' -or
        $norm -imatch '(^|/)obj/' -or
        $norm -imatch '(^|/)bin/' -or
        $norm -imatch '(^|/)PublicizedAssemblies/') {
        $forbidden += $norm
    }
}

if ($forbidden.Count -gt 0) {
    Write-Error ("Forbidden file(s) detected ($Mode):`n - " + ($forbidden -join "`n - "))
    exit 1
}

Write-Host "Forbidden file check ($Mode) passed: 0 violations."
exit 0
