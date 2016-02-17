using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Animation;

namespace File_Renamer
{
    internal class AnimatableGrid : AnimationTimeline
    {
        public override Type TargetPropertyType
        {
            get { return typeof(GridLength); }
        }

        protected override Freezable CreateInstanceCore()
        {
            return new AnimatableGrid();
        }

        static AnimatableGrid()
        {
            FromProperty = DependencyProperty.Register("From", typeof(GridLength), typeof(AnimatableGrid));

            ToProperty = DependencyProperty.Register("To", typeof(GridLength), typeof(AnimatableGrid));
        }


        public static readonly DependencyProperty FromProperty;
        public GridLength From
        {
            get
            {
                return (GridLength)GetValue(AnimatableGrid.FromProperty);
            }
            set
            {
                SetValue(AnimatableGrid.FromProperty, value);
            }
        }


        public static readonly DependencyProperty ToProperty;
        public GridLength To
        {
            get
            {
                return (GridLength)GetValue(AnimatableGrid.FromProperty);
            }
            set
            {
                SetValue(AnimatableGrid.ToProperty, value);
            }
        }


        public override object GetCurrentValue(object defaultOriginValue, object defaultDestinationValue, AnimationClock animationClock)
        {
            double fromVal = ((GridLength)GetValue(AnimatableGrid.FromProperty)).Value;
            double toVal = ((GridLength)GetValue(AnimatableGrid.ToProperty)).Value;

            if (fromVal > toVal)
            {
                return new GridLength((1 - animationClock.CurrentProgress.Value) * (fromVal - toVal) + toVal, this.To.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
            }
            else
            {
                return new GridLength(animationClock.CurrentProgress.Value * (toVal - fromVal) + fromVal, this.To.IsStar ? GridUnitType.Star : GridUnitType.Pixel);
            }
        }


        

        

    }
}
