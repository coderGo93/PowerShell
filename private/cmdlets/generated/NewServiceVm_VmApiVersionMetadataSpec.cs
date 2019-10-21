namespace Nutanix.Powershell.Cmdlets
{
    using System.Management.Automation;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>Implement a variant of the cmdlet New-ServiceVm.</summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"Vm_VmApiVersionMetadataSpec", SupportsShouldProcess = true)]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.IVmIntentResponse))]
    public class NewServiceVm_VmApiVersionMetadataSpec : System.Management.Automation.PSCmdlet, Microsoft.Rest.ClientRuntime.IEventListener
    {
        private Nutanix.Powershell.Models.NutanixCredential NTNXConnection = new Nutanix.Powershell.Models.NutanixCredential();
        /// <summary>The <see cref="System.Threading.CancellationTokenSource" /> for this operation.</summary>
        private System.Threading.CancellationTokenSource _cancellationTokenSource = new System.Threading.CancellationTokenSource();
        /// <summary>Backing field for Body property</summary>
        private Nutanix.Powershell.Models.IVmIntentInput _body;

        /// <summary>An intentful representation of a vm</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "An intentful representation of a vm", ValueFromPipeline = true)]
        public Nutanix.Powershell.Models.IVmIntentInput Body
        {
            get
            {
                return this._body;
            }
            set
            {
                this._body = value;
            }
        }
        /// <summary>The reference to the client API class.</summary>
        public Nutanix.Powershell.NutanixIntentfulAPI Client => Nutanix.Powershell.Module.Instance.ClientAPI;
        /// <summary>SendAsync Pipeline Steps to be appended to the front of the pipeline</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be appended to the front of the pipeline")]
        [System.Management.Automation.ValidateNotNull]
        public Microsoft.Rest.ClientRuntime.SendAsyncStep[] HttpPipelineAppend { get; set; }
        /// <summary>SendAsync Pipeline Steps to be prepended to the front of the pipeline</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "SendAsync Pipeline Steps to be prepended to the front of the pipeline")]
        [System.Management.Automation.ValidateNotNull]
        public Microsoft.Rest.ClientRuntime.SendAsyncStep[] HttpPipelinePrepend { get; set; }
        /// <summary>
        /// <see cref="IEventListener" /> cancellation delegate. Stops the cmdlet when called.
        /// </summary>
        System.Action Microsoft.Rest.ClientRuntime.IEventListener.Cancel => _cancellationTokenSource.Cancel;
        /// <summary><see cref="IEventListener" /> cancellation token.</summary>
        System.Threading.CancellationToken Microsoft.Rest.ClientRuntime.IEventListener.Token => _cancellationTokenSource.Token;
        /// <summary>
        /// The instance of the <see cref="Microsoft.Rest.ClientRuntime.HttpPipeline" /> that the remote call will use.
        /// </summary>
        private Microsoft.Rest.ClientRuntime.HttpPipeline Pipeline { get; set; }
        /// <summary>The URI for the proxy server to use</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The URI for the proxy server to use")]
        public System.Uri Proxy { get; set; }
        /// <summary>Credentials for a proxy server to use for the remote call</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Credentials for a proxy server to use for the remote call")]
        [System.Management.Automation.ValidateNotNull]
        public System.Management.Automation.PSCredential ProxyCredential { get; set; }
        /// <summary>Use the default credentials for the proxy</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Use the default credentials for the proxy")]
        public System.Management.Automation.SwitchParameter ProxyUseDefaultCredentials { get; set; }

        /// <summary>Use credentials for login</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "PSCredential for authentication")]
        public PSCredential PSCredential { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter SkipSSL { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The Nutanix Credential object for authentication")]
        [System.Management.Automation.ValidateNotNull]
        public Nutanix.Powershell.Models.NutanixCredential Credential { get; set; }

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Server address")]
        public string Server { get; set; }

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Server Port, defaults to 9440")]
        public string Port { get; set; }

        /// <summary>The Username for authentication</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "The HTTP protocol, defaults to https")]
        public string Protocol { get; set; }

        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Run the command asynchronous")]
        public System.Management.Automation.SwitchParameter Async { get; set; }

        /// <summary>
        /// (overrides the default BeginProcessing method in System.Management.Automation.PSCmdlet)
        /// </summary>

        protected override void BeginProcessing()
        {
            Module.Instance.SetProxyConfiguration(Proxy, ProxyCredential, ProxyUseDefaultCredentials);
        }
        /// <summary>Creates a duplicate instance of this cmdlet (via JSON serialization).</summary>
        /// <returns>a duplicate instance of NewServiceVm_VmApiVersionMetadataSpec</returns>
        public Nutanix.Powershell.Cmdlets.NewServiceVm_VmApiVersionMetadataSpec Clone()
        {
            var clone = FromJson(this.ToJson(null, Microsoft.Rest.ClientRuntime.SerializationMode.IncludeAll));
            clone.HttpPipelinePrepend = this.HttpPipelinePrepend;
            clone.HttpPipelineAppend = this.HttpPipelineAppend;
            return clone;
        }
        /// <summary>Performs clean-up after the command execution</summary>

        protected override void EndProcessing()
        {
        }
        /// <summary>
        /// Deserializes a <see cref="Carbon.Json.JsonNode" /> into a new instance of this class.
        /// </summary>
        /// <param name="node">a <see cref="Carbon.Json.JsonNode" /> to deserialize from.</param>
        /// <returns>an instance of NewServiceVm_VmApiVersionMetadataSpec.</returns>
        public static Nutanix.Powershell.Cmdlets.NewServiceVm_VmApiVersionMetadataSpec FromJson(Carbon.Json.JsonNode node)
        {
            return node is Carbon.Json.JsonObject json ? new NewServiceVm_VmApiVersionMetadataSpec(json) : null;
        }
        /// <summary>
        /// Creates a new instance of this cmdlet, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this cmdlet.</param>
        /// <returns>
        /// returns a new instance of the <see cref="NewServiceVm_VmApiVersionMetadataSpec" /> cmdlet
        /// </returns>
        public static Nutanix.Powershell.Cmdlets.NewServiceVm_VmApiVersionMetadataSpec FromJsonString(string jsonText) => string.IsNullOrEmpty(jsonText) ? null : FromJson(Carbon.Json.JsonObject.Parse(jsonText));
        /// <summary>Handles/Dispatches events during the call to the REST service.</summary>
        /// <param name="id">The message id</param>
        /// <param name="token">The message cancellation token. When this call is cancelled, this should be <c>true</c></param>
        /// <param name="messageData">Detailed message data for the message event.</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the message is completed.
        /// </returns>
        async System.Threading.Tasks.Task Microsoft.Rest.ClientRuntime.IEventListener.Signal(string id, System.Threading.CancellationToken token, System.Func<Microsoft.Rest.ClientRuntime.EventData> messageData)
        {
            using (NoSynchronizationContext)
            {
                if (token.IsCancellationRequested)
                {
                    return;
                }
                switch (id)
                {
                    case Microsoft.Rest.ClientRuntime.Events.Verbose:
                        {
                            WriteVerbose($"{messageData().Message ?? System.String.Empty}");
                            return;
                        }
                    case Microsoft.Rest.ClientRuntime.Events.Warning:
                        {
                            WriteWarning($"{messageData().Message ?? System.String.Empty}");
                            return;
                        }
                    case Microsoft.Rest.ClientRuntime.Events.Information:
                        {
                            var data = messageData();
                            WriteInformation(data, new[] { data.Message });
                            return;
                        }
                    case Microsoft.Rest.ClientRuntime.Events.Debug:
                        {
                            WriteDebug($"{messageData().Message ?? System.String.Empty}");
                            return;
                        }
                    case Microsoft.Rest.ClientRuntime.Events.Error:
                        {
                            WriteError(new System.Management.Automation.ErrorRecord(new System.Exception(messageData().Message), string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null));
                            return;
                        }
                }
                WriteDebug($"{id}: {messageData().Message ?? System.String.Empty}");
            }
        }
        /// <summary>
        /// Intializes a new instance of the <see cref="NewServiceVm_VmApiVersionMetadataSpec" /> cmdlet class.
        /// </summary>
        public NewServiceVm_VmApiVersionMetadataSpec()
        {
        }
        /// <summary>Constructor for deserialization.</summary>
        /// <param name="json">a <see cref="Carbon.Json.JsonObject" /> to deserialize from.</param>
        internal NewServiceVm_VmApiVersionMetadataSpec(Carbon.Json.JsonObject json)
        {
            // deserialize the contents
            _body = If(json?.PropertyT<Carbon.Json.JsonObject>("Body"), out var __jsonBody) ? Nutanix.Powershell.Models.VmIntentInput.FromJson(__jsonBody) : Body;
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletProcessRecordStart).Wait(); if (((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested) { return; }
            try
            {
                NTNXConnection = (Nutanix.Powershell.Models.NutanixCredential)SessionState.PSVariable.GetValue("Global:NTNXConnection");
                // work
                if (ShouldProcess($"Call remote 'newVm' operation"))
                {
                    using (var asyncCommandRuntime = new Microsoft.Rest.ClientRuntime.PowerShell.AsyncCommandRuntime(this, ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token))
                    {
                        asyncCommandRuntime.Wait(ProcessRecordAsync(), ((Microsoft.Rest.ClientRuntime.IEventListener)this).Token);
                    }
                }
            }
            catch (System.AggregateException aggregateException)
            {
                // unroll the inner exceptions to get the root cause
                foreach (var innerException in aggregateException.Flatten().InnerExceptions)
                {
                    ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletException, $"{innerException.GetType().Name} - {innerException.Message} : {innerException.StackTrace}").Wait(); if (((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested) { return; }
                    // Write exception out to error channel.
                    WriteError(new System.Management.Automation.ErrorRecord(innerException, string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null));
                }
            }
            catch (System.Exception exception)
            {
                ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletException, $"{exception.GetType().Name} - {exception.Message} : {exception.StackTrace}").Wait(); if (((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested) { return; }
                // Write exception out to error channel.
                WriteError(new System.Management.Automation.ErrorRecord(exception, string.Empty, System.Management.Automation.ErrorCategory.NotSpecified, null));
            }
        }
        /// <summary>Performs execution of the command, working asynchronously if required.</summary>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        protected async System.Threading.Tasks.Task ProcessRecordAsync()
        {
            using (NoSynchronizationContext)
            {
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletGetPipeline); if (((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested) { return; }
                if (this.SkipSSL.ToBool() || !NTNXConnection.IgnoreSSLErrors)
                {
                    Pipeline = Nutanix.Powershell.Module.Instance.CreatePipelineWithProxy(this.MyInvocation.BoundParameters);
                }
                else
                {
                    Pipeline = Nutanix.Powershell.Module.Instance.CreatePipeline(this.MyInvocation.BoundParameters);
                }
                Pipeline.Prepend(HttpPipelinePrepend);
                Pipeline.Append(HttpPipelineAppend);

                if (Credential == null)
                {
                    if (Port == null)
                        Port = NTNXConnection.Port ?? "9440";
                    if (Protocol == null)
                        Protocol = NTNXConnection.Protocol ?? "https";
                    if (Server == null)
                        Server = NTNXConnection.Server ?? "localhost";
                    if (PSCredential == null)
                        PSCredential = NTNXConnection.PSCredential;
                    //build url
                    var url = $"{Protocol}://{Server}:{Port}";
                    Credential = new Nutanix.Powershell.Models.NutanixCredential(url, PSCredential);
                }

                // get the client instance
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletBeforeAPICall); if (((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested) { return; }
                if (this.Async.ToBool())
                {
                    await this.Client.NewVm(Body, onAccepted, onDefault, this, Pipeline, Credential);
                }
                else
                {
                    await this.Client.NewVm_Sync(Body, onAccepted, onDefault, onOK, onNotFound, this, Pipeline, Credential);
                }
                await ((Microsoft.Rest.ClientRuntime.IEventListener)this).Signal(Microsoft.Rest.ClientRuntime.Events.CmdletAfterAPICall); if (((Microsoft.Rest.ClientRuntime.IEventListener)this).Token.IsCancellationRequested) { return; }
            }
        }
        /// <summary>Interrupts currently running code within the command.</summary>

        protected override void StopProcessing()
        {
            ((Microsoft.Rest.ClientRuntime.IEventListener)this).Cancel();
            base.StopProcessing();
        }
        /// <summary>
        /// Serializes the state of this cmdlet to a <see cref="Carbon.Json.JsonNode" /> object.
        /// </summary>
        /// <param name="container">The <see cref="Carbon.Json.JsonObject"/> container to serialize this object into. If the caller
        /// passes in <c>null</c>, a new instance will be created and returned to the caller.</param>
        /// <param name="serializationMode">Allows the caller to choose the depth of the serialization. See <see cref="Microsoft.Rest.ClientRuntime.SerializationMode"/>.</param>
        /// <returns>
        /// a serialized instance of <see cref="NewServiceVm_VmApiVersionMetadataSpec" /> as a <see cref="Carbon.Json.JsonNode" />.
        /// </returns>
        public Carbon.Json.JsonNode ToJson(Carbon.Json.JsonObject container, Microsoft.Rest.ClientRuntime.SerializationMode serializationMode)
        {
            // serialization method
            container = container ?? new Carbon.Json.JsonObject();
            AddIf(null != Body ? (Carbon.Json.JsonNode)Body.ToJson(null) : null, "Body", container.Add);
            return container;
        }
        /// <summary>a delegate that is called when the remote service returns 202 (Accepted).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.IVmIntentResponse" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onAccepted(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse> response)
        {
            using (NoSynchronizationContext)
            {
                // onAccepted - response for 202 / application/json
                // (await response) // should be Nutanix.Powershell.Models.IVmIntentResponse
                WriteObject(await response);
            }
        }
        /// <summary>a delegate that is called when the remote service returns 200 (OK).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.IVmIntentResponse" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onOK(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmIntentResponse> response)
        {
            using (NoSynchronizationContext)
            {
                // onOK - response for 200 / application/json
                // (await response) // should be Nutanix.Powershell.Models.IVmIntentResponse
                WriteObject(await response);
            }
        }

        /// <summary>a delegate that is called when the remote service returns 404 (NotFound).</summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.IVmStatus" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onNotFound(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus> response)
        {
            using (NoSynchronizationContext)
            {
                // onNotFound - response for 404 / application/json
                // (await response) // should be Nutanix.Powershell.Models.IVmStatus
                WriteObject(await response);
            }
        }
        /// <summary>
        /// a delegate that is called when the remote service returns default (any response code not handled elsewhere).
        /// </summary>
        /// <param name="responseMessage">the raw response message as an System.Net.Http.HttpResponseMessage.</param>
        /// <param name="response">the body result as a <see cref="Nutanix.Powershell.Models.IVmStatus" /> from the remote call</param>
        /// <returns>
        /// A <see cref="System.Threading.Tasks.Task" /> that will be complete when handling of the method is completed.
        /// </returns>
        private async System.Threading.Tasks.Task onDefault(System.Net.Http.HttpResponseMessage responseMessage, System.Threading.Tasks.Task<Nutanix.Powershell.Models.IVmStatus> response)
        {
            using (NoSynchronizationContext)
            {
                // Error Response : default
                WriteError(new System.Management.Automation.ErrorRecord(new System.Exception($"The service encountered an unexpected result: {responseMessage.StatusCode}"), responseMessage.StatusCode.ToString(), System.Management.Automation.ErrorCategory.InvalidOperation, new { Body }));
            }
        }
    }
}