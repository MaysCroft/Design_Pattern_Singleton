using System.Windows.Input;
using System.ComponentModel;
using AppPadraoSingleton.Commands;
using AppPadraoSingleton.Services;

namespace AppPadraoSingleton.ViewModels;

public class BaseViewModel : INotifyPropertyChanged
{
    private readonly GerenciadorSessao _sessao = GerenciadorSessao.Instance;

    public string Titulo => $"Câmara de Jade - Tianquan: {_sessao.UsuarioLogado}";
    public int MoraAtual => _sessao.MoraAcumulada;

    public ICommand ColetarCommand { get; }

    public BaseViewModel()
    {
        _sessao.PropertyChanged += (sender, args) =>
        {
            if (args.PropertyName == nameof(GerenciadorSessao.MoraAcumulada))
            {
                OnPropertyChanged(nameof(MoraAtual));
            }
        };

        ColetarCommand = new RelayCommand(() => _sessao.ColetarTaxas(55000));
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}