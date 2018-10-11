namespace Sample.API.Models
{
    using static Microsoft.Rest.ClientRuntime.Extensions;
    /// <summary>
    /// If this field is set, the guest will be customized using Sysprep. Either unattend_xml or custom_key_values should be provided.
    /// If custom_key_values are provided then the unattended answer file will be generated using these key-value pairs.
    /// </summary>
    public partial class GuestCustomizationStatusSysprep : Sample.API.Models.IGuestCustomizationStatusSysprep
    {
        /// <summary>Backing field for CustomKeyValues property</summary>
        private System.Collections.Generic.IDictionary<string,string> _customKeyValues;

        /// <summary>Generic key value pair used for custom attributes</summary>
        public System.Collections.Generic.IDictionary<string,string> CustomKeyValues
        {
            get
            {
                return this._customKeyValues;
            }
            set
            {
                this._customKeyValues = value;
            }
        }
        /// <summary>Backing field for InstallType property</summary>
        private string _installType;

        /// <summary>
        /// Whether the guest will be freshly installed using this unattend configuration, or whether this unattend configuration
        /// will be applied to a pre-prepared image. Default is "PREPARED".
        /// </summary>
        public string InstallType
        {
            get
            {
                return this._installType;
            }
            set
            {
                this._installType = value;
            }
        }
        /// <summary>Backing field for UnattendXml property</summary>
        private string _unattendXml;

        /// <summary>
        /// This field contains a Sysprep unattend xml definition, as a string. The value must be base64 encoded.
        /// </summary>
        public string UnattendXml
        {
            get
            {
                return this._unattendXml;
            }
            set
            {
                this._unattendXml = value;
            }
        }
        /// <summary>Creates an new <see cref="GuestCustomizationStatusSysprep" /> instance.</summary>
        public GuestCustomizationStatusSysprep()
        {
        }
    }
    /// If this field is set, the guest will be customized using Sysprep. Either unattend_xml or custom_key_values should be provided.
    /// If custom_key_values are provided then the unattended answer file will be generated using these key-value pairs.
    public partial interface IGuestCustomizationStatusSysprep : Microsoft.Rest.ClientRuntime.IJsonSerializable {
        System.Collections.Generic.IDictionary<string,string> CustomKeyValues { get; set; }
        string InstallType { get; set; }
        string UnattendXml { get; set; }
    }
}