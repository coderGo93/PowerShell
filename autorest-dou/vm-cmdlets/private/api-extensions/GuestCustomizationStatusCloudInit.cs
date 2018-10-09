namespace Sample.API.Models
{

    /// <summary>
    /// If this field is set, the guest will be customized using cloud-init. Either user_data or custom_key_values should be provided.
    /// If custom_key_ves are provided then the user data will be generated using these key-value pairs.
    /// </summary>
    [System.ComponentModel.TypeConverter(typeof(GuestCustomizationStatusCloudInitTypeConverter))]
    public partial class GuestCustomizationStatusCloudInit
    {

        /// <summary>
        /// Creates a new instance of <see cref="GuestCustomizationStatusCloudInit" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Sample.API.Models.IGuestCustomizationStatusCloudInit FromJsonString(string jsonText) => FromJson(Carbon.Json.JsonNode.Parse(jsonText));
        /// <summary>Serializes this instance to a json string.</summary>
        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Rest.ClientRuntime.SerializationMode.IncludeAll)?.ToString();
    }
    /// If this field is set, the guest will be customized using cloud-init. Either user_data or custom_key_values should be provided.
    /// If custom_key_ves are provided then the user data will be generated using these key-value pairs.
    [System.ComponentModel.TypeConverter(typeof(GuestCustomizationStatusCloudInitTypeConverter))]
    public partial interface IGuestCustomizationStatusCloudInit {

    }
}