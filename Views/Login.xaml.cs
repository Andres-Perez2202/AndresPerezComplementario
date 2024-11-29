using AndresPerezComplementario.Services;
using MySql.Data.MySqlClient;
namespace AndresPerezComplementario.Views;

public partial class Login : ContentPage
{
    string connectionString = "Server=localhost;Database=DBUISSAEL;Uid=root;Pwd=;";
    public Login()
	{
        InitializeComponent();
    }
    private async void OnLoginClicked(object sender, EventArgs e)
{
    var usuario = UsuarioEntry.Text;
    var contrasena = ContrasenaEntry.Text;

    using var connection = new DatabaseService().GetConnection();
    await connection.OpenAsync();

    var command = new MySqlCommand("SELECT * FROM ESTUDIANTES_LOGIN WHERE USUARIO=@Usuario AND CONTRASE�A=@Contrasena", connection);
    command.Parameters.AddWithValue("@Usuario", usuario);
    command.Parameters.AddWithValue("@Contrasena", contrasena);

    using var reader = await command.ExecuteReaderAsync();
    if (reader.HasRows)
    {
        await Navigation.PushAsync(new Principal());
    }
    else
    {
        ErrorLabel.Text = "Usuario o contrase�a incorrectos.";
        ErrorLabel.IsVisible = true;
    }
}

}
