namespace ConsoleApp1;

public class Empresa
{
    private string cnpj;
    private string name;
    private List<Garagem> _garagems = new List<Garagem>();
    private Stack<Veiculo> _veiculos = new Stack<Veiculo>();
    private bool jornada;

    public Empresa(string cnpj, string name)
    {
        this.cnpj = cnpj;
        this.name = name;
        this.jornada = false;
    }

    public string Cnpj
    {
        get => cnpj;
        set => cnpj = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public List<Garagem> Garagems
    {
        get => _garagems;
        set => _garagems = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Stack<Veiculo> Veiculos
    {
        get => _veiculos;
        set => _veiculos = value ?? throw new ArgumentNullException(nameof(value));
    }

    public bool Jornada
    {
        get => jornada;
        set => jornada = value;
    }

    public void adicionarVeiculo(Veiculo veiculo)
    {
        _veiculos.Push(veiculo);
    }

    public Veiculo retirarVeiculo()
    {
        return _veiculos.Pop();
    }

    public Garagem pesquisar(Garagem garagem)
    {
        foreach (var garage in Garagems)
        {
            if (garage.Codigo == garagem.Codigo)
            {
                return garage;
            }
        }
        return null;
    }
}