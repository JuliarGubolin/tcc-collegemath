using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using CollegeMath.App.Droid.Models.Custom;
using CollegeMath.App.Models.Custom;

[assembly: ExportRenderer(typeof(RoundedEntry), typeof(RoundedEntryRenderAndroid))]
namespace CollegeMath.App.Droid.Models.Custom
{
    public class RoundedEntryRenderAndroid : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(10f);
                gradientDrawable.SetStroke(5, Android.Graphics.Color.Rgb(91, 200, 175));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(43, 43, 128));
                Control.SetBackground(gradientDrawable);
                Control.SetTextColor(Android.Graphics.Color.White);
                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight, Control.PaddingBottom);
            }
        }

        public RoundedEntryRenderAndroid(Context context) : base(context)
        {

        }
    }
}