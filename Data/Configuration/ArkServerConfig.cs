using System.ComponentModel.DataAnnotations;
using System.Net;

namespace ArkMonitor.Data.Configuration;

internal class ArkServerConfig
{
    public const string SectionName = "ArkServer";

    [Required(AllowEmptyStrings = false)]
    public string Host { get; set; } = string.Empty;

    public IPAddress HostIpAddress => IPAddress.Parse(Host);

    [Required, Range(1, 65535)]
    public ushort Port { get; set; }

    [Required(AllowEmptyStrings = false)]
    public string AdminPassword { get; set; } = string.Empty;
}
