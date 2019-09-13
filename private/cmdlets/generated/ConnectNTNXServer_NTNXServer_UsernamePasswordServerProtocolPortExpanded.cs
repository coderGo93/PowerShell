namespace Nutanix.Powershell.ModelCmdlets
{
    using System.Management.Automation;
    using System.Collections.Generic;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="Disk" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet("Connect", @"NTNXServer_UsernamePasswordServerProtocolPortExpanded")]
    [System.Management.Automation.OutputType(typeof(Nutanix.Powershell.Models.NutanixCredential))]
    public class ConnectNTNXServer_UsernamePasswordServerProtocolPortExpanded : System.Management.Automation.PSCmdlet
    {

        private string _server;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Server
        {
            set
            {
                _server = value;
            }
            get
            {
                return _server;
            }
        }

        private string _port;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Port
        {
            set
            {
                _port = value;
            }
            get
            {
                return _port;
            }
        }

        private string _protocol;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string Protocol
        {
            set
            {
                _protocol = value;
            }
            get
            {
                return _protocol;
            }
        }

        private Nutanix.Powershell.Models.NutanixCredential _credential;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public Nutanix.Powershell.Models.NutanixCredential Credential
        {
            set
            {
                _credential = value;
            }
            get
            {
                return _credential;
            }
        }


        private bool _skip_ssl;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter IgnoreSSLErrors { get; set; }

        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            if (Protocol == null)
                Protocol = _credential.Protocol ?? "https";
            if (IgnoreSSLErrors == null)
                IgnoreSSLErrors = false;
            if (Port == null)
                Port = _credential.Port ?? "9440";
            if (Server == null)
                Server = _credential.Server ?? "";
            _credential.Protocol = Protocol;
            _credential.Port = Port;
            _credential.Server = Server;
            SessionState.PSVariable.Set("Global:NTNXConnection", _credential);
            SessionState.PSVariable.Set("Global:IgnoreSSLErrors", IgnoreSSLErrors);

            WriteObject(_credential);
        }
    }
}
