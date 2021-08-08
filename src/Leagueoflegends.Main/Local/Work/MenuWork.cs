﻿using Leagueoflegends.Data.Main;
using Leagueoflegends.Foundation.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Leagueoflegends.Main.Local.Work
{
    public class MenuWork : ObservableObject
    {
        private readonly Action<MainMenuModel, List<SubMenuModel>> _menuCommand;

        #region Menus

        private MainMenuModel _currentMenu;
        public MainMenuModel CurrentMenu
        {
            get => _currentMenu;
            set { _currentMenu = value; OnPropertyChanged(); }
        }

        public List<MainMenuModel> Menus { get; }

        #endregion

        public List<SubMenuModel> TotalSubMenus { get; }

        #region Constructor

        public MenuWork(Action<MainMenuModel, List<SubMenuModel>> menuCommand)
        {
            _menuCommand = menuCommand;

            Menus = GetMenus();
            Menus.ForEach(x => x.MenuSelectCommand = new RelayCommand<MainMenuModel>(MenuChanged));
            TotalSubMenus = GetSubMenus();

            CurrentMenu = Menus.First();
            MenuChanged(CurrentMenu);
        }

        private void MenuChanged(MainMenuModel obj)
        {
            List<SubMenuModel> subMenus = TotalSubMenus.Where(x => x.MainSeq == obj.Seq).ToList();
            _menuCommand.Invoke(obj, subMenus);
        }
        #endregion

        #region GetMenus

        private List<MainMenuModel> GetMenus()
        {
            List<MainMenuModel> source = new()
            {
                new MainMenuModel(0, "HOME", "TEXT"),
                new MainMenuModel(1, "TFT", "TEXT"),
                new MainMenuModel(2, "CLASH", "TEXT"),
                new MainMenuModel(3, "Profile", "ICON"),
                new MainMenuModel(4, "Collection", "ICON"),
                new MainMenuModel(5, "Loot", "ICON"),
                new MainMenuModel(6, "My Shop", "ICON"),
                new MainMenuModel(7, "Store", "ICON")
            };
            return source;
        }
        #endregion

        #region GetSubMenus

        private List<SubMenuModel> GetSubMenus()
        {
            List<SubMenuModel> source = new()
            {
                new SubMenuModel(0, 0, "OVERVIEW"),
                new SubMenuModel(1, 0, "PRESEASON"),
                new SubMenuModel(2, 0, "PATCH NOTES"),

                new SubMenuModel(3, 4, "CHAMPIONS"),
                new SubMenuModel(4, 4, "SKINS"),
                new SubMenuModel(5, 4, "EMOTES"),
                new SubMenuModel(6, 4, "RUNES"),
                new SubMenuModel(7, 4, "SPELLS"),
                new SubMenuModel(8, 4, "ITEMS"),
                new SubMenuModel(9, 4, "ICONS"),
                new SubMenuModel(10, 4, "WARDS"),
                new SubMenuModel(11, 4, "CHROMAS"),

                new SubMenuModel(12, 7, "FEATURED"),
                new SubMenuModel(13, 7, "CHAMPIONS"),
                new SubMenuModel(14, 7, "SKINS"),
                new SubMenuModel(15, 7, "TFT"),
                new SubMenuModel(16, 7, "LOOT"),
                new SubMenuModel(17, 7, "ACCESSORIES"),
            };
            return source;
        }
        #endregion
    }
}