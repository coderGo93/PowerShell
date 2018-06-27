#
# Module manifest for module 'Nutanix.PowerShell.SDK'
#
# Generated by: Nutanix
#
# Owner: PowerShell@nutanix.com
#
# Maintainer(s):
#   Jon Kohler  (Nutanix, JonKohler)
#   Alex Guo    (Nutanix, mallochine)

$PSDefaultParameterValues.Clear()
Set-StrictMode -Version Latest

#Import-Module (Join-Path -Path $PSScriptRoot -ChildPath Nutanix.PowerShell.SDK.dll)
Import-Module (Join-Path -Path . -ChildPath Nutanix.PowerShell.SDK.dll)

# if (Test-Path -Path "$PSScriptRoot\StartupScripts")
# {
#     Get-ChildItem "$PSScriptRoot\StartupScripts" | ForEach-Object {
#         . $_.FullName
#     }
# }

# $FilteredCommands = @()

### TODO add (# SIG # Begin signature block)