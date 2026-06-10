using MongoDB.Driver;

public class UsuarioService
{
    private readonly IMongoCollection<Users> _usuarios;

    public UsuarioService(IConfiguration configuration)
    {
        var client = new MongoClient(
            configuration["MongoDB:ConnectionString"]);

        var database = client.GetDatabase(
            configuration["MongoDB:DatabaseName"]);

        _usuarios = database.GetCollection<Users>(
            configuration["MongoDB:UsersCollectionName"]);
    }

    public async Task<List<Users>> ObtenerTodos()
    {
        return await _usuarios.Find(_ => true).ToListAsync();
    }

    public async Task<Users?> Login(
        string usuario,
        string password)
    {
        return await _usuarios.Find(x =>
            x.Usuario == usuario &&
            x.Contraseña == password)
            .FirstOrDefaultAsync();
    }

    public async Task CrearUsuario(Users nuevoUsuario)
    {
        

        await _usuarios.InsertOneAsync(nuevoUsuario);
    }
}