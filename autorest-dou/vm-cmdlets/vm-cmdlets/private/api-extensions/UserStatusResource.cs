namespace Sample.API.Models
{

    /// <summary>User Resource Definition.</summary>
    [System.ComponentModel.TypeConverter(typeof(UserStatusResourceTypeConverter))]
    public partial class UserStatusResource
    {

        /// <summary>
        /// Creates a new instance of <see cref="UserStatusResource" />, deserializing the content from a json string.
        /// </summary>
        /// <param name="jsonText">a string containing a JSON serialized instance of this model.</param>
        /// <returns>an instance of the <see cref="className" /> model class.</returns>
        public static Sample.API.Models.IUserStatusResource FromJsonString(string jsonText) => FromJson(Carbon.Json.JsonNode.Parse(jsonText));
        /// <summary>Serializes this instance to a json string.</summary>
        /// <returns>a <see cref="System.String" /> containing this model serialized to JSON text.</returns>
        public string ToJsonString() => ToJson(null, Microsoft.Rest.ClientRuntime.SerializationMode.IncludeAll)?.ToString();
    }
    /// User Resource Definition.
    [System.ComponentModel.TypeConverter(typeof(UserStatusResourceTypeConverter))]
    public partial interface IUserStatusResource {

    }
}