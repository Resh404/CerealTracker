using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Protobuf.WellKnownTypes;

namespace CerealAPI.Models;

public class Image
{
    [Key]
    public int ImageId { get; init; }
    public string ImageFilePath { get; init; } = string.Empty;

    // Foreign key property
    public int CerealId { get; init; }
    // Navigation property
    public Cereal Cereal { get; init; }

}
