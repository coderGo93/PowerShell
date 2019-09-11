namespace Nutanix.Powershell.ModelCmdlets
{
    using System.Management.Automation;
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="Disk" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.Set, @"ConnectNTNXServer_UsernamePasswordServerProtocolPortExpanded")]
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

        private PSCredential _PSCredential;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public PSCredential PSCredential
        {
            set
            {
                _PSCredential = value;
            }
            get
            {
                return _PSCredential;
            }
        }


        private bool _skip_ssl;
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, DontShow = true, HelpMessage = "Skip the ssl validation")]
        public System.Management.Automation.SwitchParameter SkipSSL { get; set; }

        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            
        }
    }
}