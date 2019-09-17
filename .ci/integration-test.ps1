#!/usr/bin/pwsh
param(
    [String]$passwd,
    [String]$user,
    [String]$port=9440,
    [String]$server,
    [String]$protocol="https",
    [String]$clusterID
)

Import-Module -Name .\Nutanix.psd1

$secureStringPwd = $passwd | ConvertTo-SecureString -AsPlainText -Force
$creds = New-Object System.Management.Automation.PSCredential -ArgumentList $user, $secureStringPwd

$credentials = New-NutanixCredential -PSCredential $creds  -server $server

Connect-NTNXServer -Credential $credentials
$env:ClusterID = $clusterID  

Invoke-Pester -Path ".\tests\integration\*.Tests.ps1" -CodeCoverage ".\exported\*Subnet*.ps1" 