using System.ComponentModel;

namespace ReportsBLL.Models.Problems;

public enum EProblemState
{
    [Description("Open")] Open = 1,
    [Description("Active")] Active = 2,
    [Description("Closed")] Closed = 3
}