using System;
using System.Collections.Generic;
using CoreGraphics;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using YuCollectionView = YUCollectionView.YUCollectionView;

namespace YUCollectionView.iOS
{
    public class YUCollectionViewDelegator<TItemsView, TViewController> : GroupableItemsViewDelegator<TItemsView, TViewController>
        where TItemsView : YuCollectionView
        where TViewController : YUCollectionViewViewController<TItemsView>
    {
        private MenuContext menuContext;

        public YUCollectionViewDelegator(ItemsViewLayout itemsViewLayout, TViewController itemsViewController) : base(itemsViewLayout, itemsViewController)
        {
        }

        public YUCollectionViewDelegator(ItemsViewLayout itemsViewLayout, TViewController itemsViewController, MenuContext menuContext) : base(itemsViewLayout, itemsViewController)
        {
            this.menuContext = menuContext;
        }

        public override UIContextMenuConfiguration GetContextMenuConfiguration(UICollectionView collectionView, NSIndexPath indexPath, CGPoint point)
        {
            var index = (int)indexPath.Item;
            var title = menuContext.Title ?? "";

            var actions = new List<UIAction>();

            foreach(var item in menuContext.ItemsSource)
            {
                var menu = (MenuItem)item;
                var action = UIAction.Create(menu.Name, null, menu.Name.ToLower(), (arg) =>
                {
                    menu.Command?.Execute(index);
                });
                actions.Add(action);
            }

            var actionProvider = new UIContextMenuActionProvider((sa) =>
            {
                return UIMenu.Create(title, actions.ToArray());
            });
            var configuration = UIContextMenuConfiguration.Create(null, null, actionProvider);
            return configuration;
        }
    }
}
