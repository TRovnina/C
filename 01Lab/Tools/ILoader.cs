using System.ComponentModel;
using System.Windows;


namespace _01Rovnina.Tools
{
    internal interface ILoader : INotifyPropertyChanged
    {
        Visibility LoaderVisibility { get; set; }
        bool IsControlEnabled { get; set; }
    }
}
