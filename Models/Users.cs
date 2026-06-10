using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using Prueba2.Models;

public class Users
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [Required]
    public string? Correo { get; set; }
    [Required]
    public string? Usuario { get; set; }
    [Required]
    public string? Contraseña { get; set; }
}
