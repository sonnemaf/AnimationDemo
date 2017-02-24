using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Animation;

namespace AnimationDemo {
    public class StoryboardServices {

        #region IsPlaying Attached Property

        /// <summary> 
        /// Identifies the IsPlaying attachted property. This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsPlayingProperty =
            DependencyProperty.RegisterAttached("IsPlaying",
                                                typeof(bool),
                                                typeof(StoryboardServices),
                                                new PropertyMetadata(false, OnIsPlayingChanged));

        /// <summary>
        /// IsPlaying changed handler. 
        /// </summary>
        /// <param name="d">FrameworkElement that changed its IsPlaying attached property.</param>
        /// <param name="e">DependencyPropertyChangedEventArgs with the new and old value.</param> 
        private static void OnIsPlayingChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var source = d as Storyboard;
            if (source != null) {
                var value = (bool)e.NewValue;
                if (value) {
                    if (source.GetCurrentState() == ClockState.Stopped) {
                        source.Begin();
                    } else {
                        source.Resume();
                    }
                } else {
                    source.Pause();
                }
            }
        }

        /// <summary>
        /// Gets the value of the IsPlaying attached property from the specified FrameworkElement.
        /// </summary>
        public static bool GetIsPlaying(DependencyObject obj) {
            return (bool)obj.GetValue(IsPlayingProperty);
        }


        /// <summary>
        /// Sets the value of the IsPlaying attached property to the specified FrameworkElement.
        /// </summary>
        /// <param name="obj">The object on which to set the IsPlaying attached property.</param>
        /// <param name="value">The property value to set.</param>
        public static void SetIsPlaying(DependencyObject obj, bool value) {
            obj.SetValue(IsPlayingProperty, value);
        }

        #endregion IsPlaying Attached Property

    }
}
