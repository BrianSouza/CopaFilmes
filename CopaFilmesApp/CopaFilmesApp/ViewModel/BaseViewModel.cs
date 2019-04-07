﻿using CopaFilmesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;

namespace CopaFilmesApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public IFilmesProvider filmesProvider = null;
        public IMessageService messageService = null;
        public event PropertyChangedEventHandler PropertyChanged;

        
        public BaseViewModel()
        {
            filmesProvider = DependencyService.Get<IFilmesProvider>();
            messageService = DependencyService.Get<IMessageService>();
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value))
            {
                return false;
            }
            storage = value;
            OnPropertyChanged(propertyName);

            return true;
        }

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
