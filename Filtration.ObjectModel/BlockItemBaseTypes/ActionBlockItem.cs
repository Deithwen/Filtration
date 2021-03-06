﻿using System.Windows.Media;
using Filtration.ObjectModel.Enums;
using Filtration.ObjectModel.Extensions;

namespace Filtration.ObjectModel.BlockItemBaseTypes
{
    public sealed class ActionBlockItem : BlockItemBase
    {
        private BlockAction _action;
        private bool _isDirty;

        public ActionBlockItem(BlockAction action)
        {
            Action = action;
        }

        public BlockAction Action
        {
            get { return _action; }
            set
            {
                _action = value;
                IsDirty = true;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SummaryText));
                OnPropertyChanged(nameof(SummaryBackgroundColor));
                OnPropertyChanged(nameof(SummaryText));
            }
        }

        public override string OutputText => Action.GetAttributeDescription();

        public override string PrefixText => string.Empty;

        public override int MaximumAllowed => 1;

        public override string DisplayHeading => "Action";

        public override string SummaryText => Action == BlockAction.Show ? "Show" : "Hide";

        public override Color SummaryBackgroundColor => Action == BlockAction.Show ? Colors.LimeGreen : Colors.OrangeRed;

        public override Color SummaryTextColor => Action == BlockAction.Show ? Colors.Black : Colors.White;

        public override int SortOrder => 0;

        public override bool IsDirty
        {
            get { return _isDirty; }
            protected set
            {
                _isDirty = value;
                OnPropertyChanged();
            }
        }

        public void ToggleAction()
        {
            Action = Action == BlockAction.Show ? BlockAction.Hide : BlockAction.Show;
        }
    }
}
