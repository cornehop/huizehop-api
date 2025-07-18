using System.ComponentModel.DataAnnotations;

namespace HuizeHop.Api.Library.Database.BaseClasses;

/// <summary>
/// Base class for database entities
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Unique identifier
    /// </summary>
    [Key]
    public Guid Id { get; set; }
}