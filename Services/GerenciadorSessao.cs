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
    
}