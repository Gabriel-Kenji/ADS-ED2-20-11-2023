namespace ConsoleApp1;

public class Veiculo
{
    private string placa;
    private int numero;

    public Veiculo()
    {
        this.placa = "0A0A0A0";
        this.numero = 1;
    }
    
    public Veiculo(string placa, int numero)
    {
        this.placa = placa;
        this.numero = numero;
    }

    public string Placa
    {
        get => placa;
        set => placa = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public int Numero
    {
        get => numero;
        set => numero = value;
    }

    
}