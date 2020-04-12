using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using YUCollectionView.iOS;
using YuCollectionView = YUCollectionView.YUCollectionView;

namespace YUCollectionView.iOS
{
    public class YUCollectionViewViewController<TItemsView> : GroupableItemsViewController<TItemsView> where TItemsView : YuCollectionView
    {

        public YUCollectionViewViewController(TItemsView groupableItemsView, ItemsViewLayout layout) : base(groupableItemsView, layout)
        {
        }
        
        protected override UICollectionViewDelegateFlowLayout CreateDelegator()
        {
            var collectionView = (YuCollectionView)ItemsView;
            if(collectionView.MenuContext != null)
            {
                var menuContext = collectionView.MenuContext;
                if(menuContext.ItemsSource != null)
                {
                    var items = menuContext.ItemsSource;

                    return new YUCollectionViewDelegator<TItemsView, YUCollectionViewViewController<TItemsView>>(ItemsViewLayout, this, menuContext);
                }
            }
            return base.CreateDelegator();
        }
    }
}
