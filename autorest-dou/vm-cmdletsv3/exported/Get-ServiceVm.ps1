function Get-ServiceVm {
[CmdletBinding(SupportsShouldProcess=$true, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrder', Mandatory=$true, ValueFromPipeline=$true, HelpMessage='All api calls that return a list will have this metadata block as input
')]
    [Sample.API.Models.IVmListMetadata]
    ${GetEntitiesRequest},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrder', HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [Parameter(ParameterSetName='VmUuid', HelpMessage='SendAsync Pipeline Steps to be appended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Rest.ClientRuntime.SendAsyncStep[]]
    ${HttpPipelineAppend},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrder', HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [Parameter(ParameterSetName='VmUuid', HelpMessage='SendAsync Pipeline Steps to be prepended to the front of the pipeline')]
    [ValidateNotNull()]
    [Microsoft.Rest.ClientRuntime.SendAsyncStep[]]
    ${HttpPipelinePrepend},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrder', HelpMessage='The URI for the proxy server to use')]
    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='The URI for the proxy server to use')]
    [Parameter(ParameterSetName='VmUuid', HelpMessage='The URI for the proxy server to use')]
    [uri]
    ${Proxy},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrder', HelpMessage='Credentials for a proxy server to use for the remote call')]
    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='Credentials for a proxy server to use for the remote call')]
    [Parameter(ParameterSetName='VmUuid', HelpMessage='Credentials for a proxy server to use for the remote call')]
    [ValidateNotNull()]
    [pscredential]
    ${ProxyCredential},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrder', HelpMessage='Use the default credentials for the proxy')]
    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='Use the default credentials for the proxy')]
    [Parameter(ParameterSetName='VmUuid', HelpMessage='Use the default credentials for the proxy')]
    [switch]
    ${ProxyUseDefaultCredentials},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='The filter in FIQL syntax used for the results.')]
    [string]
    ${Filter},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='The kind name')]
    [string]
    ${Kind},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='The number of records to retrieve relative to the offset')]
    [int]
    ${Length},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='Offset from the start of the entity list')]
    [int]
    ${Offset},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='The attribute to perform sort on')]
    [string]
    ${SortAttribute},

    [Parameter(ParameterSetName='VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', HelpMessage='The sort order in which results are returned')]
    [string]
    ${SortOrder},

    [Parameter(ParameterSetName='VmUuid', HelpMessage='The username for authentication')]
    [string]
    ${username},

    [Parameter(ParameterSetName='VmUuid', HelpMessage='The password for authentication')]
    [string]
    ${password},

    [Parameter(ParameterSetName='VmUuid', HelpMessage='Skip the ssl validation')]
    [switch]
    ${SkipSSL},

    [Parameter(ParameterSetName='VmUuid', Mandatory=$true, HelpMessage='The UUID of the entity.')]
    [string]
    ${Uuid})

begin
{
  switch ($PsCmdlet.ParameterSetName) { 

  'VmUuid' {

    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer))
        {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand('NutanixIntentfulAPI.private\Get-ServiceVm_VmUuid', [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters }
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($myInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }

}

  'VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded' {

    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer))
        {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand('NutanixIntentfulAPI.private\Get-ServiceVm_VmsFilterKindLengthOffsetSortAttributeSortOrderExpanded', [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters }
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($myInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }

}

  'VmsFilterKindLengthOffsetSortAttributeSortOrder' {

    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer))
        {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand('NutanixIntentfulAPI.private\Get-ServiceVm_VmsFilterKindLengthOffsetSortAttributeSortOrder', [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters }
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($myInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }

}

  default {

    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer))
        {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand('NutanixIntentfulAPI.private\Get-ServiceVm_VmsFilterKindLengthOffsetSortAttributeSortOrder', [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters }
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($myInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }

}

}
}

process
{
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end
{
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
<#

.ForwardHelpTargetName NutanixIntentfulAPI.private\Get-ServiceVm_VmsFilterKindLengthOffsetSortAttributeSortOrder
.ForwardHelpCategory Cmdlet

#>

}

