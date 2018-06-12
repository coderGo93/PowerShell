// Purpose: Images (image service) source for 'Nutanix.PowerShell.SDK'
// Author: Nutanix
// Copyright: Nutanix, 2018
// Owner: PowerShell@nutanix.com
// Maintainer(s):
//   Jon Kohler  (Nutanix, JonKohler)
//   Alex Guo    (Nutanix, mallochine)

using System;
using System.Management.Automation;

using Newtonsoft.Json;

namespace Nutanix
{
  public class Image
  {
    public string Name { get; set; }
    public string Id { get; set; }

    // 'Uid' is VMware's equivalent field for Nutanix's Uuid.
    public string Uid;
    public string Uuid;
    public dynamic Json { get; set; }

    // TODO Mtu, NumPorts, ExtensionData, NumPortsAvailable, Key, Nic, VMHostId,
    // VMHost, VMHostUid, Nic

    public Image(dynamic Json)
    {
      // Special property 'Json' stores the original Json.
      this.Json = Json;
      this.Json.Property("status").Remove();
      this.Json.api_version = "3.1";

      Name = Json.spec.name;
      Uuid = Json.metadata.uuid;
      Uid = Uuid;
    }
  }

  [CmdletAttribute(VerbsCommon.New, "Image")]
  public class NewImageCmdlet : Cmdlet
  {
    [Parameter]
    public string Name { get; set; } = string.Empty;

    [Parameter]
    public string URL { get; set; } = string.Empty;

    [Parameter]
    public string Description { get; set; } = string.Empty;

    [Parameter]
    public SwitchParameter RunAsync
    {
      get { return runAsync; }
      set { runAsync = value; }
    }
    private bool runAsync;

    protected override void ProcessRecord()
    {
      var url = "/images";
      var method = "POST";
      var str = @"{
      ""api_version"": ""3.0"",
      ""metadata"": {
        ""kind"": ""image"",
        ""name"": """ + Name + @"""
      },
      ""spec"": {
        ""description"": """ + Description + @""",
        ""name"": """ + Name + @""",
        ""resources"": {
          ""image_type"": ""DISK_IMAGE"",
          ""source_uri"": """ + URL + @"""
        }
      }
    }";

      WriteDebug(Util.RestCallTrace(url, method, str));
      var task = Task.FromUuidInJson(Util.RestCall(url, method, str));
      if (runAsync)
      {
        WriteObject(task);
      }
      else
      {
        WriteObject(task.Wait());
      }
    }
  }

  [CmdletAttribute(VerbsCommon.Get, "Image")]
  public class GetImageCmdlet : Cmdlet
  {
    [Parameter]
    public string Uuid { get; set; } = string.Empty;

    [Parameter]
    public string Name { get; set; } = string.Empty;

    [Parameter]
    public int? Max { get; set; }

    protected override void ProcessRecord()
    {
      if (!string.IsNullOrEmpty(Uuid))
      {
        WriteObject(GetImageByUuid(Uuid));
        return;
      }

      var images = GetAllImages(BuildRequestBody());
      CheckResult(images);
      WriteObject(images);
    }

    // Given the parameters, build request body for '/images/list'.
    public dynamic BuildRequestBody()
    {
      dynamic Json = JsonConvert.DeserializeObject("{}");
      if (Max != null)
      {
        Json.length = Max;
      }
      if (!string.IsNullOrEmpty(Name))
      {
        Json.filter = "name==" + Name;
      }
      return Json;
    }

    public void CheckResult(Image[] images)
    {
      return; // TODO: consider whether throwing duplicate exception is good idea.
      if (!string.IsNullOrEmpty(Name) && images.Length > 1)
      {
        throw new Exception("Found duplicate images");
      }
    }

    public static Image GetImageByUuid(string uuid)
    {
      // TODO: validate using UUID regexes that 'uuid' is in correct format.
      var Json = Util.RestCall("/images/" + uuid, "GET", string.Empty /* requestBody */ );
      return new Image(Json);
    }

    public static Image[] GetImagesByName(string name)
    {
      return GetAllImages("{\"filter\": \"name==" + name + "\"}");
    }

    public static Image[] GetAllImages(dynamic JsonReqBody)
    {
      return GetAllImages(JsonReqBody.ToString());
    }

    public static Image[] GetAllImages(string reqBody)
    {
      return Util.FromJson<Image>(Util.RestCall("/images/list", "POST", reqBody),
        (Func<dynamic, Image>)(j => new Image(j)));
    }
  }

  [CmdletAttribute(VerbsCommon.Remove, "Image")]
  public class DeleteImageCmdlet : Cmdlet
  {
    [Parameter]
    public string Uuid { get; set; } = string.Empty;

    protected override void ProcessRecord()
    {
      if (!string.IsNullOrEmpty(Uuid))
      {
        // TODO: WriteObject Task
        DeleteImageByUuid(Uuid);
        return;
      }
    }

    public static void DeleteImageByUuid(string uuid)
    {
      // TODO: validate using UUID regexes that 'uuid' is in correct format.
      Util.RestCall("/images/" + uuid, "DELETE", string.Empty /* requestBody */ );
    }
  }

  [CmdletAttribute(VerbsCommon.Set, "Image")]
  public class SetImageCmdlet : Cmdlet
  {
    [Parameter(Mandatory = true, ValueFromPipeline = true)]
    public Image Image { get; set; }

    [Parameter]
    public string Name { get; set; }

    [Parameter]
    public SwitchParameter RunAsync
    {
      get { return runAsync; }
      set { runAsync = value; }
    }
    private bool runAsync;

    protected override void ProcessRecord()
    {
      if (Name != null)
      {
        Image.Json.spec.name = Name;
      }
      Image.Json.api_version = "3.1";
      var task = Task.FromUuidInJson(
        Util.RestCall("/images/" + Image.Uuid, "PUT", Image.Json.ToString()));
      if (runAsync)
      {
        WriteObject(task);
      }
      else
      {
        WriteObject(task.Wait());
      }
    }
  }

}
