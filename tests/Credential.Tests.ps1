# Pull In Mocking Support
. "$PSScriptRoot/HttpPipelineMocking.ps1"



Describe 'New-NutanixCredential Tests' {
    It "Should contain the correct fields" {
        $credential = New-NutanixCredential -Username admin -Password Password -ServerUri https://localhost:9440
        $credential.Username | Should -be "admin"
        $credential.Port | Should -be "9440"
        $credential.Server | Should -be "localhost"
        $credential.Protocol | Should -be "https"
        $credential.Uri.ToString() | Should -be "https://localhost:9440/"

        Connect-NTNXServer -Credential $credential

        $env:NutanixServer | Should -be "localhost"
        $env:NutanixUsername | Should -be "admin"
        $env:NutanixPassword | Should -be "Password"
    }
}

Describe "Connect-NTNXServer Tests" {
    It "Should set the credentials to the Session PSVariable" {
        $credential = New-NutanixCredential -Username admin -Password Password -ServerUri https://localhost:9440

        Connect-NTNXServer -Credential $credential

        $env:NutanixServer | Should -be "localhost"
        $env:NutanixUsername | Should -be "admin"
        $env:NutanixPassword | Should -be "Password"
    }
}

