﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using Filtration.ObjectModel.Annotations;

namespace Filtration.ObjectModel.BlockItemBaseTypes
{
    public abstract class BlockItemBase : IItemFilterBlockItem
    {
        public abstract string PrefixText { get; }
        public abstract string OutputText { get; }
        public abstract int MaximumAllowed { get; }
        public abstract string DisplayHeading { get; }
        public abstract string SummaryText { get; }
        public abstract Color SummaryBackgroundColor { get; }
        public abstract Color SummaryTextColor { get; }
        public abstract int SortOrder { get; }
        public abstract bool IsDirty { get; protected set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
