namespace ConsoleApp1;

public class Garagem
{
    private int codigo;
    private string nome;
    private Stack<Veiculo> _veiculos = new Stack<Veiculo>();
    private List<Viagem> _viagems = new List<Viagem>();

    public Garagem()
    {
        this.codigo = 0;
        this.nome = "";
        _veiculos = new Stack<Veiculo>();
        _viagems = new List<Viagem>();
    }

    public Garagem(int codigo, string nome, Stack<Veiculo> veiculos, List<Viagem> _viagems)
    {
        this.codigo = codigo;
        this.nome = nome;
        _veiculos = veiculos;
        this._viagems = _viagems;
    }

    public List<Viagem> Viagems
    {
        get => _viagems;
        set => _viagems = value ?? throw new ArgumentNullException(nameof(value));
    }

    public int Codigo
    {
        get => codigo;
        set => codigo = value;
    }

    public string Nome
    {
        get => nome;
        set => nome = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Stack<Veiculo> Veiculos
    {
        get => _veiculos;
        set => _veiculos = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void adicionarVeiculo(Veiculo veiculo)
    {
        _veiculos.Push(veiculo);
    }

    public Veiculo retirarVeiculo()
    {
        return _veiculos.Pop();
    }

    public void viagem(Garagem destino, int quantidade)
    {
        Veiculo veiculo = retirarVeiculo();
        _viagems.Add(new Viagem(veiculo, destino.codigo, destino.nome, quantidade));
        destino.adicionarVeiculo(veiculo);
    }
}