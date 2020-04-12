using System;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using YUCollectionView.iOS;
using YuCollectionView = YUCollectionView.YUCollectionView;

//[assembly: ExportRenderer(typeof(YuCollectionView), typeof(YUCollectionViewRenderer))]
[assembly: ExportRenderer(typeof(YuCollectionView), typeof(YUCollectionViewFinalRenderer))]
namespace YUCollectionView.iOS
{
    public class YUCollectionViewRenderer<TItemsView, TViewController> : GroupableItemsViewRenderer<YuCollectionView, YUCollectionViewViewController<YuCollectionView>>
        where TItemsView : YuCollectionView
        where TViewController : YUCollectionViewViewController<YuCollectionView>
    {

        protected override YUCollectionViewViewController<YuCollectionView> CreateController(YuCollectionView itemsView, ItemsViewLayout layout)
        {
            return new YUCollectionViewViewController<YuCollectionView>(itemsView, layout) as TViewController;
        }
    }

    public class YUCollectionViewFinalRenderer : YUCollectionViewRenderer<YuCollectionView, YUCollectionViewViewController<YuCollectionView>>
    {

    }
}
