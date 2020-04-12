using System;
using Xamarin.Forms;

namespace YUCollectionView
{
    public class YUCollectionView : CollectionView
    {
        public static readonly BindableProperty MenuContextProperty = BindableProperty.Create(nameof(MenuContext), typeof(MenuContext), typeof(YUCollectionView), default(MenuContext));
        
        public MenuContext MenuContext
        {
            get => (MenuContext)GetValue(MenuContextProperty);
            set => SetValue(MenuContextProperty, value);
        }

        public YUCollectionView()
        {
            
        }
    }
}
