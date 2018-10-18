namespace Sample.API.ModelCmdlets
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// Cmdlet to create an in-memory instance of the <see cref="VmRecoveryPointMetadata" /> object.
    /// </summary>
    [System.Management.Automation.Cmdlet(System.Management.Automation.VerbsCommon.New, @"VmRecoveryPointMetadataObject")]
    [System.Management.Automation.OutputType(typeof(Sample.API.Models.IVmRecoveryPointMetadata))]
    public class NewVmRecoveryPointMetadataObject : System.Management.Automation.PSCmdlet
    {
        /// <summary>Backing field for <see cref="VmRecoveryPointMetadata" /></summary>
        private Sample.API.Models.IVmRecoveryPointMetadata _vmRecoveryPointMetadata = new Sample.API.Models.VmRecoveryPointMetadata();
        /// <summary>Categories for the vm_recovery_point</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Categories for the vm_recovery_point")]
        public System.Collections.Generic.IDictionary<string,string> Categories
        {
            set
            {
                _vmRecoveryPointMetadata.Categories = value;
            }
        }
        /// <summary>UTC date and time in RFC-3339 format when vm_recovery_point was created</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "UTC date and time in RFC-3339 format when vm_recovery_point was created")]
        public System.DateTime CreationTime
        {
            set
            {
                _vmRecoveryPointMetadata.CreationTime = value;
            }
        }
        /// <summary>The kind name</summary>
        public string Kind
        {
            set
            {
                _vmRecoveryPointMetadata.Kind = value;
            }
        }
        /// <summary>UTC date and time in RFC-3339 format when vm_recovery_point was last updated</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "UTC date and time in RFC-3339 format when vm_recovery_point was last updated")]
        public System.DateTime LastUpdateTime
        {
            set
            {
                _vmRecoveryPointMetadata.LastUpdateTime = value;
            }
        }
        /// <summary>vm_recovery_point name</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "vm_recovery_point name")]
        public string Name
        {
            set
            {
                _vmRecoveryPointMetadata.Name = value;
            }
        }
        /// <summary>The kind name</summary>
        public string ProjectReferenceKind
        {
            set
            {
                _vmRecoveryPointMetadata.ProjectReference = _vmRecoveryPointMetadata.ProjectReference ?? new Sample.API.Models.ProjectReference();
                _vmRecoveryPointMetadata.ProjectReference.Kind = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string ProjectReferenceName
        {
            set
            {
                _vmRecoveryPointMetadata.ProjectReference = _vmRecoveryPointMetadata.ProjectReference ?? new Sample.API.Models.ProjectReference();
                _vmRecoveryPointMetadata.ProjectReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public string ProjectReferenceUuid
        {
            set
            {
                _vmRecoveryPointMetadata.ProjectReference = _vmRecoveryPointMetadata.ProjectReference ?? new Sample.API.Models.ProjectReference();
                _vmRecoveryPointMetadata.ProjectReference.Uuid = value;
            }
        }
        /// <summary>Hash of the spec. This will be returned from server.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Hash of the spec. This will be returned from server.")]
        public string SpecHash
        {
            set
            {
                _vmRecoveryPointMetadata.SpecHash = value;
            }
        }
        /// <summary>Version number of the latest spec.</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "Version number of the latest spec.")]
        public int SpecVersion
        {
            set
            {
                _vmRecoveryPointMetadata.SpecVersion = value;
            }
        }
        /// <summary>The kind name</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "The kind name")]
        public string UserReferenceKind
        {
            set
            {
                _vmRecoveryPointMetadata.OwnerReference = _vmRecoveryPointMetadata.OwnerReference ?? new Sample.API.Models.UserReference();
                _vmRecoveryPointMetadata.OwnerReference.Kind = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "HELP MESSAGE MISSING")]
        public string UserReferenceName
        {
            set
            {
                _vmRecoveryPointMetadata.OwnerReference = _vmRecoveryPointMetadata.OwnerReference ?? new Sample.API.Models.UserReference();
                _vmRecoveryPointMetadata.OwnerReference.Name = value;
            }
        }
        /// <summary>HELP MESSAGE MISSING</summary>
        [System.Management.Automation.Parameter(Mandatory = true, HelpMessage = "HELP MESSAGE MISSING")]
        public string UserReferenceUuid
        {
            set
            {
                _vmRecoveryPointMetadata.OwnerReference = _vmRecoveryPointMetadata.OwnerReference ?? new Sample.API.Models.UserReference();
                _vmRecoveryPointMetadata.OwnerReference.Uuid = value;
            }
        }
        /// <summary>vm_recovery_point uuid</summary>
        [System.Management.Automation.Parameter(Mandatory = false, HelpMessage = "vm_recovery_point uuid")]
        public string Uuid
        {
            set
            {
                _vmRecoveryPointMetadata.Uuid = value;
            }
        }
        /// <summary>Performs execution of the command.</summary>

        protected override void ProcessRecord()
        {
            _vmRecoveryPointMetadata.ProjectReference.Kind = "project";
            _vmRecoveryPointMetadata.Kind = "metadata";
            _vmRecoveryPointMetadata.OwnerReference.Kind = "owner";
            WriteObject(_vmRecoveryPointMetadata);
        }
    }
}