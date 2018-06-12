using System.Management.Automation;
using System;

namespace Nutanix {
public class Cluster {
  public string Name;
  public string Uuid;
  public Cluster(dynamic json) {
    Uuid = json.metadata.uuid;
    Name = json.spec.name;
  }
}

[CmdletAttribute(VerbsCommon.Get, "Cluster")]
public class GetClusterCmdlet : Cmdlet {
  protected override void ProcessRecord() {
    WriteObject(GetAllClusters());
  }

  // Grab all VMs.
  // REST: /clusters/list
  public static Cluster[] GetAllClusters() {
    var json = Util.RestCall("/clusters/list", "POST", "{}");
    if (json.entities.Count == 0) {
      return new Cluster[0];
    }
    Cluster[] clusters = new Cluster[json.entities.Count];
    for (int i = 0; i < json.entities.Count; ++i) {
      clusters[i] = new Cluster(json.entities[i]);
    }
    return clusters;
  }
}
}

[CmdletAttribute(VerbsCommunications.Connect, "Cluster")]
public class ConnectClusterCmdlet : Cmdlet {
  [Parameter]
  public string Server { get; set; } = string.Empty;

  [Parameter]
  public string UserName { get; set; } = string.Empty;

  // TODO: note that 'Password' should be the result of
  // 'ConvertTo-SecureString'
  [Parameter]
  public System.Security.SecureString Password { get; set; } =
    new System.Security.SecureString();

  [Parameter]
  public SwitchParameter AcceptInvalidSslCerts
  {
    get { return acceptInvalidSslCerts; }
    set { acceptInvalidSslCerts = value; }
  }
  private bool acceptInvalidSslCerts;

  protected override void ProcessRecord() {
    Connect(Server, UserName, Password, acceptInvalidSslCerts);
  }

  // Save authentication info.
  public static void Connect(
    string server, string username, System.Security.SecureString password,
    bool acceptinvalidsslcerts) {

    if (acceptinvalidsslcerts) {
      Util.TestOnlyIgnoreCerts();
    }
    Util.server = server;
    Util.pscreds = new System.Management.Automation.PSCredential(
      username, password);
  }
}