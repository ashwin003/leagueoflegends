﻿using System.Windows;
using System.Windows.Controls;

namespace Leagueoflegends.TeamFight.UI.Units
{
    public class Thumbnails : Control
    {
        static Thumbnails()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Thumbnails), new FrameworkPropertyMetadata(typeof(Thumbnails)));
        }
    }
}
