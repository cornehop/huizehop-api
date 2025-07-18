using System.ComponentModel.DataAnnotations;
using HuizeHop.Api.Library.Database.BaseClasses;

namespace HuizeHop.Api.Library.Database.Entities;

/// <summary>
/// Bank or investment accounts
/// </summary>
public class Account : BaseEntity
{
    /// <summary>
    /// Account name
    /// </summary>
    [StringLength(200)]
    public required string Name { get; set; }
    /// <summary>
    /// IBAN for the account
    /// </summary>
    [StringLength(34)]
    public string? Iban { get; set; }
}