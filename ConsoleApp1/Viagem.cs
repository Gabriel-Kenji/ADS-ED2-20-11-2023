namespace ConsoleApp1;

public class Viagem
{
    private Veiculo _veiculo;
    private int code_destino;
    private String nome_destino;
    private int passageiros;

    public Viagem(Veiculo veiculo, int codeDestino, string nomeDestino, int passageiros)
    {
        _veiculo = veiculo;
        code_destino = codeDestino;
        nome_destino = nomeDestino;
        this.passageiros = passageiros;
    }

    public Veiculo Veiculo
    {
        get => _veiculo;
        set => _veiculo = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int CodeDestino
    {
        get => code_destino;
        set => code_destino = value;
    }

    public string NomeDestino
    {
        get => nome_destino;
        set => nome_destino = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Passageiros
    {
        get => passageiros;
        set => passageiros = value;
    }
}