﻿using Neutronium.MVVMComponents;
using Neutronium.MVVMComponents.Relay;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Neutronium.BuildingBlocks.Application.Navigation;
using Neutronium.BuildingBlocks.Application.WindowServices;
using Neutronium.BuildingBlocks.ApplicationTools;
using Neutronium.SPA.Demo.ViewModel.Common;

namespace Neutronium.SPA.Demo.ViewModel
{
    public class MainViewModel : BuildingBlocks.ViewModel
    {
        public ISimpleCommand GoToAbout { get; }
        public ISimpleCommand Restart { get; }
        public ISimpleCommand AddItem { get; }
        public ISimpleCommand<ItemViewModel> RemoveItem { get; }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        public IList<ItemViewModel> Items { get; } = new ObservableCollection<ItemViewModel>();

        private readonly INavigator _Navigator;
        private readonly IApplication _Application;
        private readonly IMessageBox _MessageBox;

        public MainViewModel(INavigator navigator, IApplication application, IMessageBox messageBox)
        {
            _Navigator = navigator;
            _Application = application;
            _MessageBox = messageBox;
            GoToAbout = new RelaySimpleCommand(DoGoToAbout);
            Restart = new RelaySimpleCommand(DoRestart);
            AddItem = new RelaySimpleCommand(DoAddNewItem);
            RemoveItem = new RelaySimpleCommand<ItemViewModel>(DoRemoveItem);
        }

        private void DoRemoveItem(ItemViewModel item)
        {
            Items.Remove(item);
        }

        private void DoAddNewItem()
        {
            if (string.IsNullOrEmpty(_Name))
                return;

            Items.Add(new ItemViewModel { Name = _Name });
            Name = String.Empty;
        }

        private void DoGoToAbout()
        {
            _Navigator.Navigate<AboutViewModel>();
        }

        private async void DoRestart()
        {
            var message = new ConfirmationMessage(Resource.ConfirmationNeeded, Resource.DoYouWantToRestartApplication, Resource.Ok, Resource.Cancel);
            var res = await _MessageBox.ShowMessage(message);

            if (res)
                _Application.Restart();
        }
    }
}
