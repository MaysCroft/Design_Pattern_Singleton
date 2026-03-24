using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AppPadraoSingleton.Services;

public class GerenciadorSessao : INotifyPropertyChanged
{
    private static readonly Lazy<GerenciadorSessao> _instance =
        new Lazy<GerenciadorSessao>(() => new GerenciadorSessao());

    public static GerenciadorSessao Instance => _instance.Value;

    public string UsuarioLogado { get; } = "Ningguang";

    private int _moraAcumulada;

    public int MoraAcumulada
    {
        get => _moraAcumulada;
        private set
        {
            _moraAcumulada = value;
            OnPropertyChanged(); // Avisando o sistema que o valor mudou
        }
    }

    private GerenciadorSessao()
    {
        MoraAcumulada = 5000000;
    }

    public void ColetarTaxas(int valor)
    {
        MoraAcumulada += valor;
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}