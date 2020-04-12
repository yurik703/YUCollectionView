using System;
using Android.Content;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using YUCollectionView.Droid;
using static Android.Views.View;
using YuCollectionView = YUCollectionView.YUCollectionView;

[assembly: ExportRenderer(typeof(YuCollectionView), typeof(YUCollectionViewFinalRenderer))]
namespace YUCollectionView.Droid
{
    public class YUCollectionViewFinalRenderer : CollectionViewRenderer, IOnCreateContextMenuListener, IMenuItemOnMenuItemClickListener
    {
        public YUCollectionViewFinalRenderer(Context context) : base(context)
        {
        }

        public void OnCreateContextMenu(IContextMenu menu, Android.Views.View v, IContextMenuContextMenuInfo menuInfo)
        {
            var collectionView = (YuCollectionView)Element;
            if (collectionView.MenuContext != null)
            {
                var menuContext = collectionView.MenuContext;
                if (menuContext.ItemsSource != null)
                {
                    var items = menuContext.ItemsSource;

                    if(!string.IsNullOrEmpty(menuContext.Title))
                        menu.SetHeaderTitle(menuContext.Title);

                    foreach(var item in items)
                    {
                        var menuItem = (MenuItem)item;

                        var mi = menu.Add(0, v.Id, 0, menuItem.Name);
                        mi.SetOnMenuItemClickListener(this);
                    }
                }
            }
        }

        public bool OnMenuItemClick(IMenuItem item)
        {
            return true;
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ItemsView> e)
        {
            base.OnElementChanged(e);

            if(e.NewElement != null)
            {
                var collectionView = (YuCollectionView)Element;
                if (collectionView.MenuContext != null)
                {
                    var menuContext = collectionView.MenuContext;
                    if (menuContext.ItemsSource != null)
                    {
                        var items = menuContext.ItemsSource;
                        SetOnCreateContextMenuListener(this);
                    }
                }
                
            }
        }
    }
}
